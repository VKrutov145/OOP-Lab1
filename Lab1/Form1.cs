using System;
using System.Windows.Forms;


namespace Lab1
{
    public partial class Form1 : Form
    {
        Data gridData1 = new Data();
        
        private const int INTERFACEOBJECTSHEIGHT = 50;

        public void UpdateLabelAboutRowsAndColumns()
        {
            lblColumnsAmount.Text = "Columns: " + gridData1.GetColAmount().ToString();
            lblRowsAmount.Text = "Rows: " + gridData1.GetRowAmount().ToString();
        }
        
        public void HideRowsAndColumnsEditingPanel()
        {
            rbtnAddRowColumn.Hide();
            rbtnDeleteRowColumn.Hide();
            btnNColumns.Hide();
            btnNRows.Hide();
            lblNumberOfAddedDeletedRowsColumns.Hide();
            txtbxNRowsColumns.Hide();
            btnStopEditingRowsColumns.Hide();
        }
        public void ShowRowsAndColumnsEditingPanel()
        {
            rbtnAddRowColumn.Show();
            rbtnDeleteRowColumn.Show();
            btnNColumns.Show();
            btnNRows.Show();
            lblNumberOfAddedDeletedRowsColumns.Show();
            txtbxNRowsColumns.Show();
            btnStopEditingRowsColumns.Show();
        }
        
        
        
        public Form1()
        {
            InitializeComponent();
            rbtnAddRowColumn.Hide();
            rbtnDeleteRowColumn.Hide();
            btnNColumns.Hide();
            btnNRows.Hide();
            lblNumberOfAddedDeletedRowsColumns.Hide();
            txtbxNRowsColumns.Hide();
            btnStopEditingRowsColumns.Hide();
            
            txtbxExpression.Hide();
        }

        private void btnBackToStartMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void buttonAddRowColumn_Click(object sender, EventArgs e)
        {
            btnAddRowColumn.Hide();
            btnAddRowColumn.Height = INTERFACEOBJECTSHEIGHT;
            txtbxExpression.Hide();

            rbtnAddRowColumn.Show();
            rbtnDeleteRowColumn.Show();
            btnNColumns.Show();
            btnNRows.Show();
            lblNumberOfAddedDeletedRowsColumns.Show();
            txtbxNRowsColumns.Show();
            btnStopEditingRowsColumns.Show();
            
        }

        private void btnNRows_Click(object sender, EventArgs e)
        {
            var rowsAmount = dataGridView1.Rows.Count;
            var N = Convert.ToInt32(txtbxNRowsColumns.Text);
            
            if (rbtnAddRowColumn.Checked == true)
            {
                if (dataGridView1.Columns.Count != 0) 
                {
                    dataGridView1.Rows.Add(N);
                    for (int i = 1; i <= N; i++)
                    {
                        gridData1.AddRow();
                    }
                    UpdateLabelAboutRowsAndColumns();
                }
                else
                {
                    dataGridView1.Columns.Add("A", "A");
                    gridData1.AddCol();
                    dataGridView1.Rows.Add(N);   
                    for (int i = 1; i <= N; i++)
                    {
                        gridData1.AddRow();
                    }

                    UpdateLabelAboutRowsAndColumns();
                }
            }
            else
            {
                if (N < rowsAmount)
                {
                   for (var i = 1; i <= N; i++)
                   {
                       var dgvDelRow = dataGridView1.Rows[dataGridView1.Rows.Count-2];  
                       dataGridView1.Rows.Remove(dgvDelRow);  
                       gridData1.DeleteRow();
                   }

                   UpdateLabelAboutRowsAndColumns();
                }
                else
                {
                    MessageBox.Show("Attempt to delete more rows than table has");
                }
            }
        }

        private void btnNColumns_Click(object sender, EventArgs e)
        {
            var columnsAmount = dataGridView1.Columns.Count;
            var N = Convert.ToInt32(txtbxNRowsColumns.Text);
            
                if (rbtnAddRowColumn.Checked == true)
                {
                    for (var i = 1; i <= N; i++)
                    {
                        string columnName = HelpfulFunctions.GetColNameFromIndex(columnsAmount + i); 
                        dataGridView1.Columns.Add(columnName, columnName);
                        
                        gridData1.AddCol();
                    }

                    if (gridData1.GetColAmount()==1)
                    {
                        gridData1.AddRow();
                    }
                    UpdateLabelAboutRowsAndColumns();
                }
                else
                {
                    if (N <= columnsAmount)
                    {
                        for (var i = 0; i < N; i++)
                        {
                            string columnName = HelpfulFunctions.GetColNameFromIndex(columnsAmount - i);
                            dataGridView1.Columns.Remove(columnName);
                            
                            gridData1.DeleteCol();
                        }

                        if (dataGridView1.Columns.Count == 0)
                        {
                            gridData1.DeleteRow();
                        }
                        UpdateLabelAboutRowsAndColumns();
                    }
                    else
                    {
                        MessageBox.Show("Attempt to delete more columns than table has");
                    }
                }
        }

        private void btnStopEditingRowsColumns_Click(object sender, EventArgs e)
        {
            btnAddRowColumn.Show();

            rbtnAddRowColumn.Hide();
            rbtnDeleteRowColumn.Hide();
            btnNColumns.Hide();
            btnNRows.Hide();
            lblNumberOfAddedDeletedRowsColumns.Hide();
            txtbxNRowsColumns.Hide();
            btnStopEditingRowsColumns.Hide();
        }
        
        
        
        

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            HideRowsAndColumnsEditingPanel();
            btnAddRowColumn.Height = INTERFACEOBJECTSHEIGHT/2;
            btnAddRowColumn.Show();
            txtbxExpression.Show();
            txtbxExpression.Clear();

            //dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = txtbxExpression.Text;
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //txtbxExpression.Text = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            // if (Data.cells[e.RowIndex][e.ColumnIndex].Expression != null)
            //     if (!String.IsNullOrEmpty(Data.cells[e.RowIndex][e.ColumnIndex].Error))
            //         dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Data.cells[e.RowIndex][e.ColumnIndex].Error;
            //     else
            //         dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Data.cells[e.RowIndex][e.ColumnIndex].Value.ToString();
        }
    }
}