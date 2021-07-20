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

            // Assert.Equal(0, hand.Cards.Count); //TODO: remove line - 'warning xUnit2013: Do not use Assert.Equal() to check for collection size.'
            Assert.IsType<Hand>(hand);
            Assert.Empty(hand.Cards);
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