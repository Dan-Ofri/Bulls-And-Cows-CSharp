using System;

namespace Ex05
{
    public static class GameSettings
    {
        public const int CodeLength = 4;
        public const int MinGuesses = 4;
        public const int MaxGuesses = 10;

        public static readonly eColor[] AllowedColors = (eColor[])Enum.GetValues(typeof(eColor));

    }
}
