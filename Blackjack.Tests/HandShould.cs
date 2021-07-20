using System;
using Moq;
using Xunit;

namespace Blackjack.Tests
{
    public class HandShould 
    {
        [Fact]
        public void HaveNoCards_WhenFirstSetUp()
        {
            var hand = new Hand();

            Assert.Equal(0, hand.Cards.Count);
        }

        [Fact]
        public void Have2Cards_Given2CarsAdded()
        {
            var hand = new Hand();
            
            hand.AddCard(It.IsAny<Card>());
            hand.AddCard(It.IsAny<Card>());

            Assert.Equal(2, hand.Cards.Count);
        }
    }
}