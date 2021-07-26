using System;
using System.Linq;

namespace Blackjack
{
    public class Score
    {
        public int Calculate(Hand hand)
        {
            var sum = 0;
            for (var i = 0; i < hand.Cards.Count; i++)
            {
                // look at each cards rank as an int
                sum += (int)hand.Cards[i].Rank;
            }

            return sum;
        }
    }
}