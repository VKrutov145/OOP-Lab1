using System;
using System.Windows.Forms;

namespace Lab1
{
    public partial class StartMenuForm : Form
    {
        Form1 gridForm1 = new Form1();
        public StartMenuForm()
        {
            InitializeComponent();
        }

        private void btnCreateGrid_Click(object sender, EventArgs e)
        {
            gridForm1.ShowDialog();
            btnCreateGrid.Text = "Відкрити таблицю";
        }

        private void btnAboutProgramme_Click(object sender, EventArgs e)
        {
            
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            
        }
    }
}