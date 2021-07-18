using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using Moq.Protected;
using Xunit;

namespace Blackjack.Tests
{
    public class ControllerShould
    {
        Controller _controller;
        public ControllerShould()
        {
            _controller = new Controller();
        }
        [Fact]
        public void HasFullDeck_WhenInitialized()
        {
            var cards = _controller.Deck.Cards;
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
            
            var result = _controller.Shuffle();
            var cards = result.Cards;
            var numberOfCardsInSuit = cards.Count(x => x.Suit == CardSuit.Clubs);
            var numberOfCardsOfRank = cards.Count(x => x.Rank == CardRank.Ace);
            
            Assert.True(BlackjackHelper.DecksOfCardsAreEqual(deck, result));
            Assert.Equal(52, cards.Count);
            Assert.Equal(13, numberOfCardsInSuit);
            Assert.Equal(4, numberOfCardsOfRank);
        }

        [Fact]
        public void GiveEachPlayer2Cards_AfterDeckShuffled() // TODO: does this violate the law of demeter?
        {
            var player = _controller.Players[0];
            var dealer = _controller.Players[1];

            _controller.Play();

            Assert.Equal(2, player.Hand.Count); 
            Assert.Equal(2, dealer.Hand.Count);
        }
    }
}