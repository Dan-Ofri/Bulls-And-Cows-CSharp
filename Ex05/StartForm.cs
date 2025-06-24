using System;
using System.Windows.Forms;

namespace Ex05
{
    public partial class StartForm : Form
    {
        private int m_NumOfGuesses = GameSettings.MinGuesses;

        public StartForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormClosing += StartForm_FormClosing;
        }

        private void StartForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            GameBoardForm mainForm = new GameBoardForm(m_NumOfGuesses);
            mainForm.StartPosition = FormStartPosition.CenterScreen;
            mainForm.FormClosed += MainForm_FormClosed;

            mainForm.Show();
            this.Hide();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnCounter_Click(object sender, EventArgs e)
        {
            m_NumOfGuesses++;

            if (m_NumOfGuesses > GameSettings.MaxGuesses)
            {
                m_NumOfGuesses = GameSettings.MinGuesses;
            }

            btnCounter.Text = $"Number of guesses: {m_NumOfGuesses}";
        }
    }
}