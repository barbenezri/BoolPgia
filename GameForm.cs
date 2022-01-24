using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System;
using BoolPgia;

namespace WindowsFormsApp1
{
    public partial class GameForm : Form
    {
        private Game m_MyGame;
        private int m_PinSizeGap;
        private readonly List<Button> r_AnswerButton = new List<Button>();
        private List<Button> m_GuessButton = new List<Button>();
        private List<Button> m_ArrowButton = new List<Button>();
        private List<Button> m_ResultButton = new List<Button>();

        public Game MyGame
        {
            get => m_MyGame; set => m_MyGame = value;
        }

        public int PinSizeGap
        {
            get => m_PinSizeGap; set => m_PinSizeGap = value;
        }

        public GameForm()
        {
            InitialForm initialForm = new InitialForm();

            initialForm.StartPosition = FormStartPosition.CenterScreen;
            DialogResult = initialForm.ShowDialog();
            if (DialogResult != DialogResult.OK)
            {
                Environment.Exit(0);
            }

            MyGame = new Game(initialForm.DesireGuessAmount);
            PinSizeGap = MyGame.PinSize * 50;
            initializeComponents();
        }

        private void initializeComponents()
        {
            Text = "Bool Pgia";
            StartPosition = FormStartPosition.CenterScreen;
            createAnswerButton();
            for (int i = 0; i < MyGame.DesiredGuesses; i++)
            {
                createGuessButton(i);
                createArrowButton(i);
                createResultButton(i);
            }
            
            AutoSize = true;
        }

        private void createAnswerButton()
        {
            for (int i = 0; i < MyGame.PinSize; i++)
            {
                Button AnswerButton = new Button();

                AnswerButton.BackColor = Color.Black;
                AnswerButton.FlatStyle = FlatStyle.Flat;
                AnswerButton.Location = new Point(20 + (i * 50), 20);
                AnswerButton.Size = new Size(45, 45);
                AnswerButton.Enabled = false;
                Controls.Add(AnswerButton);
                r_AnswerButton.Add(AnswerButton);
            }
        }

        private void createGuessButton(int i_row)
        {
            for (int j = 0; j < MyGame.PinSize; j++)
            {
                Button GuessButton = new Button();

                GuessButton.Location = new Point(20 + (j * 50), 90 + (i_row * 50));
                GuessButton.Size = new Size(45, 45);
                GuessButton.Enabled = i_row == 0;
                m_GuessButton.Add(GuessButton);
                Controls.Add(GuessButton);
                GuessButton.Click += new EventHandler(guessButton_Click);
            }
        }

        private void createArrowButton(int i_row)
        {
            Button arrowButton = new Button();

            arrowButton.Location = new Point(15 + PinSizeGap, 100 + (i_row * 50));
            arrowButton.Size = new Size(40, 20);
            arrowButton.Click += new EventHandler(arrowButton_Click);
            arrowButton.Text = "-->>";
            arrowButton.Enabled = false;
            Controls.Add(arrowButton);
            m_ArrowButton.Add(arrowButton);
        }

        private void createResultButton(int i_row)
        {
            int rowGap = i_row * 50;
            int xPosition = PinSizeGap + 60, yPosition = 112 + rowGap;

            for (int j = 0; j < MyGame.PinSize; j++)
            {
                Button ResultButton = new Button();

                ResultButton.Size = new Size(20, 20);
                xPosition += j % 2 == 0 ? (j * 10) : 0;
                yPosition += j % 2 == 0 ? -20 : 20;
                ResultButton.Location = new Point(xPosition, yPosition);
                ResultButton.Enabled = false;
                Controls.Add(ResultButton);
                m_ResultButton.Add(ResultButton);
            }
        }

        private void guessButton_Click(object sender, EventArgs e)
        {
            string messageHeader = "Used Color";
            string messageContant = "This color already pick, Please try different one";
            PickColorForm pickColorForm = new PickColorForm();
            Button selectedButton = sender as Button;
            Game.eColor currentColor;

            DialogResult = pickColorForm.ShowDialog();
            if (DialogResult == DialogResult.OK)
            {
                currentColor = convertColorToEnum(pickColorForm.ColorPicked);
                if (MyGame.Guess.ContainsValue(currentColor))
                {
                    MessageBox.Show(messageContant, messageHeader, MessageBoxButtons.OK);
                }
                else
                {
                    selectedButton.BackColor = pickColorForm.ColorPicked;
                    setColorToCell(currentColor, selectedButton);
                }
            }
        }

        private void setColorToCell(Game.eColor i_currentColor, Button i_selectedButton)
        {
            int CurrentCellIdx = (i_selectedButton.Location.X - 20) / 50;

            if (MyGame.Guess.ContainsKey(CurrentCellIdx))
            {
                MyGame.Guess.Remove(CurrentCellIdx);
            }

            MyGame.Guess.Add(CurrentCellIdx, i_currentColor);
            m_ArrowButton[MyGame.TurnNumber].Enabled = MyGame.Guess.Count == MyGame.PinSize;
        }

        private Game.eColor convertColorToEnum(Color i_Color)
        {
            return (Game.eColor)Enum.Parse(typeof(Game.eColor), i_Color.Name);
        }

        private void arrowButton_Click(object sender, EventArgs e)
        {
            Button currentArrow = sender as Button;

            currentArrow.Enabled = false;
            changeGuessButtonStatus(MyGame.TurnNumber, false);
            insertGuess();
            MyGame.TurnNumber++;
            if (MyGame.isWin || MyGame.TurnNumber == MyGame.DesiredGuesses)
            {
                revealAnswer();
            }
            else 
            {
                changeGuessButtonStatus(MyGame.TurnNumber, true);
                MyGame.Guess.Clear();
            }
        }

        private void insertGuess()
        {
            List<int> bullsAndCows = Logic.CheckBullsAndCows(MyGame);
            int resultBoxIndex = 0, resultRow = (MyGame.TurnNumber * 4), i;

            for (i = 0; i < bullsAndCows[0]; i++)
            {
                m_ResultButton[resultRow + resultBoxIndex].BackColor = Color.Black;
                resultBoxIndex++;
            }

            for (i = 0; i < bullsAndCows[1]; i++)
            {
                m_ResultButton[resultRow + resultBoxIndex].BackColor = Color.Yellow;
                resultBoxIndex++;
            }

            MyGame.isWin = bullsAndCows[0] == 4;
        }

        private void revealAnswer()
        {
            for (int i = 0; i < MyGame.PinSize; i++)
            {
                Color temp = PickColorForm.ConvertEnumToColor(MyGame.ComputerPins[i]);
                r_AnswerButton[i].BackColor = temp;
            }
        }

        private void changeGuessButtonStatus(int i_turnNumber, bool i_status)
        {
            for (int i = 0; i < MyGame.PinSize; i++)
            {
                m_GuessButton[(i_turnNumber * MyGame.PinSize) + i].Enabled = i_status;
            }
        }
    }
}
