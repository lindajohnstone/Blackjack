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
                .Returns(new Card(CardRank.Eight, CardSuit.Hearts))// player
                .Returns(new Card(CardRank.Ten, CardSuit.Diamonds))// player
                .Returns(new Card(CardRank.Ten, CardSuit.Hearts))// dealer
                .Returns(new Card(CardRank.Six, CardSuit.Clubs))// dealer
                .Returns(new Card(CardRank.Two, CardSuit.Diamonds))// player - score 20
                .Returns(new Card(CardRank.Six, CardSuit.Diamonds));

            controller.Play();

            Assert.Equal("You beat the Dealer!", output.GetLastOutput());
        }

        // Welcome to Blackjack!
        // You are currently at 15 with the hand 4 of Spades, Ace of Clubs.
        // Hit or stay? (Hit = 1, Stay = 0)1
        // You draw 9 of Spades.
        // You are currently at 14 with the hand 4 of Spades, Ace of Clubs, 9 of Spades.
        // Hit or stay? (Hit = 1, Stay = 0)1
        // You draw 7 of Hearts.
        // You are currently at Blackjack!! with the hand 4 of Spades, Ace of Clubs, 9 of Spades, 7 of Hearts.
        // You are currently at 21 with the hand 4 of Spades, Ace of Clubs, 9 of Spades, 7 of Hearts.
        // Dealer is at 20 with the hand 10 of Hearts, King of Spades.
        // You beat the Dealer!

        // Welcome to Blackjack!
        // You are currently at 17 with the hand 7 of Diamonds, Jack of Spades.
        // Hit or stay? (Hit = 1, Stay = 0)0
        // Dealer wins!
    }
}