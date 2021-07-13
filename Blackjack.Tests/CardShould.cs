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

        [Theory]
        [MemberData(nameof(TestData.GetCardFromDataGenerator), MemberType = typeof(TestData))]
        public void NotBeEquivalent_GivenSameRankAndSuit(CardRank rank1, CardSuit suit1, CardRank rank2, CardSuit suit2)
        {
            var card1 = new Card(rank1, suit1);
            var card2 = new Card(rank2, suit2);

            var result = BlackjackHelper.CardsAreEqual(card1, card2);

            Assert.False(result);
        }    
    }
}
