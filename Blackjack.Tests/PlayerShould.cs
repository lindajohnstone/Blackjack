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
        public void HaveHandWithCards_GivenCardsAdded(int expected) // TODO: should this test be test the Hand prop or the ReceiveCard method
        {
            var player = new Player();
            var hand = player.Hand;

            for (var i = 0; i < expected; i++)
            {
                player.ReceiveCard(It.IsAny<Card>());
            }

            Assert.Equal(expected, hand.Cards.Count);
        }

        // should there be a test for ReceiveCard also?
    }
}