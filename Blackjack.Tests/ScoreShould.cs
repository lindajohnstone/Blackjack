using System;
using System.Collections.Generic;
using Xunit;

namespace Blackjack.Tests
{
    public class ScoreShould
    {
        [Theory]
        [MemberData(nameof(ScoreShouldTestData.HandsWithNumberCardsData), MemberType = typeof(ScoreShouldTestData))]
        public void CalculateSum_OfHandHoldingNumberCards(Hand hand, int expected)
        {
            var score = new Score();

            var result = score.Calculate(hand);

            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(ScoreShouldTestData.HandsWithFaceCardsNoAcesData), MemberType = typeof(ScoreShouldTestData))]
        public void CalculateSum_OfHandsWithNumbersAndFaceCards_NoAces(Hand hand, int expected)
        {
            var score = new Score();

            var result = score.Calculate(hand);

            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(ScoreShouldTestData.HandsWithFaceCardsIncludingAcesData), MemberType = typeof(ScoreShouldTestData))]
        public void CalculateSum_OfHandsWithNumbersFaceCardIncludingAce(Hand hand, int expected)
        {
            var score = new Score();

            var result = score.Calculate(hand);

            Assert.Equal(expected, result);
        }
    }
}