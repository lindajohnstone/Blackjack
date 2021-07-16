using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using Xunit;

namespace Blackjack.Tests
{
    public class ControllerShould
    {
        [Fact]
        public void HasFullDeck_WhenInitialized()
        {
            var controller = new Controller();
            var cards = controller.Deck.Cards;
            var numberOfCardsInSuit = cards.Count(x => x.Suit == CardSuit.Clubs);
            var numberOfCardsOfRank = cards.Count(x => x.Rank == CardRank.Ace);

            Assert.Equal(52, cards.Count);
            Assert.Equal(13, numberOfCardsInSuit);
            Assert.Equal(4, numberOfCardsOfRank);
        }

        [Fact]
        public void HaveSameCardsInDeck_AfterShuffling() // TODO: how to call through Controller.Play()
        {
            var deck = new Deck(new List<Card>());
            var controller = new Controller();

            var result = controller.Shuffle();
            var cards = result.Cards;
            var numberOfCardsInSuit = cards.Count(x => x.Suit == CardSuit.Clubs);
            var numberOfCardsOfRank = cards.Count(x => x.Rank == CardRank.Ace);

            Assert.True(BlackjackHelper.DecksOfCardsAreEqual(deck, result));
            Assert.Equal(52, cards.Count);
            Assert.Equal(13, numberOfCardsInSuit);
            Assert.Equal(4, numberOfCardsOfRank);
        }

        [Fact]
        public void GiveEachPlayer2Cards_WhenInitialized() // TODO: failing - returns a count of 3 for both asserts
        {
            var controller = new Controller();

            controller.Play();

            Assert.Equal(2, controller.Players[0].ReceiveCard(It.IsAny<Card>()).Count);
            Assert.Equal(2, controller.Players[1].ReceiveCard(It.IsAny<Card>()).Count);
        }
    }
}