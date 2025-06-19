using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex05
{
    public class GameLogic
    {
        private readonly Random r_Random = new Random();

        public List<eColor> GenerateSecretCode()
        {
            List<eColor> colors = GameSettings.AllowedColors.ToList();
            List<eColor> code = new List<eColor>();

            while (code.Count < GameSettings.CodeLength)
            {
                int index = r_Random.Next(colors.Count);
                eColor candidate = colors[index];

                if (!code.Contains(candidate))
                {
                    code.Add(candidate);
                }
            }

            return code;
        }

        public Feedback CalculateFeedback(List<eColor> i_SecretCode, List<eColor> i_Guess)
        {
            int hits = 0;
            int blows = 0;

            for (int i = 0; i < GameSettings.CodeLength; i++)
            {
                if (i_SecretCode[i] == i_Guess[i])
                {
                    hits++;
                }
                else if (i_SecretCode.Contains(i_Guess[i]))
                {
                    blows++;
                }
            }

            return new Feedback(hits, blows);
        }

        public bool IsWinningGuess(Feedback i_Feedback)
        {
            return i_Feedback.Hits == GameSettings.CodeLength;
        }
    }

}
