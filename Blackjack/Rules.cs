using System;

namespace Blackjack
{
    public class Rules
    {
        // Blackjack if score == 21
        // Bust if score > 21
        public bool IsBust(int score)
        {
            return score > 21 ? true : false;
        }
    }
}