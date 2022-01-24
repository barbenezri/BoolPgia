using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class InitialForm : Form
    {
        private int m_DesireGuessAmount = 4;

        public int DesireGuessAmount 
        {
            get => m_DesireGuessAmount; set => m_DesireGuessAmount = value;
        }
        
        public InitialForm()
        {
            InitializeComponent();
        }

        private void ChangesGuessAmount_Click(object sender, EventArgs e)
        {
            DesireGuessAmount = DesireGuessAmount == 10 ? 4 : DesireGuessAmount + 1;
            ChancesAmount.Text = $"Number of chances: {DesireGuessAmount}";
        }

        private void Start_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
