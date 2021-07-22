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

            Assert.Empty(hand.Cards);
        }

        [Fact]
        public void Have2Cards_Given2CardsAdded()
        {
            var hand = new Hand();
            
            hand.AddCard(It.IsAny<Card>());
            hand.AddCard(It.IsAny<Card>());

            Assert.Equal(2, hand.Cards.Count);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void HaveCards_GivenCardsAdded(int expected) 
        {
            var hand = new Hand();

            for (var i = 0; i < expected; i++)
            {
                hand.AddCard(It.IsAny<Card>());
            }

            Assert.Equal(expected, hand.Cards.Count);
        }
    }
}