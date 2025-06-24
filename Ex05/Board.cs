using System.Collections.Generic;

namespace Ex05
{
    public class Board
    {
        public int MaxGuesses { get; }
        public List<List<eColor>> Guesses { get; } = new List<List<eColor>>();
        public List<Feedback> Feedbacks { get; } = new List<Feedback>();
        public List<eColor> SecretCode { get; private set; }

        public Board(int i_MaxGuesses)
        {
            MaxGuesses = i_MaxGuesses;
        }

        public void SetSecretCode(List<eColor> i_SecretCode)
        {
            SecretCode = i_SecretCode;
        }

        public void AddGuess(List<eColor> i_Guess, Feedback i_Feedback)
        {
            Guesses.Add(i_Guess);
            Feedbacks.Add(i_Feedback);
        }
    }
}