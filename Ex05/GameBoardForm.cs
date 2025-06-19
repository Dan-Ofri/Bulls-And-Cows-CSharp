using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Ex05
{
    public partial class GameBoardForm : Form
    {
        private readonly int r_NumOfGuesses;
        private GameSession m_GameSession;
        private readonly List<Button[]> r_GuessButtons = new List<Button[]>();
        private readonly List<Button> r_SubmitButtons = new List<Button>();

        public GameBoardForm(int i_NumOfGuesses)
        {
            InitializeComponent();
            r_NumOfGuesses = i_NumOfGuesses;
            this.Text = "Bulls and Cows";
            this.Size = new Size(500, 600);
            startGame();
        }

        private void startGame()
        {
            m_GameSession = new GameSession();
            m_GameSession.InitializeNewGame(r_NumOfGuesses);
            buildBoardUI();
        }

        private void buildBoardUI()
        {
            int verticalSpacing = 50;

            for (int i = 0; i < r_NumOfGuesses; i++)
            {
                Button[] guessRow = new Button[GameSettings.CodeLength];

                for (int j = 0; j < GameSettings.CodeLength; j++)
                {
                    Button colorButton = new Button()
                    {
                        BackColor = Color.LightGray,
                        Enabled = i == 0,
                        Location = new Point(20 + j * 45, 20 + i * verticalSpacing),
                        Size = new Size(40, 40),
                        Tag = new Point(i, j)
                    };

                    colorButton.Click += colorButton_Click;
                    this.Controls.Add(colorButton);
                    guessRow[j] = colorButton;
                }

                Button submitButton = new Button()
                {
                    Text = "→",
                    Location = new Point(220, 20 + i * verticalSpacing),
                    Size = new Size(40, 40),
                    Enabled = false,
                    Tag = i
                };
                submitButton.Click += submitButton_Click;
                this.Controls.Add(submitButton);

                r_GuessButtons.Add(guessRow);
                r_SubmitButtons.Add(submitButton);
            }
        }

        private void colorButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Point position = (Point)btn.Tag;
            int row = position.X;
            int col = position.Y;

            using (ColorPickerForm colorForm = new ColorPickerForm())
            {
                if (colorForm.ShowDialog() == DialogResult.OK)
                {
                    Color chosenColor = colorForm.SelectedColor;
                    btn.BackColor = colorForm.SelectedColor;

                    btn.Tag = (row, col, chosenColor);

                    if (isRowFilled(row))
                    {
                        r_SubmitButtons[row].Enabled = true;
                    }
                }
            }
        }

        private bool isRowFilled(int i_Row)
        {
            foreach (Button btn in r_GuessButtons[i_Row])
            {
                if (!(btn.Tag is ValueTuple<int, int, eColor>))
                {
                    return false;
                }
            }
            return true;
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            Button submitBtn = sender as Button;
            int row = (int)submitBtn.Tag;

            List<eColor> guess = new List<eColor>();
            foreach (Button btn in r_GuessButtons[row])
            {
                var tag = (ValueTuple<int, int, eColor>)btn.Tag;
                guess.Add(tag.Item3);
                btn.Enabled = false;
            }

            submitBtn.Enabled = false;
            Feedback feedback = m_GameSession.SubmitGuess(guess);

            if (m_GameSession.IsWon)
            {
                MessageBox.Show($"You won in {m_GameSession.CurrentGuessNumber} guesses!", "Victory");
                disableAll();
            }
            else if (m_GameSession.IsGameOver)
            {
                MessageBox.Show("No more guesses. You lost.", "Game Over");
                disableAll();
            }
            else
            {
                enableNextRow(row + 1);
            }
        }

        private void enableNextRow(int i_Row)
        {
            foreach (Button btn in r_GuessButtons[i_Row])
            {
                btn.Enabled = true;
            }
        }

        private void disableAll()
        {
            foreach (Button[] row in r_GuessButtons)
            {
                foreach (Button btn in row)
                {
                    btn.Enabled = false;
                }
            }

            foreach (Button btn in r_SubmitButtons)
            {
                btn.Enabled = false;
            }
        }
    }
}
