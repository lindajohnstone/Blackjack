using System;
using Xunit;

namespace Blackjack.Tests
{
    public class OutputFormatterShould
    {
        [Fact]
        public void FormatHandAsString_GivenHand()
        {
            var hand = new Hand();
            hand.AddCard(new Card(CardRank.Ace, CardSuit.Hearts));
            hand.AddCard(new Card(CardRank.Six, CardSuit.Spades));
            hand.AddCard(new Card(CardRank.Two, CardSuit.Clubs));
            var expected = "Ace of Hearts, 6 of Spades, 2 of Clubs";

            var result = OutputFormatter.DisplayHand(hand);

            Assert.Equal(expected, result);
        }
    }
}