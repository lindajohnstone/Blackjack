using System;

namespace Blackjack.Tests
{
    public static class BlackjackHelper
    {
        public static bool CardsAreEqual(Card card1, Card card2)
        {
            if (card1 == null || card2 == null) return false;
            var isRankSame = RanksAreEqual(card1.Rank, card2.Rank);
            var isSuitSame = SuitsAreEqual(card1.Suit, card2.Suit);
            return isRankSame && isSuitSame;
        }
        
        private static bool RanksAreEqual(CardRank rank1, CardRank rank2)
        {
            if (rank1 !=  rank2) return false;
            return true;
        }

        private static bool SuitsAreEqual(CardSuit suit1, CardSuit suit2)
        {
            if (suit1 != suit2) return false;
            return true;
        }
    }
}