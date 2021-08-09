using System;

namespace Blackjack
{
    public static class Validator
    {
        public static bool IsValid(string input)
        {
            return (input == "0" || input == "1");
        }
    }
}