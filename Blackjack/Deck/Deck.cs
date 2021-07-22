using System;
using System.Collections.Generic;

namespace Blackjack
{
    public class Deck : IDeck
    {
        public List<Card> Cards { get; private set; }
        public Deck()
        {
            Initialize();
        }

        private void Initialize()
        {
            Cards = new List<Card>();
            foreach (CardRank rank in Enum.GetValues(typeof(CardRank)))
            {
                foreach (CardSuit suit in Enum.GetValues(typeof(CardSuit)))
                {
                    Cards.Add(new Card(rank, suit));
                }
            }
        }

        public void Shuffle()
        {
            // based on Fisher-Yates Shuffle algorithm
            var count = Cards.Count;
            Random rand = new Random();

            for (int i = count - 1; i > 0; i--)
            {
                int j = rand.Next(0, i + 1);

                var temp = Cards[i];
                Cards[i] = Cards[j];
                Cards[j] = temp;
            }
        }
    }
}