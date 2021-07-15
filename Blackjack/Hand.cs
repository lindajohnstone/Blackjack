using System;
using System.Collections.Generic;

namespace Blackjack
{
    public class Hand
    {
        public List<Card> Cards { get; private set; }

        public Hand(List<Card> cards)
        {
            Cards = cards;
            Initialize(cards);
        }

        private void Initialize(List<Card> cards)
        {
            cards = new List<Card>();
        }
    }
}