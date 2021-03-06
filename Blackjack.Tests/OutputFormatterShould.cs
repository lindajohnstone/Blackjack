using System;
using Xunit;

namespace Blackjack.Tests
{
    public class OutputFormatterShould
    {
        [Theory]
        [MemberData(nameof(OutputFormatterShouldTestData.HandData), MemberType = typeof(OutputFormatterShouldTestData))]
        public void FormatHandAsString_GivenHand(Hand hand, string expected)
        {
            var result = OutputFormatter.DisplayHand(hand);

            Assert.Equal(expected, result);
        }
    }
}