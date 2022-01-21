using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
///using BoolPgia;

namespace WindowsFormsApp1
{
    public partial class GameForm : Form
    {
        public GameForm()
        {
            InitialForm initialForm = new InitialForm();
            DialogResult = initialForm.ShowDialog();

            if (DialogResult == DialogResult.Cancel)
            {
                Environment.Exit(0);
            }


            InitializeComponent();
        }
    }
}
