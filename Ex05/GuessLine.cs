using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ex05
{
    public partial class GuessLine : UserControl
    {
        private List<Button> m_GuessButtons = new List<Button>();
        private List<Button> m_FeedbackButtons = new List<Button>();
        private Button m_SubmitButton;
        private Dictionary<Button, eColor> m_ButtonColors = new Dictionary<Button, eColor>();


        public GuessLine()
        {
            InitializeComponent();
            initializeButtonLists();
        }

        private void initializeButtonLists()
        {
            m_GuessButtons.Add(guess1);
            m_GuessButtons.Add(guess2);
            m_GuessButtons.Add(guess3);
            m_GuessButtons.Add(guess4);

            m_FeedbackButtons.Add(feedbackButton1);
            m_FeedbackButtons.Add(feedbackButton2);
            m_FeedbackButtons.Add(feedbackButton3);
            m_FeedbackButtons.Add(feedbackButton4);

            m_SubmitButton = submitButton;

            // Initialize button colors
            foreach (Button btn in m_GuessButtons)
            {
                btn.BackColor = Color.LightGray;
                btn.Enabled = false;
            }

            m_SubmitButton.Enabled = false;
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
                // Update or add the color mapping for this button
                if (m_ButtonColors.ContainsKey(i_Button))
                {
                    m_ButtonColors[i_Button] = i_Color;
                }
                else
                {
                    m_ButtonColors.Add(i_Button, i_Color);
                }
            }
        }

        public eColor? GetColorForButton(Button i_Button)
        {
            if (m_ButtonColors.ContainsKey(i_Button))
            {
                return m_ButtonColors[i_Button];
            }

            return null;
        }

        public bool ContainsColor(eColor i_Color)
        {
            return m_ButtonColors.Values.Contains(i_Color);
        }

        public bool HasDuplicateColors()
        {
            // Check if there are any duplicate colors in the row
            var colorValues = m_ButtonColors.Values.ToList();
            return colorValues.Count != colorValues.Distinct().Count();
        }

        public bool IsRowFilled()
        {
            // All buttons must have a color assigned
            return m_ButtonColors.Count == m_GuessButtons.Count;
        }

        public List<eColor> GetGuessColors()
        {
            List<eColor> colors = new List<eColor>();

            foreach (Button btn in m_GuessButtons)
            {
                if (m_ButtonColors.ContainsKey(btn))
                {
                    colors.Add(m_ButtonColors[btn]);
                }
            }

            return colors;
        }

        public void DisplayFeedback(int i_Bulls, int i_Cows)
        {
            int index = 0;

            // Set black buttons for bulls (direct hits)
            for (int i = 0; i < i_Bulls; i++)
            {
                if (index < m_FeedbackButtons.Count)
                {
                    m_FeedbackButtons[index].BackColor = Color.Black;
                    index++;
                }
            }

            // Set yellow buttons for cows (indirect hits)
            for (int i = 0; i < i_Cows; i++)
            {
                if (index < m_FeedbackButtons.Count)
                {
                    m_FeedbackButtons[index].BackColor = Color.Yellow;
                    index++;
                }
            }
        }
    }
}