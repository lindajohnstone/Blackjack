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
        List<IPlayer> _players;
        Mock<IHand> _mockPlayerHand;
        Mock<IPlayer> _mockPlayer;
        Mock<IHand> _mockDealerHand;
        Mock<IPlayer> _mockDealer;
        public ControllerShould()
        {
            _mockInput = new Mock<IInput>();
            _mockOutput = new Mock<IOutput>();
            _mockDeck = new Mock<IDeck>();
            _mockPlayer = new Mock<IPlayer>();
            _mockPlayerHand = new Mock<IHand>();
            _mockPlayerHand.SetupGet(h => h.Cards).Returns(new List<Card>());
            _mockPlayer.SetupGet(p => p.Hand).Returns(_mockPlayerHand.Object);
            _mockDealer = new Mock<IPlayer>();
            _mockDealerHand = new Mock<IHand>();
            _mockDealerHand.SetupGet(h => h.Cards).Returns(new List<Card>());
            _mockDealer.SetupGet(d => d.Hand).Returns(_mockDealerHand.Object);
            _players = new List<IPlayer> { _mockPlayer.Object, _mockDealer.Object };
            _controller = new Controller(_mockInput.Object, _mockOutput.Object, _players, _mockDeck.Object);
        }

        [Fact]
        public void GivePlayerAndDealer2Cards_WhenGameStarts() 
        {
            _mockInput.Setup(x => x.ReadLine()).Returns("0");
            _mockPlayerHand.Setup(p => p.Cards)
                .Returns(new List<Card>
                {
                    new Card(CardRank.Ace, CardSuit.Spades),
                    new Card(CardRank.Three, CardSuit.Hearts)
                });
            _mockDealerHand.Setup(h => h.Cards)
                .Returns(new List<Card>
                    {
                        new Card(CardRank.Eight, CardSuit.Diamonds),
                        new Card(CardRank.Ten, CardSuit.Diamonds)
                    });

            _controller.Play();

            _mockPlayer.Verify(x => x.ReceiveCard(It.IsAny<Card>()), Times.Exactly(2));
            _mockDealer.Verify(x => x.ReceiveCard(It.IsAny<Card>()), Times.Exactly(2));
        }

        [Fact]
        public void GivePlayerAnotherCard_WhenPlayerHits() // TODO: failing
        {
            _mockInput.SetupSequence(x => x.ReadLine()).Returns("1").Returns("0");
            _mockPlayerHand.SetupSequence(p => p.Cards)
                .Returns(new List<Card>
                {
                    new Card(CardRank.Ace, CardSuit.Spades),
                    new Card(CardRank.Three, CardSuit.Hearts)
                })
                .Returns(new List<Card>
                {
                    new Card(CardRank.Ace, CardSuit.Spades),
                    new Card(CardRank.Three, CardSuit.Hearts),
                    new Card(CardRank.Seven, CardSuit.Diamonds)
                });
            _mockDealerHand.Setup(h => h.Cards)
                .Returns(new List<Card>
                    {
                        new Card(CardRank.Eight, CardSuit.Diamonds),
                        new Card(CardRank.Ten, CardSuit.Diamonds)
                    });

            _controller.Play();

            _mockDeck.Verify(x => x.DealCard(), Times.Exactly(5)); // player receives 3 cards, dealer 2
            _mockPlayer.Verify(x => x.ReceiveCard(It.IsAny<Card>()), Times.Exactly(3));
        }

        [Fact]
        public void GivePlayer2MoreCards_WhenPlayerHitsTwice() // TODO: failing
        {
            _mockInput.SetupSequence(x => x.ReadLine()).Returns("1").Returns("1").Returns("0");
            _mockPlayerHand.Setup(p => p.Cards)
                .Returns(new List<Card>
                {
                    new Card(CardRank.Ace, CardSuit.Spades),
                    new Card(CardRank.Three, CardSuit.Hearts)
                });
            _mockDealerHand.SetupSequence(h => h.Cards)
                .Returns(new List<Card>
                    {
                        new Card(CardRank.Two, CardSuit.Diamonds),
                        new Card(CardRank.Ten, CardSuit.Diamonds)
                    })
                .Returns(new List<Card>
                    {
                        new Card(CardRank.Two, CardSuit.Diamonds),
                        new Card(CardRank.Ten, CardSuit.Diamonds),
                        new Card(CardRank.Six, CardSuit.Clubs)
                    });

            _controller.Play();

            _mockPlayer.Verify(x => x.ReceiveCard(It.IsAny<Card>()), Times.Exactly(4));
        }

        [Fact]
        public void GiveDealerMoreCards_WhenScoreLessThan17() // TODO: failing
        {
            _mockInput.Setup(x => x.ReadLine()).Returns("0");
            _mockPlayerHand.Setup(p => p.Cards)
                .Returns(new List<Card>
                {
                    new Card(CardRank.Ace, CardSuit.Spades),
                    new Card(CardRank.Three, CardSuit.Hearts)
                });
            _mockDealerHand.SetupSequence(h => h.Cards)
                .Returns(new List<Card> 
                    { 
                        new Card(CardRank.Two, CardSuit.Diamonds), 
                        new Card(CardRank.Ten, CardSuit.Diamonds) 
                    })
                .Returns(new List<Card>
                    {
                        new Card(CardRank.Two, CardSuit.Diamonds),
                        new Card(CardRank.Ten, CardSuit.Diamonds),
                        new Card(CardRank.Six, CardSuit.Clubs)
                    });
            
            _controller.Play();

            _mockDealer.Verify(h => h.ReceiveCard(It.IsAny<Card>()), Times.Exactly(3));
        }
    }
}