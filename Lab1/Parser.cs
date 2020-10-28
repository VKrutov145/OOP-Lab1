using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Runtime.Remoting.Channels;
using System.Windows.Forms;
using System.Xml.Schema;

namespace Lab1
{
    class ParserException : ApplicationException
    {
        public ParserException(string str) : base (str) { }

        public override string ToString()
        {
            return Message;
        }
    }
    class Parser
    {
        public static string GetColNameFromIndex(int columnNumber) 
        { 
            int dividend = columnNumber; 
            string columnName = String.Empty; 
            int modulo;
            
            while (dividend > 0) 
            { 
                modulo = (dividend - 1) % 26; 
                columnName = Convert.ToChar(65 + modulo).ToString() + columnName; 
                dividend = (int)((dividend - modulo) / 26);
                
            }
            return columnName;
        }
        // (A = 1, B = 2...AA = 27...AAA = 703...)
        public static int GetColNumberFromName(string columnName) 
        { 
            char[] characters = columnName.ToUpperInvariant().ToCharArray(); 
            int sum = 0; 
            for (int i = 0; i < characters.Length; i++) 
            { 
                sum *= 26; 
                sum += (characters[i] - 'A' + 1);
                
            }

            return sum;
        }
        enum Types
        {
            NONE,
            DELIMITER,
            VARIABLE,
            NUMBER,
            FUNCTION
        };
        enum Errors
        {
            SYNTAX,
            UNBALPARENS,
            NOEXP,
            DIVIBYZERO,
            INVALIDFUNCTION
        };

        private struct variableIndex
        {
           public int x;
           public int y;
        };
        private string exp;
        private int expIndex;
        private string token;
        private Types tokenType;

        List<List<double>> vars = new List<List<double>>();
        private const int VARS_SIZE = 200;

        private bool checkExpForFucntion(int expIdx)
        {
            int i = expIdx;
            if (i+2 < exp.Length)
            {
                return ((exp[i] == 'i' || exp[i] == 'I') && (exp[i+1] == 'n' || exp[i+1] == 'N') &&
                        (exp[i+2] == 'c' || exp[i+2] == 'C')) ||
                       ((exp[i] == 'd' || exp[i] == 'D') && (exp[i+1] == 'e' || exp[i+1] == 'E') &&
                        (exp[i+2] == 'c' || exp[i+2] == 'C')) ||
                       ((exp[i] == 'm' || exp[i] == 'M') && (exp[i+1] == 'm' || exp[i+1] == 'M') &&
                        (exp[i+2] == 'a' || exp[i+2] == 'A') && (exp[i+3] == 'x' || exp[i+3] == 'X')) ||
                       ((exp[i] == 'm' || exp[i] == 'M') && (exp[i+1] == 'm' || exp[i+1] == 'M') &&
                        (exp[i+2] == 'i' || exp[i+2] == 'I') && (exp[i+3] == 'n' || exp[i+3] == 'N'));
            }
            return false;
        }
        public Parser() 
        {
            for (int i = 0; i < VARS_SIZE; i++)
            {
                List<double> vars_list = new List<double>(VARS_SIZE);
                for (int j = 0; j < VARS_SIZE; j++)
                {
                    vars_list.Add(0.0);
                }
                vars.Add(vars_list);
            }

            /*for (int i = 0; i < VARS_SIZE; i++)
            {
                for (int j = 0; j < VARS_SIZE; j++)
                {
                    vars[i][j] = 0.0;
                }
            }*/

            /*foreach (var list in vars)
            {
                for (int i = 0; i < VARS_SIZE; i++)
                {
                    list[i] = 0.0;
                }
                /*foreach (var cell_value in list)
                {

                }#1#
            }*/
        }

        public void ChangeVars(int indexX, int indexY, double value)
        {
            vars[indexX][indexY] = value;
        }
        public double Evaluate(string expstr)
        {
            double result;
            exp = expstr;
            expIndex = 0;
            try
            {
                GetToken();
                if (token == "")
                {
                    SyntaxErr(Errors.NOEXP);
                    return 0.0;
                }

                EvalExp1(out result);
                if (token != "")
                {
                   SyntaxErr(Errors.SYNTAX);
                }

                return result;
            }
            catch (ParserException exc)
            {
                MessageBox.Show(exc.ToString());
                return 0.0;
            }
        }
        
        void EvalExp1(out double result) 
        {
            variableIndex varIndex;
            Types tempTokenType;
            string tempToken;
            if (tokenType == Types.VARIABLE)
            {
                tempToken = String.Copy(token);
                tempTokenType = tokenType;


                varIndex.x = GetColNumberFromName(LiteralPartOfVar(token))-1; 
                varIndex.y = Convert.ToInt32(NumericalPartOfVar(token))-1;

                GetToken();
                if (token != "=")
                {
                    PutBack();
                    token = String.Copy(tempToken);
                    tokenType = tempTokenType;
                }
                else
                {
                    GetToken();
                    EvalExp2(out result);
                    vars[varIndex.x][varIndex.y] = result;
                    return;
                }
            }
            EvalExp2(out result);
        }

