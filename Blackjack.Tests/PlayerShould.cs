using System;
using System.Collections.Generic;
using Moq;
using Xunit;

namespace Blackjack.Tests
{
    public class PlayerShould
    {
        [Fact]
        public void HaveHandWithCards_GivenCardsAdded()
        {
            var player = new Player();
            var hand = player.Hand;
            var expected = 1;

            hand.AddCard(It.IsAny<Card>());

            Assert.Equal(expected, hand.Cards.Count);
        }
    }
}