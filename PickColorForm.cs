using System;
using System.Drawing;
using System.Windows.Forms;
using BoolPgia;

namespace WindowsFormsApp1
{
    public partial class PickColorForm : Form
    {
        private Color m_ColorPicked;

        public Color ColorPicked 
        {
            get => m_ColorPicked; set=> m_ColorPicked = value;
        }

        public PickColorForm()
        {
            InitializeComponent();
        }

        private void colorButton_Click(object sender, EventArgs e)
        {
            Button selectedButton = sender as Button;

            ColorPicked = selectedButton.BackColor;
            DialogResult = DialogResult.OK;
            Close();
        }

        internal static Color ConvertEnumToColor(Game.eColor color)
        {
            return Color.FromName(Enum.GetName(typeof(Game.eColor), color));
        }

        private void InitializeComponent()
        {
            int xPosition = 5, yPosition = 5, upOrRightIndicator = 1;

            Text = "Pick A Color:";
            foreach (Game.eColor color in Enum.GetValues(typeof(Game.eColor)))
            {
                Button ColorButton = new Button();

                ColorButton.Size = new Size(50, 50);
                ColorButton.BackColor = ConvertEnumToColor(color);
                ColorButton.Location = new Point(xPosition, yPosition);
                xPosition += upOrRightIndicator % 2 == 0 ? 50 : 0;
                yPosition = upOrRightIndicator % 2 == 0 ? 5 : 65;
                ColorButton.Click += new EventHandler(colorButton_Click);
                Controls.Add(ColorButton);
                upOrRightIndicator++;
            }

            SuspendLayout();
            StartPosition = FormStartPosition.CenterScreen;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new System.Drawing.Size(282, 253);
            ResumeLayout(false);
        }
    }
}
