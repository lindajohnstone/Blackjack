using System;

namespace Blackjack
{
    public static class ChoiceParser
    {
        // return enum choice
        // rename to ChoiceParser
        public static Choice ParseChoice(string input)
        { 
            return input == "0" ? Choice.Stay : Choice.Hit;
        }
    }
}