        void EvalExp2(out double result)
        {
            string op;
            double partialResult;

            EvalExp3(out result);
            while ((op = token) == "+" || op == "-")
            {
                GetToken();
                EvalExp3(out partialResult);
                switch (op)
                {
                    case "-":
                    {
                        result = result - partialResult;
                        break;
                    }
                    case "+":
                    {
                        result = result + partialResult;
                        break;
                    }
                }
            }
        }

        void EvalExp3(out double result)
        {
            string op;
            double partialResult = 0.0;
            EvalExp4(out result);
            while ((op = token) == "*" || op == "/" || op == "%")
            {
                GetToken();
                EvalExp4(out partialResult);
                switch (op)
                {
                    case "*" :
                    {
                        result = result * partialResult;
                        break;
                    }
                    case "/":
                    {
                        if (partialResult == 0.0)
                        {
                            SyntaxErr(Errors.DIVIBYZERO);
                        }

                        result = result / partialResult;
                        break;
                    }
                    case "%":
                    {
                        if (partialResult == 0.0)
                        {
                            SyntaxErr(Errors.DIVIBYZERO);
                        }

                        result = (int)result % (int)partialResult;
                        break;
                    }
                }
            }
        }

        void EvalExp4(out double result)
        {
            double partialResult;
            double ex;
            int t;

            EvalExp5(out result);
            if (token == "^")
            {
                GetToken();
                EvalExp4(out partialResult);
                ex = result;
                if (partialResult == 0.0)
                {
                    result = 1.0;
                    return;
                }

                for (t = (int) partialResult - 1; t > 0; t--)
                {
                    result = result * (double) ex;
                }
            }
        }

        void EvalExp5(out double result)
        {
            string op;
            
            op = "";
            if ((tokenType == Types.DELIMITER) && token == "+" || token == "-")
            {
                op = token;
                GetToken();
            }

            EvalExp6(out result);
            if (op == "-")
            {
                result = -result;
            }
        }

        void EvalExp6(out double result)
        {
            if (token == "(")
            {
                GetToken();
                EvalExp2(out result);
                if (token != ")")
                {
                    SyntaxErr(Errors.UNBALPARENS);
                }
                GetToken();
            }
            else
            {
                EvalExp7(out result);   
            }
        }

        void EvalExp7(out double result)
        {
            if (tokenType == Types.FUNCTION)
            {
                switch (token.ToUpper())
                {
                    case "INC":
                    {                
                        GetToken();
                        EvalExp2(out result);
                        result++;
                        break;
                    }
                    case "DEC":
                    {
                        GetToken();
                        EvalExp2(out result);
                        result--;
                        break;
                    }
                    case "MMAX":
                    {
                        expIndex++;
                        result = GetMaxElementInArray();
                        expIndex++;
                        GetToken();
                        break;
                    }
                    case "MMIN":
                    {
                        expIndex++;
                        result = GetMinElementInArray();
                        expIndex++;
                        GetToken();
                        break;
                    }
                    default:
                    {
                        SyntaxErr(Errors.INVALIDFUNCTION);
                        result = 0.0;
                        break;
                    }
                }
            }
            else
            {
                Atom(out result);
            }
        }

        private double GetMaxElementInArray()
        {
            List<double> array = new List<double>();

            int openedBrackets = 1;
            int closedBrackets = 0;

            string mainExp = exp;
            int mainExpIndex = expIndex;
            
            do
            {
                array.Add(GetResultBeforeComma(ref openedBrackets, ref closedBrackets, ref mainExpIndex));
                
                exp = mainExp;
                expIndex = mainExpIndex;
            }
            while (openedBrackets != closedBrackets);

            double max = array[0];
            for (int i = 1; i < array.Count; i++)
            {
                if (max <= array[i])
                {
                    max = array[i];
                }
            }

            exp = mainExp;
            expIndex = mainExpIndex;
            
            return max;
        }
        
        private double GetMinElementInArray()
        {
            List<double> array = new List<double>();

            int openedBrackets = 1;
            int closedBrackets = 0;

            string mainExp = exp;
            int mainExpIndex = expIndex;
            
            do
            {
                array.Add(GetResultBeforeComma(ref openedBrackets, ref closedBrackets, ref mainExpIndex));
                
                exp = mainExp;
                expIndex = mainExpIndex;
            }
            while (openedBrackets != closedBrackets);

            double min = array[0];
            for (int i = 1; i < array.Count; i++)
            {
                if (min > array[i])
                {
                    min = array[i];
                }
            }

            exp = mainExp;
            expIndex = mainExpIndex;
            
            return min;
        }

