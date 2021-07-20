using System;

namespace Blackjack
{
    public static class Validator
    {
        // validate input is an integer
        // specifically 0 or 1
        public static bool IsValid(string input)
        {
            try
            {
                var number = Int32.Parse(input);
                return (number == 0 || number == 1);
            }
            catch (FormatException e) // TODO: is there is a better way to do this
            {
                return false;
            }
        }
    }
}