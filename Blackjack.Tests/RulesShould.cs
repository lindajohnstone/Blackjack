using System;
using Xunit;

namespace Blackjack.Tests
{
    public class RulesShould
    {
        [Theory]
        [InlineData(24)]
        [InlineData(26)]
        [InlineData(22)]
        [InlineData(30)]
        public void ReturnBustIsTrue_GivenScoreGreaterThan21(int score)
        {
            var result = Rules.IsBust(score);

            Assert.True(result);
        }

        [Theory]
        [InlineData(15)]
        [InlineData(21)]
        [InlineData(10)]
        [InlineData(5)]
        [InlineData(13)]
        public void ReturnBustIsFalse_GivenScoreLessThan21(int score)
        {
            var result = Rules.IsBust(score);

            Assert.False(result);
        }

        [Fact]
        public void ReturnBlackjackIsTrue_GivenScoreOf21()
        {
            var score = 21;

            var result = Rules.IsBlackjack(score);

            Assert.True(result);
        }

        [Theory]
        [InlineData(22)]
        [InlineData(15)]
        [InlineData(10)]
        [InlineData(5)]
        [InlineData(13)]
        public void ReturnBlackjackIsFalse_GivenScoreNotEqualTo21(int score)
        {
            var result = Rules.IsBlackjack(score);

            Assert.False(result);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(16)]
        [InlineData(12)]
        [InlineData(8)]
        [InlineData(4)]
        public void ReturnDealerShouldHitAgainIsTrue_GivenDealerScoreLessThan17(int score)
        {
            var result = Rules.ShouldDealerHitAgain(score);

            Assert.True(result);
        }

        [Theory]
        [InlineData(17)]
        [InlineData(24)]
        [InlineData(26)]
        [InlineData(22)]
        public void ReturnDealerShouldHitAgainIsFalse_GivenDealerScoreGreaterThan17(int score)
        {
            var result = Rules.ShouldDealerHitAgain(score);

            Assert.False(result);
        }
    }
}