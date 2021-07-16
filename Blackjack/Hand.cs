using System;
using System.Collections.Generic;

namespace Blackjack
{
    public class Hand
    {
        public List<Card> Cards { get; private set; }

        public Hand()
        {
            Cards = new List<Card>();
        }

        public void AddCard(Card card)
        {
            Cards.Add(card);
        }
    }
}