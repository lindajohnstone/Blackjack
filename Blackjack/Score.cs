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
                var rank = (int)hand.Cards[i].Rank;
                if (rank < 10) sum += rank;
                sum += 10;
                /*
                if rank is less than 10 - add rank to sum
                if rank is greater than 10 - add 10 to sum
                */
            }

            return sum;
        }
    }
}