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

        private readonly List<GuessLine> r_GuessLines = new List<GuessLine>();
        private readonly List<Button> r_SecretCodeButtons = new List<Button>();
        private int m_CurrentGuessLineIndex = 0;

        private GameSession r_Session;

        public GameBoardForm(int i_NumOfGuesses)
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;

            r_NumOfGuesses = i_NumOfGuesses;
            r_Session = new GameSession();
            r_Session.InitializeNewGame(r_NumOfGuesses);

            // Store secret code buttons in a list for easier access
            r_SecretCodeButtons.Add(secretButton1);
            r_SecretCodeButtons.Add(secretButton2);
            r_SecretCodeButtons.Add(secretButton3);
            r_SecretCodeButtons.Add(secretButton4);

            startGame();
        }

        private void startGame()
        {
            buildBoardUi();
            enableFirstGuessLine();
        }

        private void enableFirstGuessLine()
        {
            if (r_GuessLines.Count > 0)
            {
                m_CurrentGuessLineIndex = 0;
                configureGuessLine(m_CurrentGuessLineIndex);
            }
        }

        private void configureGuessLine(int i_LineIndex)
        {
            if (i_LineIndex < 0 || i_LineIndex >= r_GuessLines.Count)
            {
                return;
            }

            GuessLine guessLine = r_GuessLines[i_LineIndex];

            // Configure guess buttons to be clickable
            guessLine.ConfigureGuessButtons(i_LineIndex, colorButton_Click);

            // Configure submit button
            guessLine.ConfigureSubmitButton(i_LineIndex, submitButton_Click);
        }

        private void buildBoardUi()
        {
            const int k_Spacing = 10;
            const int k_ButtonSize = 40;
            const int k_StartY = 70; // Start below the secret code buttons

            int startX = secretButton1.Location.X;

            for (int row = 0; row < r_NumOfGuesses; row++)
            {
                GuessLine guessLine = new GuessLine();
                guessLine.Location = new Point(startX, k_StartY + row * (k_ButtonSize + k_Spacing));
                this.Controls.Add(guessLine);
                r_GuessLines.Add(guessLine);
            }

            // Adjust form size based on number of rows
            this.ClientSize = new Size(
                this.ClientSize.Width,
                k_StartY + r_NumOfGuesses * (k_ButtonSize + k_Spacing) + k_Spacing);
        }

        private void colorButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null) return;

            GuessLine currentGuessLine = r_GuessLines[m_CurrentGuessLineIndex];

            using (ColorPickerForm colorForm = new ColorPickerForm())
            {
                // Position the color picker form relative to the clicked button
                Point buttonScreenPoint = btn.PointToScreen(new Point(0, 0));
                colorForm.StartPosition = FormStartPosition.Manual;
                colorForm.Location = new Point(buttonScreenPoint.X + btn.Width + 10, buttonScreenPoint.Y);

                // Make sure the form is visible on screen
                Rectangle screenBounds = Screen.GetWorkingArea(this);
                if (colorForm.Location.X + colorForm.Width > screenBounds.Right)
                {
                    colorForm.Location = new Point(buttonScreenPoint.X - colorForm.Width - 10, buttonScreenPoint.Y);
                }

                if (colorForm.ShowDialog() == DialogResult.OK)
                {
                    eColor selectedColor = colorForm.SelectedEnumColor;

                    // Store the original color to be able to restore it if needed
                    eColor? originalColor = null;
                    if (btn.BackColor != Color.LightGray)
                    {
                        originalColor = currentGuessLine.GetColorForButton(btn);
                    }

                    // Set the new color
                    btn.BackColor = colorForm.SelectedColor;
                    currentGuessLine.SetButtonColor(btn, selectedColor);

                    // Check if the row has any duplicates after this selection
                    if (currentGuessLine.HasDuplicateColors())
                    {
                        // Disable submit button if there are duplicates
                        currentGuessLine.DisableSubmitButton();
                    }
                    else if (currentGuessLine.IsRowFilled())
                    {
                        // Enable submit button only if row is filled and has no duplicates
                        currentGuessLine.EnableSubmitButton();
                    }
                }
            }
        }


        private void submitButton_Click(object sender, EventArgs e)
        {
            Button submitBtn = sender as Button;
            if (submitBtn == null) return;

            GuessLine currentGuessLine = r_GuessLines[m_CurrentGuessLineIndex];
            List<eColor> guess = currentGuessLine.GetGuessColors();

            Feedback feedback = r_Session.SubmitGuess(guess);
            int bulls = feedback.Hits;
            int cows = feedback.Blows;

            currentGuessLine.DisplayFeedback(bulls, cows);
            currentGuessLine.DisableAllButtons();

            if (r_Session.IsWon)
            {
                revealSecret();
                return;
            }

            if (!r_Session.IsGameOver)
            {
                m_CurrentGuessLineIndex++;
                configureGuessLine(m_CurrentGuessLineIndex);
            }
            else
            {
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
