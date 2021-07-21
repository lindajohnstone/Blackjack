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
        Mock<IInput> _mockInput;
        List<IPlayer> _players;
        public ControllerShould()
        {
            _mockInput = new Mock<IInput>();
            _players = new List<IPlayer>();
            _controller = new Controller(_mockInput.Object, new List<IPlayer>(), new Deck());
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
    }
}