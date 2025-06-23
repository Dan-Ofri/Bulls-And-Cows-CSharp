using System.Collections.Generic;

namespace Ex05
{
    public class GameSession
    {
        public Board Board { get; private set; }
        public List<eColor> SecretCode { get; private set; }
        public int CurrentGuessNumber { get; private set; } = 0;
        public bool IsGameOver => CurrentGuessNumber >= Board.MaxGuesses;
        public bool IsWon { get; private set; } = false;

        private GameLogic r_Logic;

        public void InitializeNewGame(int i_MaxGuesses)
        {
            r_Logic = new GameLogic();
            Board = new Board(i_MaxGuesses);
            SecretCode = r_Logic.GenerateSecretCode();
            Board.SetSecretCode(SecretCode);
            CurrentGuessNumber = 0;
            IsWon = false;
        }

        public Feedback SubmitGuess(List<eColor> i_Guess)
        {
            Feedback feedback = r_Logic.CalculateFeedback(SecretCode, i_Guess);
            Board.AddGuess(i_Guess, feedback);
            CurrentGuessNumber++;
            IsWon = r_Logic.IsWinningGuess(feedback);
            return feedback;
        }
    }
}