using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Ex05
{
    public partial class GameBoardForm : Form
    {
        private const int k_CodeLength = GameSettings.k_CodeLength;

        private readonly int r_NumOfGuesses;
        private readonly List<GuessLine> r_GuessLines = new List<GuessLine>();
        private readonly List<Button> r_SecretCodeButtons = new List<Button>();

        private int m_CurrentGuessLineIndex;
        private readonly GameSession r_Session;

        public GameBoardForm(int i_NumOfGuesses)
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormClosing += GameBoardForm_FormClosing;

            r_NumOfGuesses = i_NumOfGuesses;
            r_Session = new GameSession();
            r_Session.InitializeNewGame(r_NumOfGuesses);

            cacheSecretCodeButtons();
            startGame();
        }

        private void GameBoardForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void startGame()
        {
            buildBoardUi();
            enableFirstGuessLine();
        }

        private void cacheSecretCodeButtons()
        {
            r_SecretCodeButtons.Add(btnSecretCode1);
            r_SecretCodeButtons.Add(btnSecretCode2);
            r_SecretCodeButtons.Add(btnSecretCode3);
            r_SecretCodeButtons.Add(btnSecretCode4);
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
            guessLine.ConfigureGuessButtons(i_LineIndex, colorButton_Click);
            guessLine.ConfigureSubmitButton(i_LineIndex, submitButton_Click);
        }

        private void buildBoardUi()
        {
            const int k_Spacing = 10;
            const int k_ButtonSize = 40;
            const int k_StartY = 70;
            int startX = btnSecretCode1.Location.X;

            for (int row = 0; row < r_NumOfGuesses; row++)
            {
                GuessLine guessLine = new GuessLine();
                guessLine.Location = new Point(startX, k_StartY + row * (k_ButtonSize + k_Spacing));
                this.Controls.Add(guessLine);
                r_GuessLines.Add(guessLine);
            }

            this.ClientSize = new Size(
                this.ClientSize.Width,
                k_StartY + r_NumOfGuesses * (k_ButtonSize + k_Spacing) + k_Spacing);
        }

        private void colorButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if(btn == null)
            {
                return;
            }

            GuessLine currentGuessLine = r_GuessLines[m_CurrentGuessLineIndex];

            using (ColorPickerForm colorForm = createAndPositionColorPicker(btn))
            {
                if (colorForm.ShowDialog() == DialogResult.OK)
                {
                    eColor selectedColor = colorForm.SelectedEnumColor;

                    btn.BackColor = colorForm.SelectedColor;
                    currentGuessLine.SetButtonColor(btn, selectedColor);

                    updateSubmitButtonState(currentGuessLine);
                }
            }
        }

        private ColorPickerForm createAndPositionColorPicker(Button i_Button)
        {
            ColorPickerForm colorForm = new ColorPickerForm();
            Point buttonScreenPoint = i_Button.PointToScreen(Point.Empty);
            colorForm.StartPosition = FormStartPosition.Manual;
            colorForm.Location = new Point(buttonScreenPoint.X + i_Button.Width + 10, buttonScreenPoint.Y);

            Rectangle screenBounds = Screen.GetWorkingArea(this);
            if (colorForm.Location.X + colorForm.Width > screenBounds.Right)
            {
                colorForm.Location = new Point(buttonScreenPoint.X - colorForm.Width - 10, buttonScreenPoint.Y);
            }

            return colorForm;
        }

        private void updateSubmitButtonState(GuessLine i_CurrentLine)
        {
            if (i_CurrentLine.HasDuplicateColors())
            {
                i_CurrentLine.DisableSubmitButton();
            }
            else if (i_CurrentLine.IsRowFilled())
            {
                i_CurrentLine.EnableSubmitButton();
            }
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null)
            {
                return;
            }

            GuessLine currentGuessLine = r_GuessLines[m_CurrentGuessLineIndex];
            List<eColor> guess = currentGuessLine.GetGuessColors();

            Feedback feedback = r_Session.SubmitGuess(guess);
            currentGuessLine.DisplayFeedback(feedback.Hits, feedback.Blows);
            currentGuessLine.DisableAllButtons();

            if (r_Session.State == eGameState.Won ||
                r_Session.State == eGameState.Lost)
            {
                revealSecret();
            }
            else if (r_Session.State == eGameState.InProgress)
            {
                m_CurrentGuessLineIndex++;
                configureGuessLine(m_CurrentGuessLineIndex);
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