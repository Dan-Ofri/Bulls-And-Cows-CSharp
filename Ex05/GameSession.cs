using System.Collections.Generic;

namespace Ex05
{
    public class GameSession
    {
        private Board Board { get; set; }

        public List<eColor> SecretCode { get; private set; }
        private int CurrentGuessNumber { get; set; }

        public eGameState State { get; private set; } = eGameState.InProgress;

        private GameLogic m_Logic;

        public void InitializeNewGame(int i_MaxGuesses)
        {
            m_Logic = new GameLogic();
            Board = new Board(i_MaxGuesses);
            SecretCode = m_Logic.GenerateSecretCode();
            Board.SetSecretCode(SecretCode);
            CurrentGuessNumber = 0;
            State = eGameState.InProgress;
        }

        public Feedback SubmitGuess(List<eColor> i_Guess)
        {
            Feedback feedback = m_Logic.CalculateFeedback(SecretCode, i_Guess);
            Board.AddGuess(i_Guess, feedback);
            CurrentGuessNumber++;
            updateGameState(feedback);
            return feedback;
        }

        private void updateGameState(Feedback i_Feedback)
        {
            if (m_Logic.IsWinningGuess(i_Feedback))
            {
                State = eGameState.Won;
            }
            else if (CurrentGuessNumber >= Board.MaxGuesses)
            {
                State = eGameState.Lost;
            }
        }
    }
}