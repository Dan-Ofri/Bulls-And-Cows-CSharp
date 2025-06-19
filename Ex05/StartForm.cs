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
    public partial class StartForm : Form
    {
        private int m_NumOfGuesses = 4;
        public StartForm()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            GameBoardForm mainForm = new GameBoardForm(m_NumOfGuesses);
            mainForm.Show();
            this.Hide();
        }

        private void btnCounter_Click(object sender, EventArgs e)
        {
            m_NumOfGuesses++;
            if (m_NumOfGuesses > 10)
            {
                m_NumOfGuesses = 4;
            }

            btnCounter.Text = $"Number of guesses: {m_NumOfGuesses}";
        }
    }
}