        void Atom(out double result)
        {
            switch (tokenType)
            {
                case Types.NUMBER:
                {
                    try
                    {
                        result = Double.Parse(token);
                    }
                    catch (FormatException)
                    {
                        result = 0.0;
                        SyntaxErr(Errors.SYNTAX);
                    }

                    GetToken();
                    return;
                }
                case Types.VARIABLE:
                {
                    result = FindVar(token);
                    GetToken();
                    return;
                }
                default:
                {
                    result = 0.0;
                    SyntaxErr(Errors.SYNTAX);
                    break;
                }
            }
        }

        double FindVar(string vname)
        {
            if (!Char.IsLetter(vname[0]))
            {
                SyntaxErr(Errors.SYNTAX);
                return 0.0;
            }

            variableIndex varIndex;
            varIndex.x = GetColNumberFromName(LiteralPartOfVar(token))-1; 
            varIndex.y = Convert.ToInt32(NumericalPartOfVar(token))-1;
            return vars[varIndex.x][varIndex.y];
        }

        void PutBack()
        {
            for (int i = 0; i < token.Length; i++)
            {
                expIndex--;
            }
        }

        void SyntaxErr(Errors error)
        {
            string[] err =
            {
                "Синтаксична помилка",
                "Дисбаланс дужок",
                "Вираз відсутній",
                "Ділення на нуль",
                "Невідома функція"
            };
            throw new ParserException(err[(int)error]);
        }

        void GetToken()
                 {
                     tokenType = Types.NONE;
                     token = "";
                     
                     if (expIndex == exp.Length)
                     {
                         return;
                     }
         
                     while (expIndex < exp.Length && Char.IsWhiteSpace(exp[expIndex]))
                     {
                         ++expIndex;
                     }
         
                     if (expIndex == exp.Length)
                     {
                         return;
                     }
         
                     if (IsDelim(exp[expIndex]))
                     {
                         token += exp[expIndex];
                         expIndex++;
                         tokenType = Types.DELIMITER;
                     }
                     else if (Char.IsLetter(exp[expIndex]))
                     {
                         if (checkExpForFucntion(expIndex) == true)
                         {
                             while (!IsDelim(exp[expIndex]))
                             {
                                 token += exp[expIndex];
                                 expIndex++;
                                 if (expIndex >= exp.Length)
                                 {
                                     SyntaxErr(Errors.SYNTAX);
                                 }
                             }
                             tokenType = Types.FUNCTION;
                         }
                         else
                         {
                             while (!IsDelim(exp[expIndex]))
                             {
                                 token += exp[expIndex];
                                 expIndex++;
                                 if (expIndex >= exp.Length)
                                 {
                                     break;
                                 }
                             }
                             tokenType = Types.VARIABLE;
                         }
                     }
                     else if (Char.IsDigit(exp[expIndex]))
                     {
                         while (!IsDelim(exp[expIndex]))
                         {
                             token += exp[expIndex];
                             expIndex++;
                             if (expIndex >= exp.Length)
                             {
                                 break;
                             }
                         }
                         tokenType = Types.NUMBER;
                     }
                 }

        double GetResultBeforeComma(ref int openedBrackets, ref int closedBrackets, ref int mainExpIndex)
        {
            string partialExpression = "";
            //GetTokenWithoutComma();
            do
            {
                if (exp[expIndex] == '(')
                {
                    openedBrackets++;
                }

                if (exp[expIndex] == ')')
                {
                    closedBrackets++;
                }
                

                if (openedBrackets != closedBrackets)
                {
                    partialExpression += exp[expIndex];
                    ++expIndex;
                    ++mainExpIndex;
                }
                else
                {
                    break;
                }
            } while (",;|".IndexOf(exp[expIndex]) == -1);

            if (openedBrackets != closedBrackets)
            {
                mainExpIndex++;
            }

            return Evaluate(partialExpression);
        }
        
        bool IsDelim(char c)
        {
            if (("+-/*%^=()".IndexOf(c) != -1))
            {
                return true;
            }
            return false;
        }

        string LiteralPartOfVar(string vname)
        {
            string literalPartOfVariable = "";
            int i = 0;

            while (char.IsLetter(vname[i]))
            {
                literalPartOfVariable += vname[i];
                i++;
                if (i >= vname.Length)
                {
                    break;
                }
            }

            return literalPartOfVariable;
        }

        string NumericalPartOfVar(string vname)
        {
            string numericPartOfVariable = "";
            int i = 0;

            while (char.IsLetter(vname[i]))
            {
                i++;
                if (i >= vname.Length)
                {
                    break;
                }
            }
            
            while (char.IsDigit(vname[i]))
            {
                numericPartOfVariable += vname[i];
                i++;
                if (i >= vname.Length)
                {
                    break;
                }
            }
            if (numericPartOfVariable == "")
            {
                SyntaxErr(Errors.SYNTAX);
                return null;
            }
            return numericPartOfVariable;
        }
    }
}