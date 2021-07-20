using System;
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
            var rank1 = CardRank.Ace;
            var suit1 = CardSuit.Hearts;
            var card1 = new Card(rank1, suit1);
            var rank2 = CardRank.Two;
            var suit2 = CardSuit.Diamonds;
            var card2 = new Card(rank2, suit2);

            hand.AddCard(card1);
            hand.AddCard(card2);

            Assert.Equal(2, hand.Cards.Count);
        }
    }
}