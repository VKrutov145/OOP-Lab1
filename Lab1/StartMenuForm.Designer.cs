using System.ComponentModel;

namespace Lab1
{
    partial class StartMenuForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.btnCreateGrid = new System.Windows.Forms.Button();
            this.btnAboutProgramme = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCreateGrid
            // 
            this.btnCreateGrid.Location = new System.Drawing.Point(256, 83);
            this.btnCreateGrid.Name = "btnCreateGrid";
            this.btnCreateGrid.Size = new System.Drawing.Size(272, 57);
            this.btnCreateGrid.TabIndex = 0;
            this.btnCreateGrid.Text = "Створити таблицю";
            this.btnCreateGrid.UseVisualStyleBackColor = true;
            this.btnCreateGrid.Click += new System.EventHandler(this.btnCreateGrid_Click);
            // 
            // btnAboutProgramme
            // 
            this.btnAboutProgramme.Location = new System.Drawing.Point(256, 189);
            this.btnAboutProgramme.Name = "btnAboutProgramme";
            this.btnAboutProgramme.Size = new System.Drawing.Size(272, 57);
            this.btnAboutProgramme.TabIndex = 1;
            this.btnAboutProgramme.Text = "Про програму";
            this.btnAboutProgramme.UseVisualStyleBackColor = true;
            this.btnAboutProgramme.Click += new System.EventHandler(this.btnAboutProgramme_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(333, 294);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(125, 27);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Закрити програму";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // StartMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnAboutProgramme);
            this.Controls.Add(this.btnCreateGrid);
            this.Name = "StartMenuForm";
            this.Text = "StartMenuForm";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button btnExit;

        private System.Windows.Forms.Button btnAboutProgramme;
        private System.Windows.Forms.Button btnCreateGrid;

        #endregion
    }
}