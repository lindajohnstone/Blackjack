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
        public void ReturnTrue_GivenScoreGreaterThan21(int score)
        {
            var rules= new Rules();

            var result = rules.IsBust(score);

            Assert.True(result);
        }

        [Theory]
        [InlineData(15)]
        [InlineData(21)]
        [InlineData(10)]
        [InlineData(5)]
        [InlineData(13)]
        public void ReturnFalse_GivenScoreLessThan21(int score)
        {
            var rules = new Rules();

            var result = rules.IsBust(score);

            Assert.False(result);
        }

        [Fact]
        public void ReturnTrue_GivenScoreOf21()
        {
            var rules = new Rules();
            var score = 21;

            var result = rules.IsBlackjack(score);

            Assert.True(result);
        }

        [Theory]
        [InlineData(22)]
        [InlineData(15)]
        [InlineData(10)]
        [InlineData(5)]
        [InlineData(13)]
        public void ReturnFalse_GivenScoreNotEqualTo21(int score)
        {
            var rules = new Rules();

            var result = rules.IsBlackjack(score);

            Assert.False(result);
        }
    }
}