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
        StubOutput _output;
        Mock<IDeck> _mockDeck;
        public ControllerShould()
        {
            _mockInput = new Mock<IInput>();
            _output = new StubOutput();
            _mockDeck = new Mock<IDeck>();
            var player = new Player(new Hand());
            var dealer = new Dealer(new Hand());
            _controller = new Controller(_mockInput.Object, _output, player, dealer, _mockDeck.Object);
        }

        [Fact]
        public void ReturnDealerWin_GivenPlayerBust()
        {
            _mockInput.SetupSequence(_ => _.ReadLine())
                .Returns("1")
                .Returns("0");
            _mockDeck.SetupSequence(d => d.DealCard())
                .Returns(new Card(CardRank.Eight, CardSuit.Hearts))
                .Returns(new Card(CardRank.Ten, CardSuit.Diamonds))
                .Returns(new Card(CardRank.Two, CardSuit.Hearts))
                .Returns(new Card(CardRank.Two, CardSuit.Clubs))
                .Returns(new Card(CardRank.Four, CardSuit.Diamonds));

            var expectedOutcome = Outcome.DealerWin;

            var result = _controller.Play();

            Assert.Equal(expectedOutcome, result.Outcome);
        }

        [Fact]
        public void ReturnPlayerWin_GivenDealerBust()
        {
            _mockInput.SetupSequence(_ => _.ReadLine())
                .Returns("1")
                .Returns("0");
            _mockDeck.SetupSequence(d => d.DealCard())
                .Returns(new Card(CardRank.Eight, CardSuit.Hearts))
                .Returns(new Card(CardRank.Ten, CardSuit.Diamonds))
                .Returns(new Card(CardRank.Ten, CardSuit.Hearts))
                .Returns(new Card(CardRank.Six, CardSuit.Clubs))
                .Returns(new Card(CardRank.Two, CardSuit.Diamonds))
                .Returns(new Card(CardRank.Six, CardSuit.Diamonds));

            var expectedOutcome = Outcome.PlayerWin;

            var result = _controller.Play();

            Assert.Equal(expectedOutcome, result.Outcome);
        }

        [Fact]
        public void ReturnPlayerWin_GivenPlayerHasBlackjack() // fixed bug - if player had blackjack, would display lines 140 + 149
        {
            _mockInput.SetupSequence(_ => _.ReadLine())
                .Returns("1")
                .Returns("1")
                .Returns("0");
            _mockDeck.SetupSequence(d => d.DealCard())
                .Returns(new Card(CardRank.Four, CardSuit.Spades)) 
                .Returns(new Card(CardRank.Ace, CardSuit.Clubs)) 
                .Returns(new Card(CardRank.Ten, CardSuit.Hearts)) 
                .Returns(new Card(CardRank.King, CardSuit.Spades)) 
                .Returns(new Card(CardRank.Nine, CardSuit.Spades)) 
                .Returns(new Card(CardRank.Seven, CardSuit.Hearts)); 

            var expectedOutcome = Outcome.PlayerWin;

            var result = _controller.Play();

            Assert.Equal(expectedOutcome, result.Outcome);
        }

        [Fact]
        public void ReturnPlayerWin_GivenPlayerHasBlackjackFromInitialDeal() // fixed bug - if initial player hand scored Blackjack, do/while would run
        {
            _mockInput.Setup(_ => _.ReadLine())
                .Returns("0");
            _mockDeck.SetupSequence(d => d.DealCard())
                .Returns(new Card(CardRank.Jack, CardSuit.Diamonds))
                .Returns(new Card(CardRank.Ace, CardSuit.Diamonds))
                .Returns(new Card(CardRank.Five, CardSuit.Spades))
                .Returns(new Card(CardRank.Three, CardSuit.Diamonds))
                .Returns(new Card(CardRank.King, CardSuit.Spades));

            var expectedOutcome = Outcome.PlayerWin;

            var result = _controller.Play();

            Assert.Equal(expectedOutcome, result.Outcome);
        }

        [Fact]
        public void ReturnDealerWin_GivenDealerHasBlackjack()
        {
            _mockInput.Setup(_ => _.ReadLine())
                .Returns("0");
            _mockDeck.SetupSequence(d => d.DealCard())
                .Returns(new Card(CardRank.Jack, CardSuit.Hearts))
                .Returns(new Card(CardRank.Ten, CardSuit.Diamonds))
                .Returns(new Card(CardRank.Ten, CardSuit.Hearts))
                .Returns(new Card(CardRank.Six, CardSuit.Clubs))
                .Returns(new Card(CardRank.Five, CardSuit.Diamonds));

            var expectedOutcome = Outcome.DealerWin;

            var result = _controller.Play();

            Assert.Equal(expectedOutcome, result.Outcome);
        }

        [Fact]
        public void ReturnPlayerWins_GivenDealerHasLowerScore()
        {
            _mockInput.Setup(_ => _.ReadLine())
                .Returns("0");
            _mockDeck.SetupSequence(d => d.DealCard())
                .Returns(new Card(CardRank.Nine, CardSuit.Hearts))
                .Returns(new Card(CardRank.Ten, CardSuit.Diamonds))
                .Returns(new Card(CardRank.Ten, CardSuit.Hearts))
                .Returns(new Card(CardRank.Seven, CardSuit.Clubs));

            var expectedOutcome = Outcome.PlayerWin;

            var result = _controller.Play();

            Assert.Equal(expectedOutcome, result.Outcome);
        }

        [Fact]
        public void ReturnDealerWins_GivenPlayerHasLowerScore()
        {
            _mockInput.Setup(_ => _.ReadLine())
                .Returns("0");
            _mockDeck.SetupSequence(d => d.DealCard())
                .Returns(new Card(CardRank.Ten, CardSuit.Hearts))
                .Returns(new Card(CardRank.Seven, CardSuit.Clubs))
                .Returns(new Card(CardRank.Nine, CardSuit.Hearts))
                .Returns(new Card(CardRank.Ten, CardSuit.Diamonds));

            var expectedOutcome = Outcome.DealerWin;

            var result = _controller.Play();

            Assert.Equal(expectedOutcome, result.Outcome);
        }

        [Fact]
        public void ReturnDealerWins_AtGameEnd_AfterScoreGreaterThanPlayer()
        {
            _mockInput.SetupSequence(_ => _.ReadLine())
                .Returns("1")
                .Returns("0");
            _mockDeck.SetupSequence(d => d.DealCard())
                .Returns(new Card(CardRank.Ten, CardSuit.Hearts))
                .Returns(new Card(CardRank.Seven, CardSuit.Clubs))
                .Returns(new Card(CardRank.Nine, CardSuit.Hearts))
                .Returns(new Card(CardRank.Ten, CardSuit.Diamonds))
                .Returns(new Card(CardRank.Ace, CardSuit.Diamonds));
            var expected = "Dealer wins!";

            _controller.Play();
            _controller.DisplayGameResult();

            Assert.Equal(expected, _output.GetWinner());
        }

        [Fact]
        public void ReturnDealerWins_AtGameEnd_AfterPlayerGoesBust()
        {
            _mockInput.SetupSequence(_ => _.ReadLine())
                .Returns("1")
                .Returns("0");
            _mockDeck.SetupSequence(d => d.DealCard())
                .Returns(new Card(CardRank.Ten, CardSuit.Hearts))
                .Returns(new Card(CardRank.Seven, CardSuit.Clubs))
                .Returns(new Card(CardRank.Nine, CardSuit.Hearts))
                .Returns(new Card(CardRank.Ten, CardSuit.Diamonds))
                .Returns(new Card(CardRank.Five, CardSuit.Diamonds));
            var expected = "Dealer wins!";

            _controller.Play();
            _controller.DisplayGameResult();

            Assert.Equal(expected, _output.GetWinner());
        }
    }
}