using System.Drawing;

namespace Ex05
{
    public static class GameSettings
    {
        public const int CodeLength = 4;
        public const int MinGuesses = 4;
        public const int MaxGuesses = 10;
        public const int NumAvailableColors = 8;

        public static readonly Color HitColor = Color.Black;  
        public static readonly Color BlowColor = Color.Yellow; 
    }
}