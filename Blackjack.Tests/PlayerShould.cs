using System;
using System.Collections.Generic;
using Moq;
using Xunit;

namespace Blackjack.Tests
{
    public class PlayerShould
    {
        [Fact]
        public void Verify_PlayerReceives2Cards()
        {
            var mockPlayer = new Mock<IPlayer>();
            var rank1 = CardRank.Ace;
            var suit1 = CardSuit.Hearts;
            var card1 = new Card(rank1, suit1);
            var rank2 = CardRank.Two;
            var suit2 = CardSuit.Diamonds;
            var card2 = new Card(rank2, suit2);
            var cards = new List<Card>();
            mockPlayer.Setup(x => x.ReceiveCard(Capture.In(cards)));

            mockPlayer.Object.ReceiveCard(card1);
            mockPlayer.Object.ReceiveCard(card2);

            mockPlayer.Verify(x => x.ReceiveCard(It.IsAny<Card>()), Times.Exactly(2));
        }
    }
}