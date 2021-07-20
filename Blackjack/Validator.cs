using System;

namespace Blackjack
{
    public static class Validator
    {
        // validate input is an integer
        // use string literal ie is it either "0" or "1"
        public static bool IsValid(string input)
        {
            return (input == "0" || input == "1");
        }
    }
}