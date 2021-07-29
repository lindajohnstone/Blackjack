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
            var players = new List<IPlayer> { player, dealer };
            _controller = new Controller(_mockInput.Object, _mockOutput.Object, players, _mockDeck.Object);
        }


        [Fact]
        public void testName() //TODO: failing - not fully setup?
        {
            _mockInput.Setup(i => i.ReadLine()).Returns("0");
            _mockDeck.SetupSequence(d => d.DealCard())
                .Returns(new Card(CardRank.Ace, CardSuit.Clubs))
                .Returns(new Card(CardRank.Ten, CardSuit.Hearts))
                .Returns(new Card(CardRank.Eight, CardSuit.Spades))
                .Returns(new Card(CardRank.Nine, CardSuit.Diamonds));
            _mockOutput.Setup(o => o.WriteLine("You beat the Dealer!"));
    
            var expected = "You beat the Dealer!";

            _controller.Play();

            Assert.Equal(expected, _mockOutput.ToString());
        }

        [Fact]
        public void ReturnEndTurnTrue_GivenPlayerScoreEqualTo21()
        {
            var score = 21;

            var result = _controller.EndTurn(It.IsAny<Choice>(), score);

            Assert.True(result);
        }

        [Fact]
        public void ReturnEndTurnFalse_GivenPlayerScoreNotEqualTo21()
        {
            var score = 20;

            var result = _controller.EndTurn(It.IsAny<Choice>(), score);

            Assert.False(result);
        }

        [Fact]
        public void ReturnEndTurnTrue_GivenPlayerScoreGreaterThan21()
        {
            var score = 24;

            var result = _controller.EndTurn(It.IsAny<Choice>(), score);

            Assert.True(result);
        }

        [Fact]
        public void ReturnEndTurnTrue_GivenPlayerChoosesToStay() 
        {
            var choice = Choice.Stay;

            var result = _controller.EndTurn(choice, It.IsAny<int>());

            Assert.True(result);
        }
    }
}