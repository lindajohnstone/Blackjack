using System;

namespace Blackjack
{
    public static class InputParser
    {
        public static void ParseChoice(string v, object input)
        {
            throw new NotImplementedException();
        }

        public static int ParseChoice(string input)
        {
            var number = IsValid(input);
            return number;
        }

        private static int IsValid(string input)
        {
            var isValidNumber = Int32.TryParse(input, out var number);
            // if (number < 0 || number > 1) return ; // what to return if input not valid
            return number;
        }
    }
}