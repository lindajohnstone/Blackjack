using System;

namespace Blackjack
{
    public static class InputParser
    {
        public static int ParseChoice(string input)
        {
            return Int32.Parse(input);
        }
    }
}