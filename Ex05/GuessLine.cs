using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Ex05
{
    public partial class GuessLine : UserControl
    {
        private readonly List<Button> m_GuessButtons = new List<Button>();
        private readonly List<Button> m_FeedbackButtons = new List<Button>();
        private readonly Dictionary<Button, eColor> m_ButtonColors = new Dictionary<Button, eColor>();
        private Button m_SubmitButton;

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
            m_GuessButtons.Add(btnGuess1);
            m_GuessButtons.Add(btnGuess2);
            m_GuessButtons.Add(btnGuess3);
            m_GuessButtons.Add(btnGuess4);

            foreach (Button btn in m_GuessButtons)
            {
                btn.BackColor = Color.LightGray;
                btn.Enabled = false;
            }
        }

        private void initializeFeedbackButtons()
        {
            m_FeedbackButtons.Add(buttonFeedback1);
            m_FeedbackButtons.Add(buttonFeedback2);
            m_FeedbackButtons.Add(buttonFeedback3);
            m_FeedbackButtons.Add(buttonFeedback4);
        }

        public void ConfigureGuessButtons(int i_RowIndex, EventHandler i_ClickHandler)
        {
            foreach (Button btn in m_GuessButtons)
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
            foreach (Button btn in m_GuessButtons)
            {
                btn.Enabled = false;
            }

            m_SubmitButton.Enabled = false;
        }

        public void SetButtonColor(Button i_Button, eColor i_Color)
        {
            if (m_GuessButtons.Contains(i_Button))
            {
                m_ButtonColors[i_Button] = i_Color;
            }
        }

        public bool HasDuplicateColors()
        {
            return m_ButtonColors.Values.Count() != m_ButtonColors.Values.Distinct().Count();
        }

        public bool IsRowFilled()
        {
            return m_ButtonColors.Count == m_GuessButtons.Count;
        }

        public List<eColor> GetGuessColors()
        {
            List<eColor> colors = new List<eColor>();

            foreach (Button btn in m_GuessButtons)
            {
                if (m_ButtonColors.TryGetValue(btn, out eColor color))
                {
                    colors.Add(color);
                }
            }

            return colors;
        }

        public void DisplayFeedback(int i_Bulls, int i_Cows)
        {
            int index = 0;

            for (int i = 0; i < i_Bulls && index < m_FeedbackButtons.Count; i++, index++)
            {
                m_FeedbackButtons[index].BackColor = GameSettings.HitColor;
            }

            for (int i = 0; i < i_Cows && index < m_FeedbackButtons.Count; i++, index++)
            {
                m_FeedbackButtons[index].BackColor = GameSettings.BlowColor;
            }
        }
    }
}