using System;
using System.IO;
using System.Windows.Forms;


namespace Lab1
{
    public partial class Form1 : Form
    {
        private enum FormatOfData
        {
            EXPRESSION,
            VALUE
        }

        private FormatOfData FOD;
        
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

            dataGridView1.AllowUserToAddRows = false;
            FOD = FormatOfData.VALUE;
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

            btnExpValFormat.Height = INTERFACEOBJECTSHEIGHT;
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
                    
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        dataGridView1.Rows[i].HeaderCell.Value = (i + 1).ToString();
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
                            for (int i = 0; i < gridData1.GetRowAmount(); i++)
                            {
                                gridData1.DeleteRow();   
                            }
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
            
            btnExpValFormat.Height = INTERFACEOBJECTSHEIGHT/2;
            
            btnClearAll.Height = INTERFACEOBJECTSHEIGHT/2;
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int colIndex = e.ColumnIndex;
            if (dataGridView1.Rows[rowIndex].Cells[colIndex].Value != null)
            {
                string cellText = dataGridView1.Rows[rowIndex].Cells[colIndex].Value.ToString();
                gridData1.ChangeCellExpression(colIndex,rowIndex,cellText);
            }
            
            
            gridData1.UpdateAllCells();
            for (int j = 0; j < dataGridView1.Rows.Count; j++)
            {
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    if (dataGridView1.Rows[j].Cells[i].Value != null)
                    {
                        if (FOD == FormatOfData.VALUE)
                        {
                            dataGridView1.Rows[j].Cells[i].Value = gridData1.GetCellValue(i,j);

                        }
                        else
                        {
                            dataGridView1.Rows[j].Cells[i].Value = gridData1.GetCellExpression(i,j);
                        }
                    }
                }
            }
        }

        private void btnExpValFormat_Click(object sender, EventArgs e)
        {
            txtbxExpression.Hide();
            btnClearAll.Height = INTERFACEOBJECTSHEIGHT;
            btnAddRowColumn.Height = INTERFACEOBJECTSHEIGHT;
            btnExpValFormat.Height = INTERFACEOBJECTSHEIGHT;
            
            if (FOD == FormatOfData.VALUE)
            {
                btnExpValFormat.Text = "Show value format";
                for (int i = 0; i < gridData1.GetColAmount(); i++)
                {
                    for (int j = 0; j < gridData1.GetRowAmount(); j++)
                    {
                        dataGridView1.Rows[j].Cells[i].Value = gridData1.GetCellExpression(i, j);
                    }
                }
                FOD = FormatOfData.EXPRESSION;
            }
            else
            {
                btnExpValFormat.Text = "Show expression format";
                for (int i = 0; i < gridData1.GetColAmount(); i++)
                {
                    for (int j = 0; j < gridData1.GetRowAmount(); j++)
                    {
                        dataGridView1.Rows[j].Cells[i].Value = gridData1.GetCellValue(i, j);
                    }
                }
                FOD = FormatOfData.VALUE;
            }
        }
        
        private void txtbxExpression_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            txtbxExpression.Hide();
            
            btnClearAll.Height = INTERFACEOBJECTSHEIGHT;
            
            btnAddRowColumn.Height = INTERFACEOBJECTSHEIGHT;
            
            btnExpValFormat.Height = INTERFACEOBJECTSHEIGHT;

            DialogResult dialogResult = MessageBox.Show("Are you sure?", "Delete all data", MessageBoxButtons.YesNo);
            if(dialogResult == DialogResult.Yes)
            {
                for (int i = 0; i < gridData1.GetColAmount(); i++)
                {
                    for (int j = 0; j < gridData1.GetRowAmount(); j++)
                    {
                        gridData1.DeleteCell(i,j);
                        dataGridView1.Rows[j].Cells[i].Value = "";
                    }
                }
            }
            
        }

        public void SaveFile()
        {
            
        }

        public void OpenFile(string path)
        {
            for (int a = 0; a < gridData1.GetColAmount(); a++)
            {
                for (int b = 0; b < gridData1.GetRowAmount(); b++)
                {
                    dataGridView1.Rows[b].Cells[a].Value = "";
                    gridData1.DeleteCell(a,b);
                    
                }
            }
            for (int a = 0; a < gridData1.GetRowAmount(); a++)
            {
                dataGridView1.Columns.Remove(HelpfulFunctions.GetColNameFromIndex(a));
                gridData1.DeleteRow();   
            }
            for (int a = 0; a < gridData1.GetColAmount(); a++)
            {
                dataGridView1.Rows.Remove(dataGridView1.Rows[a]);
                gridData1.DeleteCol();   
            }


            if (!File.Exists(path))
            {
                throw new SystemException("THERE_IS_NO_FILE");
            }

            string fileData;
            fileData = File.ReadAllText(path);
            
            gridData1.AddRow();
            

            int rowIterator = 0;
            int colAmount = 0;
            int rowAmount = 0;
            int colIterator = 0;
            
            StringReader sr = new StringReader(fileData);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    string cellText = "";
                    while (i < line.Length && line[i] != '|')
                    {
                        cellText += line[i];
                        i++;
                    }
                    
                    if (i >= line.Length)
                    {
                        gridData1.AddRow();
                        dataGridView1.Rows.Add(1);
                        rowIterator++;
                        colIterator = 0;
                        break;
                    }
                    gridData1.AddCol();
                    dataGridView1.Columns.Add(HelpfulFunctions.GetColNameFromIndex(colIterator), HelpfulFunctions.GetColNameFromIndex(colIterator));
                    gridData1.ChangeCellExpression(colIterator,rowIterator,cellText);
                    colIterator++;
                }
            }
            dataGridView1.Rows.Add(1);
            
            gridData1.UpdateAllCells();
            for (int j = 0; j < dataGridView1.Rows.Count; j++)
            {
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    if (dataGridView1.Rows[j].Cells[i].Value != null)
                    {
                        if (FOD == FormatOfData.VALUE)
                        {
                            dataGridView1.Rows[j].Cells[i].Value = gridData1.GetCellValue(i,j);

                        }
                        else
                        {
                            dataGridView1.Rows[j].Cells[i].Value = gridData1.GetCellExpression(i,j);
                        }
                    }
                }
            }
        }
    }
}