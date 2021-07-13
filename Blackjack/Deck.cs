using System;
using System.Collections.Generic;

namespace Blackjack
{
    public class Deck
    {
        public List<Card> Cards { get; private set; }
        public Deck(List<Card> cards)
        {
            Cards = cards;
            Initialize(cards);
        }

        private List<Card> Initialize(List<Card> cards) // TODO: is there a way to set this via a loop?
        {
            foreach (CardRank rank in Enum.GetValues(typeof(CardRank)))
            {
                foreach (CardSuit suit in Enum.GetValues(typeof(CardSuit)))
                {
                    cards.Add(new Card(rank, suit));
                }
            }
            // for (var rank = 0; rank < 13; rank++)
            // {
            //     for (var suit = 0; suit < 4; suit++)
            //     {
            //         cards.Add(new Card((CardRank)rank, (CardSuit) suit));
            //     }
            // }
            return cards;
        }
    }
}