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

        private List<Card> Initialize(List<Card> cards) 
        {
            foreach (CardRank rank in Enum.GetValues(typeof(CardRank)))
            {
                foreach (CardSuit suit in Enum.GetValues(typeof(CardSuit)))
                {
                    cards.Add(new Card(rank, suit));
                }
            }
            
            return cards;
        }
    }
}