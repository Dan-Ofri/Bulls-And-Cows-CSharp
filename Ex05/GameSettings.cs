using System;
using System.Collections.Generic;
using System.Drawing;


namespace Ex05
{
    public static class GameSettings
    {
        public const int CodeLength = 4;
        public const int MinGuesses = 4;
        public const int MaxGuesses = 10;

        public static readonly eColor[] AllowedColors = (eColor[])Enum.GetValues(typeof(eColor));

        public static readonly Dictionary<eColor, Color> ColorMapping = new Dictionary<eColor, Color>
                                                                            {
                                                                                { eColor.Red, Color.Red },
                                                                                { eColor.Blue, Color.Blue },
                                                                                { eColor.Green, Color.Green },
                                                                                { eColor.Yellow, Color.Yellow },
                                                                                { eColor.Orange, Color.Orange },
                                                                                { eColor.Purple, Color.Purple },
                                                                                { eColor.LightBlue, Color.Brown },
                                                                                { eColor.Pink, Color.White }
                                                                            };

    }
}
