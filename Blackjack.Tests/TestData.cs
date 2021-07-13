using System.Collections.Generic;

namespace Blackjack.Tests
{
    public class TestData
    {
        public static IEnumerable<object[]> GetCardFromDataGenerator()
        {
            yield return new object[]
            {
                CardRank.Ten, CardSuit.Hearts, CardRank.Nine, CardSuit.Hearts
            };
            yield return new object[]
            {
                CardRank.Ace, CardSuit.Hearts, CardRank.Ace, CardSuit.Diamonds
            };
            yield return new object[]
            {
                CardRank.Five, CardSuit.Clubs, CardRank.Nine, CardSuit.Hearts
            };
            yield return new object[]
            {
                CardRank.Three, CardSuit.Hearts, CardRank.Nine, CardSuit.Clubs
            };
        }
    }
}