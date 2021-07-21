using System;
using System.Collections.Generic;
using System.Linq;

namespace Blackjack.Tests
{
    public static class BlackjackHelper
    {
        public static bool DecksOfCardsAreEqual(Deck deck1, Deck deck2)
        {
            if (deck1 == null || deck2 == null) return false;
            return ListsOfCardsAreEqual(deck1.Cards, deck2.Cards);
        }        
        
        private static bool ListsOfCardsAreEqual(List<Card> cards1, List<Card> cards2)
        {
            if (cards1 == null || cards2 == null) return false;
            if (cards1.Count != cards2.Count)
            {
                return false;
            }
            var cards1Ordered = cards1.OrderBy(c => c.Rank).ThenBy(c => c.Suit).ToList();
            var cards2Ordered = cards2.OrderBy(c => c.Rank).ThenBy(c => c.Suit).ToList();

            for (var i = 0; i < cards1.Count; i++)
            {
                if (!CardsAreEqual(cards1Ordered[i], cards2Ordered[i]))
                {
                    return false;
                }
            }
            return true;
        }

        private static bool CardsAreEqual(Card card1, Card card2)
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