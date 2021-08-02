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
            var expected = Choice.Hit;

            var result = Rules.ShouldDealerHitAgain(score);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(17)]
        [InlineData(24)]
        [InlineData(26)]
        [InlineData(22)]
        public void ReturnDealerShouldHitAgainIsFalse_GivenDealerScoreGreaterThan17(int score)
        {
            var expected = Choice.Stay;

            var result = Rules.ShouldDealerHitAgain(score);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ReturnPlayerWins_GivenPlayerHasBlackjack_AndDealerScoreIsLessThan21()
        {
            var playerScore = 21;
            var dealerScore = 18;
            var expected = "You beat the Dealer!";

            var result = Rules.GoneBlackjack(playerScore, dealerScore);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ReturnDealerWins_GivenDealerHasBlackjack_AndPlayerScoreIsLessThan21()
        {
            var playerScore = 18;
            var dealerScore = 21;
            var expected = "Dealer wins!";

            var result = Rules.GoneBlackjack(playerScore, dealerScore);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ReturnATie_GivenBothParticipantsHaveBlackjack()
        {
            var playerScore = 21;
            var dealerScore = 21;
            var expected = "It's a TIE!";

            var result = Rules.GoneBlackjack(playerScore, dealerScore);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(23, 18)]
        [InlineData(22, 21)]
        [InlineData(27, 18)]
        [InlineData(23, 8)]
        public void ReturnDealerWins_GivenPlayerBust(int playerScore, int dealerScore)
        {
            var expected = "Dealer wins!";

            var result = Rules.GoneBust(playerScore, dealerScore);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(18, 23)]
        [InlineData(20, 22)]
        [InlineData(18, 27)]
        [InlineData(19, 25)]
        public void ReturnPlayerWins_GivenDealerBust(int playerScore, int dealerScore)
        {
            var expected = "You beat the Dealer!";

            var result = Rules.GoneBust(playerScore, dealerScore);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ReturnPlayerWins_GivenHigherScoreThanDealer()
        {
            var playerScore = 20;
            var dealerScore = 18;
            var expected = "You beat the Dealer!";

            var result = Rules.WinningParticipant(playerScore, dealerScore);

            Assert.Equal(expected, result);
        }
    }
}