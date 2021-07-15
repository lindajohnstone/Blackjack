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
            var numberOfCardsInSuit = controller.Deck.Cards.Count(x => x.Suit == CardSuit.Clubs);
            var numberOfCardsOfRank = controller.Deck.Cards.Count(x => x.Rank == CardRank.Ace);

            Assert.Equal(52, controller.Deck.Cards.Count);
            Assert.Equal(13, numberOfCardsInSuit);
            Assert.Equal(4, numberOfCardsOfRank);
        }

        [Fact]
        public void WhenShuffled_DeckHasSameCards() // TODO: how to call through Controller.Play()
        {
            var deck = new Deck(new List<Card>());
            var controller = new Controller(deck);

            var result = controller.Shuffle();
            var numberOfCardsInSuit = result.Cards.Count(x => x.Suit == CardSuit.Clubs);
            var numberOfCardsOfRank = result.Cards.Count(x => x.Rank == CardRank.Ace);

            Assert.True(BlackjackHelper.DecksOfCardsAreEqual(deck, result));
            Assert.Equal(52, result.Cards.Count);
            Assert.Equal(13, numberOfCardsInSuit);
            Assert.Equal(4, numberOfCardsOfRank);
        }
    }
}