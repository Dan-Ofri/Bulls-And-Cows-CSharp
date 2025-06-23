using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Ex05
{
    public partial class GameBoardForm : Form
    {
        private const int k_CodeLength = 4;
        private readonly int r_NumOfGuesses;

        private readonly List<List<Button>> r_GuessButtons = new List<List<Button>>();
        private readonly List<Button> r_SubmitButtons = new List<Button>();
        private readonly List<Button> r_FeedbackButtons = new List<Button>();
        private readonly List<Button> r_SecretCodeButtons = new List<Button>();

        private GameSession r_Session;

        public GameBoardForm(int i_NumOfGuesses)
        {
            InitializeComponent();
            r_NumOfGuesses = i_NumOfGuesses;
            r_Session = new GameSession();
            r_Session.InitializeNewGame(r_NumOfGuesses);
            startGame();
        }

        private void startGame()
        {
            buildBoardUI();
        }

        private void buildBoardUI()
        {
            int spacing = 10;
            int buttonSize = 40;
            int startX = 20;
            int startY = 20;

            for (int col = 0; col < k_CodeLength; col++)
            {
                Button secretButton = new Button();
                secretButton.Size = new Size(buttonSize, buttonSize);
                secretButton.Location = new Point(startX + col * (buttonSize + spacing), startY);
                secretButton.BackColor = Color.Black;
                secretButton.Enabled = false;

                this.Controls.Add(secretButton);
                r_SecretCodeButtons.Add(secretButton);
            }

            for (int row = 0; row < r_NumOfGuesses; row++)
            {
                List<Button> guessRow = new List<Button>();
                for (int col = 0; col < k_CodeLength; col++)
                {
                    Button guessButton = new Button();
                    guessButton.Size = new Size(buttonSize, buttonSize);
                    guessButton.Location = new Point(startX + col * (buttonSize + spacing), startY + (row + 1) * (buttonSize + spacing));
                    guessButton.Enabled = row == 0;
                    guessButton.BackColor = Color.LightGray;
                    guessButton.Tag = new Point(row, col);
                    guessButton.Click += colorButton_Click;

                    this.Controls.Add(guessButton);
                    guessRow.Add(guessButton);
                }
                r_GuessButtons.Add(guessRow);

                Button submitButton = new Button();
                submitButton.Size = new Size(40, buttonSize);
                submitButton.Location = new Point(startX + k_CodeLength * (buttonSize + spacing), startY + (row + 1) * (buttonSize + spacing));
                submitButton.Text = "→";
                submitButton.Enabled = false;
                submitButton.Tag = row;
                submitButton.Click += submitButton_Click;

                this.Controls.Add(submitButton);
                r_SubmitButtons.Add(submitButton);

                Button feedbackButton = new Button();
                feedbackButton.Size = new Size(buttonSize, buttonSize);
                feedbackButton.Location = new Point(startX + (k_CodeLength + 1) * (buttonSize + spacing), startY + (row + 1) * (buttonSize + spacing));
                feedbackButton.Enabled = false;

                this.Controls.Add(feedbackButton);
                r_FeedbackButtons.Add(feedbackButton);
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
                    btn.BackColor = colorForm.SelectedColor;
                    btn.Tag = (row, col, colorForm.SelectedEnumColor);

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
                if (btn.BackColor == Color.LightGray)
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
                if (btn.Tag is ValueTuple<int, int, eColor> tag)
                {
                    guess.Add(tag.Item3);
                }
            }

            Feedback feedback = r_Session.SubmitGuess(guess);
            int bulls = feedback.Hits;
            int cows = feedback.Blows;

            r_FeedbackButtons[row].Text = string.Format("{0}B {1}C", bulls, cows);

            foreach (Button btn in r_GuessButtons[row])
            {
                btn.Enabled = false;
            }
            submitBtn.Enabled = false;

            if (r_Session.IsWon)
            {
                MessageBox.Show("You won!");
                revealSecret();
                return;
            }

            if (!r_Session.IsGameOver)
            {
                foreach (Button btn in r_GuessButtons[row + 1])
                {
                    btn.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("You lost!");
                revealSecret();
            }
        }

        private void revealSecret()
        {
            for (int i = 0; i < k_CodeLength; i++)
            {
                r_SecretCodeButtons[i].BackColor = ColorPickerForm.EnumToColorMap[r_Session.SecretCode[i]];
            }
        }
    }
}
