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
        Mock<IOutput> _mockOutput;
        Mock<IDeck> _mockDeck;
        public ControllerShould()
        {
            _mockInput = new Mock<IInput>();
            _mockOutput = new Mock<IOutput>();
            _mockDeck = new Mock<IDeck>();
            var player = new Player(new Hand());
            var dealer = new Dealer(new Hand());
            _controller = new Controller(_mockInput.Object, _mockOutput.Object, player, dealer, _mockDeck.Object);
        }

        [Fact]
        public void ReturnDealerWinOutcome_GivenPlayerGoesBust()
        {
            /*
                player receives 2 cards from deck
                8 of Hearts, 10 Diamonds - score = 18
                dealer receives 2 cards from deck
                (doesn't matter which ones)
                player hits 
                player receives 4 of Diamonds - score = 22 BUST!
            */
            _mockInput.SetupSequence(_ => _.ReadLine())
                .Returns("1")
                .Returns("0");
            _mockOutput.Setup(x => x.WriteLine(Messages.DealerWins)); // TODO: is this setup properly? 
            _mockDeck.SetupSequence(d => d.DealCard())
                .Returns(new Card(CardRank.Eight, CardSuit.Hearts))
                .Returns(new Card(CardRank.Ten, CardSuit.Diamonds))
                .Returns(new Card(CardRank.Two, CardSuit.Hearts))
                .Returns(new Card(CardRank.Two, CardSuit.Clubs))
                .Returns(new Card(CardRank.Four, CardSuit.Diamonds));

            _controller.Play();

            Assert.Equal("Dealer wins!", _mockOutput.ToString()); // failing
        }
    }
}