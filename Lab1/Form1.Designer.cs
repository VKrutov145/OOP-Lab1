namespace Lab1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnBackToStartMenu = new System.Windows.Forms.Button();
            this.btnAddRowColumn = new System.Windows.Forms.Button();
            this.rbtnAddRowColumn = new System.Windows.Forms.RadioButton();
            this.rbtnDeleteRowColumn = new System.Windows.Forms.RadioButton();
            this.txtbxNRowsColumns = new System.Windows.Forms.TextBox();
            this.lblNumberOfAddedDeletedRowsColumns = new System.Windows.Forms.Label();
            this.btnNRows = new System.Windows.Forms.Button();
            this.btnNColumns = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize) (this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(1, 60);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(798, 390);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnBackToStartMenu
            // 
            this.btnBackToStartMenu.Location = new System.Drawing.Point(1, 4);
            this.btnBackToStartMenu.Name = "btnBackToStartMenu";
            this.btnBackToStartMenu.Size = new System.Drawing.Size(49, 50);
            this.btnBackToStartMenu.TabIndex = 1;
            this.btnBackToStartMenu.Text = "Back";
            this.btnBackToStartMenu.UseVisualStyleBackColor = true;
            this.btnBackToStartMenu.Click += new System.EventHandler(this.btnBackToStartMenu_Click);
            // 
            // btnAddRowColumn
            // 
            this.btnAddRowColumn.Location = new System.Drawing.Point(62, 4);
            this.btnAddRowColumn.Name = "btnAddRowColumn";
            this.btnAddRowColumn.Size = new System.Drawing.Size(160, 50);
            this.btnAddRowColumn.TabIndex = 2;
            this.btnAddRowColumn.Text = "Додати стовпці/рядки";
            this.btnAddRowColumn.UseVisualStyleBackColor = true;
            this.btnAddRowColumn.Click += new System.EventHandler(this.buttonAddRowColumn_Click);
            // 
            // rbtnAddRowColumn
            // 
            this.rbtnAddRowColumn.Location = new System.Drawing.Point(62, 8);
            this.rbtnAddRowColumn.Name = "rbtnAddRowColumn";
            this.rbtnAddRowColumn.Size = new System.Drawing.Size(29, 22);
            this.rbtnAddRowColumn.TabIndex = 3;
            this.rbtnAddRowColumn.TabStop = true;
            this.rbtnAddRowColumn.Text = "+";
            this.rbtnAddRowColumn.UseVisualStyleBackColor = true;
            // 
            // rbtnDeleteRowColumn
            // 
            this.rbtnDeleteRowColumn.Location = new System.Drawing.Point(62, 32);
            this.rbtnDeleteRowColumn.Name = "rbtnDeleteRowColumn";
            this.rbtnDeleteRowColumn.Size = new System.Drawing.Size(37, 22);
            this.rbtnDeleteRowColumn.TabIndex = 4;
            this.rbtnDeleteRowColumn.TabStop = true;
            this.rbtnDeleteRowColumn.Text = "—";
            this.rbtnDeleteRowColumn.UseVisualStyleBackColor = true;
            // 
            // txtbxNRowsColumns
            // 
            this.txtbxNRowsColumns.Location = new System.Drawing.Point(127, 32);
            this.txtbxNRowsColumns.Name = "txtbxNRowsColumns";
            this.txtbxNRowsColumns.Size = new System.Drawing.Size(95, 20);
            this.txtbxNRowsColumns.TabIndex = 5;
            this.txtbxNRowsColumns.Text = "0";
            // 
            // lblNumberOfAddedDeletedRowsColumns
            // 
            this.lblNumberOfAddedDeletedRowsColumns.Location = new System.Drawing.Point(102, 32);
            this.lblNumberOfAddedDeletedRowsColumns.Name = "lblNumberOfAddedDeletedRowsColumns";
            this.lblNumberOfAddedDeletedRowsColumns.Size = new System.Drawing.Size(19, 19);
            this.lblNumberOfAddedDeletedRowsColumns.TabIndex = 6;
            this.lblNumberOfAddedDeletedRowsColumns.Text = "N:";
            this.lblNumberOfAddedDeletedRowsColumns.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnNRows
            // 
            this.btnNRows.Location = new System.Drawing.Point(97, 8);
            this.btnNRows.Name = "btnNRows";
            this.btnNRows.Size = new System.Drawing.Size(52, 22);
            this.btnNRows.TabIndex = 7;
            this.btnNRows.Text = "N rows";
            this.btnNRows.UseVisualStyleBackColor = true;
            this.btnNRows.Click += new System.EventHandler(this.btnNRows_Click);
            // 
            // btnNColumns
            // 
            this.btnNColumns.Location = new System.Drawing.Point(155, 8);
            this.btnNColumns.Name = "btnNColumns";
            this.btnNColumns.Size = new System.Drawing.Size(67, 22);
            this.btnNColumns.TabIndex = 8;
            this.btnNColumns.Text = "N columns";
            this.btnNColumns.UseVisualStyleBackColor = true;
            this.btnNColumns.Click += new System.EventHandler(this.btnNColumns_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnNColumns);
            this.Controls.Add(this.btnNRows);
            this.Controls.Add(this.lblNumberOfAddedDeletedRowsColumns);
            this.Controls.Add(this.txtbxNRowsColumns);
            this.Controls.Add(this.rbtnDeleteRowColumn);
            this.Controls.Add(this.rbtnAddRowColumn);
            this.Controls.Add(this.btnAddRowColumn);
            this.Controls.Add(this.btnBackToStartMenu);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize) (this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button btnNColumns;
        private System.Windows.Forms.Button btnNRows;
        private System.Windows.Forms.TextBox txtbxNRowsColumns;

        private System.Windows.Forms.Label lblNumberOfAddedDeletedRowsColumns;

        private System.Windows.Forms.RadioButton rbtnAddRowColumn;
        private System.Windows.Forms.RadioButton rbtnDeleteRowColumn;

        private System.Windows.Forms.Button btnAddRowColumn;

        private System.Windows.Forms.Button btnBackToStartMenu;

        private System.Windows.Forms.DataGridView dataGridView1;

        #endregion
    }
}