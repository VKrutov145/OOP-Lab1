using System;
using System.Collections.Generic;

namespace Lab1
{
    public class Data
    {
        private List<List<Tuple<string, string>>> gridData = new List<List<Tuple<string, string>>>();

        private int rowAmount;
        private int colAmount;

        public Data()
        {
            rowAmount = 0;
            colAmount = 0;
        }

        /*public Data(int c, int r)
        {

            colAmount = c;
            rowAmount = r;

            for (int i = 0; i < colAmount; i++)
            {
                List<Tuple<string, string>> tempList = new List<Tuple<string, string>>();

                for (int j = 0; j < rowAmount; j++)
                {
                    tempList.Add(new Tuple<string, string>(null,null));
                }

                gridData.Add(tempList);
            }
        }*/
        /*public void WriteListList()
            {
                for (int j = 0; j < rowAmount; j++)
                {
                    for (int i = 0; i < colAmount; i++)
                    {
                        Console.Write(gridData[i][j].Item1);
                        Console.Write("R");
                        Console.Write(gridData[i][j].Item2);
                        Console.Write("|");
                    }
                    Console.WriteLine();
                }
            }*/
        public void AddRow()
        {
            foreach (var column in gridData)
            {
                column.Add(new Tuple<string, string>(null,null));
            }

            rowAmount++;
        }

        public void AddCol()
        {
            Tuple<string, string> nullTuple = new Tuple<string, string>(null,null);
            List<Tuple<string, string>> newColumn = new List<Tuple<string, string>>();
            for (int i = 0; i < rowAmount; i++)
            {
                newColumn.Add(nullTuple);
            }
            gridData.Add(newColumn);

            colAmount++;
        }

        public void DeleteRow()
            {
                if (rowAmount == 0)
                {
                    throw new Exception("Неможливо видалити рядок");
                    return;
                }
                foreach (var column in gridData)
                {
                    column.RemoveAt(rowAmount-1);
                }
                rowAmount--;
            }

        public void DeleteCol()
            {
                if (colAmount == 0)
                {
                    throw new Exception("Неможливо видалити стовпець");
                    return;
                }
                gridData.RemoveAt(colAmount-1);
                colAmount--;
            }

        public int GetRowAmount()
        {
            return rowAmount;
        }
        public int GetColAmount()
        {
            return colAmount;
        }
    }
    
}