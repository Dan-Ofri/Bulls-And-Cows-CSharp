using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Ex05
{
    public partial class GuessLine : UserControl
    {
        private readonly List<Button> r_GuessButtons = new List<Button>();
        private readonly List<Button> r_FeedbackButtons = new List<Button>();
        private readonly Dictionary<Button, eColor> r_ButtonColors = new Dictionary<Button, eColor>();
        private Button m_SubmitButton;
        private static readonly Color sr_HitColor = Color.Black;
        private static readonly Color sr_BlowColor = Color.Yellow;

        public GuessLine()
        {
            InitializeComponent();
            initializeButtonLists();
        }

        private void initializeButtonLists()
        {
            initializeGuessButtons();
            initializeFeedbackButtons();

            m_SubmitButton = buttonSubmit;
            m_SubmitButton.Enabled = false;
        }

        private void initializeGuessButtons()
        {
            r_GuessButtons.Add(btnGuess1);
            r_GuessButtons.Add(btnGuess2);
            r_GuessButtons.Add(btnGuess3);
            r_GuessButtons.Add(btnGuess4);

            foreach (Button btn in r_GuessButtons)
            {
                btn.BackColor = Color.LightGray;
                btn.Enabled = false;
            }
        }

        private void initializeFeedbackButtons()
        {
            r_FeedbackButtons.Add(buttonFeedback1);
            r_FeedbackButtons.Add(buttonFeedback2);
            r_FeedbackButtons.Add(buttonFeedback3);
            r_FeedbackButtons.Add(buttonFeedback4);
        }

        public void ConfigureGuessButtons(int i_RowIndex, EventHandler i_ClickHandler)
        {
            foreach (Button btn in r_GuessButtons)
            {
                btn.Enabled = true;
                btn.Click += i_ClickHandler;
            }
        }

        public void ConfigureSubmitButton(int i_RowIndex, EventHandler i_ClickHandler)
        {
            m_SubmitButton.Click += i_ClickHandler;
        }

        public void EnableSubmitButton()
        {
            m_SubmitButton.Enabled = true;
        }

        public void DisableSubmitButton()
        {
            m_SubmitButton.Enabled = false;
        }

        public void DisableAllButtons()
        {
            foreach (Button btn in r_GuessButtons)
            {
                btn.Enabled = false;
            }

            m_SubmitButton.Enabled = false;
        }

        public void SetButtonColor(Button i_Button, eColor i_Color)
        {
            if (r_GuessButtons.Contains(i_Button))
            {
                r_ButtonColors[i_Button] = i_Color;
            }
        }

        public bool HasDuplicateColors()
        {
            return r_ButtonColors.Values.Count() != r_ButtonColors.Values.Distinct().Count();
        }

        public bool IsRowFilled()
        {
            return r_ButtonColors.Count == r_GuessButtons.Count;
        }

        public List<eColor> GetGuessColors()
        {
            List<eColor> colors = new List<eColor>();

            foreach (Button btn in r_GuessButtons)
            {
                if (r_ButtonColors.TryGetValue(btn, out eColor color))
                {
                    colors.Add(color);
                }
            }

            return colors;
        }

        public void DisplayFeedback(int i_Bulls, int i_Cows)
        {
            int index = 0;

            for (int i = 0; i < i_Bulls && index < r_FeedbackButtons.Count; i++, index++)
            {
                r_FeedbackButtons[index].BackColor = sr_HitColor;
            }

            for (int i = 0; i < i_Cows && index < r_FeedbackButtons.Count; i++, index++)
            {
                r_FeedbackButtons[index].BackColor = sr_BlowColor;
            }
        }
    }
}