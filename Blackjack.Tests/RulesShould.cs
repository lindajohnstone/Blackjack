using System;
using Xunit;

namespace Blackjack.Tests
{
    public class RulesShould
    {
        [Theory]
        [MemberData(nameof(RulesShouldTestData.HandScoreBustTrueData), MemberType = typeof(RulesShouldTestData))]
        public void ReturnTrue_GivenScoreGreaterThan21(Hand hand, int score)
        {
            var rules= new Rules();

            var result = rules.IsBust(score);

            Assert.True(result);
        }

        [Theory]
        [MemberData(nameof(RulesShouldTestData.HandData), MemberType = typeof(RulesShouldTestData))]
        public void ReturnFalse_GivenScoreLessThan21(Hand hand, int score)
        {
            var rules = new Rules();

            var result = rules.IsBust(score);

            Assert.False(result);
        }

        [Theory]
        [MemberData(nameof(RulesShouldTestData.HandScoreBlackjackData), MemberType = typeof(RulesShouldTestData))]
        public void ReturnTrue_GivenScoreOf21(Hand hand, int score)
        {
            var rules = new Rules();

            var result = rules.IsBlackjack(score);

            Assert.True(result);
        }

        [Theory]
        [MemberData(nameof(RulesShouldTestData.HandData), MemberType = typeof(RulesShouldTestData))]
        public void ReturnFalse_GivenScoreNotEqualTo21(Hand hand, int score)
        {
            var rules = new Rules();

            var result = rules.IsBlackjack(score);

            Assert.False(result);
        }
    }
}