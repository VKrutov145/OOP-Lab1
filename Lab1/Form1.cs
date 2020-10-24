using System;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            rbtnAddRowColumn.Hide();
            rbtnDeleteRowColumn.Hide();
            btnNColumns.Hide();
            btnNRows.Hide();
            lblNumberOfAddedDeletedRowsColumns.Hide();
            txtbxNRowsColumns.Hide();
        }

        private void btnBackToStartMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void buttonAddRowColumn_Click(object sender, EventArgs e)
        {
            btnAddRowColumn.Hide();

            rbtnAddRowColumn.Show();
            rbtnDeleteRowColumn.Show();
            btnNColumns.Show();
            btnNRows.Show();
            lblNumberOfAddedDeletedRowsColumns.Show();
            txtbxNRowsColumns.Show();
        }

        private void btnNRows_Click(object sender, EventArgs e)
        {
            
        }

        private void btnNColumns_Click(object sender, EventArgs e)
        {
            var columnsAmount = dataGridView1.Columns.Count;
            var N = Convert.ToInt32(txtbxNRowsColumns.Text);
            if (rbtnAddRowColumn.Checked == true)
            {
                for (var i = 1; i <= N; i++)
                {
                    //string columnName = ;
                    dataGridView1.Columns.Add((columnsAmount + 1).ToString(), (columnsAmount + 1).ToString());
                    /* (1 = A, 2 = B...27 = AA...703 = AAA...)
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
                    }*/
                }
            }
            else
            {
                for (var i = columnsAmount; i >= N; i--)
                {
                    dataGridView1.Columns.Remove((i).ToString());
                }
            }
        }
    }
}