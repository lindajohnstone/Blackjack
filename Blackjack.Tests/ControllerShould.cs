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
        public void ReturnDealerWin_GivenPlayerBust()
        {
            var output = new StubOutput();
            var player = new Player(new Hand());
            var dealer = new Dealer(new Hand()); 
            var controller = new Controller(_mockInput.Object, output, player, dealer, _mockDeck.Object);
            _mockInput.SetupSequence(_ => _.ReadLine())
                .Returns("1")
                .Returns("0");
            _mockDeck.SetupSequence(d => d.DealCard())
                .Returns(new Card(CardRank.Eight, CardSuit.Hearts))
                .Returns(new Card(CardRank.Ten, CardSuit.Diamonds))
                .Returns(new Card(CardRank.Two, CardSuit.Hearts))
                .Returns(new Card(CardRank.Two, CardSuit.Clubs))
                .Returns(new Card(CardRank.Four, CardSuit.Diamonds));

            controller.Play();

            Assert.Equal("Dealer wins!", output.GetLastOutput()); 
        }

        [Fact]
        public void ReturnPlayerWin_GivenDealerBust()
        {
            var output = new StubOutput();
            var player = new Player(new Hand());
            var dealer = new Dealer(new Hand());
            var controller = new Controller(_mockInput.Object, output, player, dealer, _mockDeck.Object);
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

            controller.Play();

            Assert.Equal("You beat the Dealer!", output.GetLastOutput());
        }

        [Fact] // TODO: rename - bug fix??
        public void ReturnPlayerWin_GivenPlayerHasBlackjack() // fixed bug - if player had blackjack, would display lines 140 + 149
        {
            var output = new StubOutput();
            var player = new Player(new Hand());
            var dealer = new Dealer(new Hand());
            var controller = new Controller(_mockInput.Object, output, player, dealer, _mockDeck.Object);
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

            controller.Play();

            Assert.Equal("You beat the Dealer!", output.GetLastOutput());
        }

        [Fact] // TODO: rename - bug fix??
        public void ReturnPlayerWin_GivenPlayerHasBlackjackFromInitialDeal() // fixed bug - if initial player hand scored Blackjack, do/while would run
        {
            var output = new StubOutput();
            var player = new Player(new Hand());
            var dealer = new Dealer(new Hand());
            var controller = new Controller(_mockInput.Object, output, player, dealer, _mockDeck.Object);
            _mockInput.SetupSequence(_ => _.ReadLine())
                .Returns("0");
            _mockDeck.SetupSequence(d => d.DealCard())
                .Returns(new Card(CardRank.Jack, CardSuit.Diamonds))
                .Returns(new Card(CardRank.Ace, CardSuit.Diamonds))
                .Returns(new Card(CardRank.Five, CardSuit.Spades))
                .Returns(new Card(CardRank.Three, CardSuit.Diamonds))
                .Returns(new Card(CardRank.King, CardSuit.Spades));

            controller.Play();

            Assert.Equal("You beat the Dealer!", output.GetLastOutput());
        }

        [Fact]
        public void ReturnDealerWin_GivenDealerHasBlackjack()
        {
            var output = new StubOutput();
            var player = new Player(new Hand());
            var dealer = new Dealer(new Hand());
            var controller = new Controller(_mockInput.Object, output, player, dealer, _mockDeck.Object);
            _mockInput.SetupSequence(_ => _.ReadLine())
                .Returns("0");
            _mockDeck.SetupSequence(d => d.DealCard())
                .Returns(new Card(CardRank.Jack, CardSuit.Hearts)) 
                .Returns(new Card(CardRank.Ten, CardSuit.Diamonds)) 
                .Returns(new Card(CardRank.Ten, CardSuit.Hearts)) 
                .Returns(new Card(CardRank.Six, CardSuit.Clubs)) 
                .Returns(new Card(CardRank.Five, CardSuit.Diamonds));

            controller.Play();

            Assert.Equal("Dealer wins!", output.GetLastOutput());
        }

        [Fact]
        public void ReturnPlayerWins_GivenDealerHasLowerScore()
        {
            var output = new StubOutput();
            var player = new Player(new Hand());
            var dealer = new Dealer(new Hand());
            var controller = new Controller(_mockInput.Object, output, player, dealer, _mockDeck.Object);
            _mockInput.SetupSequence(_ => _.ReadLine())
                .Returns("0");
            _mockDeck.SetupSequence(d => d.DealCard())
                .Returns(new Card(CardRank.Nine, CardSuit.Hearts)) 
                .Returns(new Card(CardRank.Ten, CardSuit.Diamonds)) 
                .Returns(new Card(CardRank.Ten, CardSuit.Hearts)) 
                .Returns(new Card(CardRank.Seven, CardSuit.Clubs));

            controller.Play();

            Assert.Equal("You beat the Dealer!", output.GetLastOutput());
        }


        // test dealer wins if player score is lower 
    }
}