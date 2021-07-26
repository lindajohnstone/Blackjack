using System;
using System.Collections.Generic;
using Xunit;

namespace Blackjack.Tests
{
    public class ScoreShould
    {
        [Theory]
        [MemberData(nameof(BlackjackTestData.NumberCards), MemberType = typeof(BlackjackTestData))]
        public void CalculateSum_OfHandHoldingNumberCards(Hand hand, int expected)
        {
            var score = new Score();

            var result = score.Calculate(hand);

            Assert.Equal(expected, result);
        }
    }
}