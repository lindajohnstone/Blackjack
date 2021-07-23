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

        Mock<IDeck> _mockDeck;
        List<IPlayer> _players;
        public ControllerShould()
        {
            _mockInput = new Mock<IInput>();
            _players = new List<IPlayer>();
            _mockDeck = new Mock<IDeck>();
            _controller = new Controller(_mockInput.Object, _players, _mockDeck.Object);
        }

        [Fact]
        public void GivePlayer2Cards_WhenGameStarts() 
        {
            _mockInput.Setup(x => x.ReadLine()).Returns("0");
            var mockPlayer = new Mock<IPlayer>();
            _players.Add(mockPlayer.Object);
            
            _controller.Play();

            mockPlayer.Verify(x => x.ReceiveCard(It.IsAny<Card>()), Times.Exactly(2));
        }

        [Fact]
        public void GivePlayerAnotherCard_WhenPlayerHits()
        {
            _mockInput.Setup(x => x.ReadLine()).Returns("1");
            _mockDeck.Setup(x => x.DealCard()).Returns(It.IsAny<Card>());
            var mockPlayer = new Mock<IPlayer>();
            _players.Add(mockPlayer.Object);

            _controller.Play();

            _mockDeck.Verify(x => x.DealCard(), Times.Exactly(3));
            mockPlayer.Verify(x => x.ReceiveCard(It.IsAny<Card>()), Times.Exactly(3));
        }
    }
}