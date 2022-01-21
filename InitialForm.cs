using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class InitialForm : Form
    {
        private int m_DesireGuessAmount = 4;
        public int DesireGuessAmount { get => m_DesireGuessAmount; set => m_DesireGuessAmount = value; }
        public InitialForm()
        {
            InitializeComponent();
        }


        private void ChancesAmount_btn_Click(object sender, EventArgs e)
        {
            m_DesireGuessAmount = m_DesireGuessAmount == 10 ? 4 : m_DesireGuessAmount + 1;
            ChancesAmount_btn.Text = $"Number of chances: {m_DesireGuessAmount}";
        }

        private void Start_btn_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
