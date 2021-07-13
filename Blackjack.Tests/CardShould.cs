using System;
using Xunit;

namespace Blackjack.Tests
{
    public class CardShould
    {
        [Theory]
        [InlineData(CardRank.Ace, CardSuit.Clubs)]
        [InlineData(CardRank.Two, CardSuit.Diamonds)]
        [InlineData(CardRank.Queen, CardSuit.Hearts)]
        [InlineData(CardRank.Ten, CardSuit.Spades)]
        public void BeEquivalent_GivenSameRankAndSuit(CardRank rank, CardSuit suit)
        {
            var card1 = new Card(rank, suit);
            var card2 = new Card(rank, suit);

            var result = BlackjackHelper.CardsAreEqual(card1, card2);

            Assert.True(result);
        }

    }
}
