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
                if (rank > 10) sum += 10;
                if (rank > 1 && rank <= 10) sum += rank;
                if (rank == 1 && sum > 10) sum += 1;
                if (rank == 1 && sum < 11) sum += 11;
            }

            return sum;
        }
    }
}