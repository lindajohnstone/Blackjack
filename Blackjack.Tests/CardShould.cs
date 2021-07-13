using System;
using Xunit;

namespace Blackjack.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void BeEquivalent_GivenSameRank()
        {
            var rank1 = CardRank.Two;
            var rank2 = CardRank.Two;

            var result = BlackjackHelper.RanksAreEqual(rank1, rank2);

            Assert.True(result);
        }

        [Fact]
        public void BeEquivalent_GivenSameSuit()
        {
            var suit1 = CardSuit.Hearts;
            var suit2 = CardSuit.Hearts;

            var result = BlackjackHelper.SuitsAreEqual(suit1, suit2);

            Assert.True(result);
        }
    }
}
