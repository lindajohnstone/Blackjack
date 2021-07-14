using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Blackjack.Tests
{
    public class ControllerShould
    {
        [Fact]
        public void WhenInitialized_ReturnsADeck()
        {
            var deck = new Deck(new List<Card>());
            var controller = new Controller(deck);

            var numberOfCardsInSuit = deck.Cards.Count(x => x.Suit == CardSuit.Clubs);
            var numberOfCardsOfRank = deck.Cards.Count(x => x.Rank == CardRank.Ace);

            Assert.Equal(52, deck.Cards.Count);
            Assert.Equal(13, numberOfCardsInSuit);
            Assert.Equal(4, numberOfCardsOfRank);
        }
    }
}