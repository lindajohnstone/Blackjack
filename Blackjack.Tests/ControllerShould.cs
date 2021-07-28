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
        Mock<IHand> _mockHand;
        Mock<IPlayer> _mockPlayer;
        public ControllerShould()
        {
            _mockInput = new Mock<IInput>();
            _mockOutput = new Mock<IOutput>();
            _mockDeck = new Mock<IDeck>();
            _mockPlayer = new Mock<IPlayer>();
            _mockHand = new Mock<IHand>();
            _mockHand.SetupGet(h => h.Cards).Returns(new List<Card>());
            _mockPlayer.SetupGet(p => p.Hand).Returns(_mockHand.Object);
            // add dealer here
            _players = new List<IPlayer> { _mockPlayer.Object };
            _controller = new Controller(_mockInput.Object, _mockOutput.Object, _players, _mockDeck.Object);
        }

        [Fact]
        public void GivePlayer2Cards_WhenGameStarts() 
        {
            _mockInput.Setup(x => x.ReadLine()).Returns("0");
            
            _controller.Play();

            _mockPlayer.Verify(x => x.ReceiveCard(It.IsAny<Card>()), Times.Exactly(2));
        }

        [Fact]
        public void GivePlayerAnotherCard_WhenPlayerHits()
        {
            _mockInput.SetupSequence(x => x.ReadLine()).Returns("1").Returns("0");
            _mockDeck.Setup(x => x.DealCard()).Returns(It.IsAny<Card>());

            _controller.Play();

            _mockDeck.Verify(x => x.DealCard(), Times.Exactly(3));
            _mockPlayer.Verify(x => x.ReceiveCard(It.IsAny<Card>()), Times.Exactly(3));
        }

        [Fact]
        public void GivePlayer2MoreCards_WhenPlayerHitsTwice()
        {
            _mockInput.SetupSequence(x => x.ReadLine()).Returns("1").Returns("1").Returns("0");

            _controller.Play();

            _mockPlayer.Verify(x => x.ReceiveCard(It.IsAny<Card>()), Times.Exactly(4));
        }
    }
}