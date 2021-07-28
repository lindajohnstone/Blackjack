using System;
using Moq;
using Xunit;

namespace Blackjack.Tests
{
    public class DealerShould
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void HaveHandWithCards_GivenCardsAdded(int expected)
        {
            var mockHand = new Mock<IHand>();
            var dealer = new Dealer(mockHand.Object);
            for (var i = 0; i < expected; i++)
            {
                dealer.ReceiveCard(It.IsAny<Card>());
            }

            mockHand.Verify(x => x.AddCard(It.IsAny<Card>()), Times.Exactly(expected));
        }
    }
}