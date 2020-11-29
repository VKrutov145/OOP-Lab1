using System;
using System.Windows.Forms;

namespace Lab1
{
    public partial class StartMenuForm : Form
    {
        private Form1 gridForm1 = new Form1();
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
            MessageBox.Show("Основний функціонал програми:\n" +
                            "1. Збереження числових данних в форматі таблиці\n" +
                            "2. Можливість виконувати ряд операцій над данними:\n" +
                            "2.1. +, -, *, / (бінарні операції)\n" +
                            "2.2. ^ (піднесення у степінь)\n" +
                            "2.3. іnc, dec\n" +
                            "2.4. mmax(x1,x2,...,xN), mmіn(x1,x2,...,xN)\n" +
                            "3. Можливість перевірити навички програмування в студента групи К-24 Крутова Василя\n");
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}