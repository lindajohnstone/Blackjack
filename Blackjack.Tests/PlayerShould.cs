using System;
using System.Collections.Generic;
using Moq;
using Xunit;

namespace Blackjack.Tests
{
    public class PlayerShould
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void HaveHandWithCards_GivenCardsAdded(int expected) 
        {
            var mockHand = new Mock<IHand>();
            var player = new Player(mockHand.Object);

            for (var i = 0; i < expected; i++)
            {
                player.ReceiveCard(It.IsAny<Card>());
            }

            mockHand.Verify(x => x.AddCard(It.IsAny<Card>()), Times.Exactly(expected));
        }
    }
}