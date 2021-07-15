using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Blackjack.Tests
{
    public class DeckShould
    {
        [Fact]
        public void BeInitialized()
        {
            var cards = new List<Card>();
            var deck = new Deck(cards);
            var numberOfCardsInSuit = deck.Cards.Count(x => x.Suit == CardSuit.Clubs);
            var numberOfCardsOfRank = deck.Cards.Count(x => x.Rank == CardRank.Ace);

            Assert.Equal(52, deck.Cards.Count);
            Assert.Equal(13, numberOfCardsInSuit);
            Assert.Equal(4, numberOfCardsOfRank);
        }
    }
}