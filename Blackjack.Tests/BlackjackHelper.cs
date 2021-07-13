using System;

namespace Blackjack.Tests
{
    public static class BlackjackHelper
    {
        public static bool CardsAreEqual(Card card1, Card card2)
        {
            throw new NotImplementedException();
        }
        
        public static bool RanksAreEqual(CardRank rank1, CardRank rank2)
        {
            if (rank1 !=  rank2) return false;
            return true;
        }

        public static bool SuitsAreEqual(CardSuit suit1, CardSuit suit2)
        {
            if (suit1 != suit2) return false;
            return true;
        }
    }
}