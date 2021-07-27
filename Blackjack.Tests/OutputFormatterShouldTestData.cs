using System;
using System.Collections.Generic;
using Xunit;

namespace Blackjack.Tests
{
    public class OutputFormatterShouldTestData
    {
        public static TheoryData<Hand, string> HandData =
            new TheoryData<Hand, string>
            {
                { 
                    new Hand(new List<Card> 
                    { 
                        new Card(CardRank.Ace, CardSuit.Hearts), 
                        new Card(CardRank.Six, CardSuit.Spades), 
                        new Card(CardRank.Two, CardSuit.Clubs)
                    }),
                    "Ace of Hearts, 6 of Spades, 2 of Clubs" 
                },
                {
                    new Hand(new List<Card>
                    {
                        new Card(CardRank.Seven, CardSuit.Hearts),
                        new Card(CardRank.Six, CardSuit.Spades),
                        new Card(CardRank.Two, CardSuit.Clubs)
                    }),
                    "7 of Hearts, 6 of Spades, 2 of Clubs"
                },
                {
                    new Hand(new List<Card> 
                    { 
                        new Card(CardRank.Queen, CardSuit.Hearts), 
                    }),
                    "Queen of Hearts" 
                },
                {
                    new Hand(new List<Card>
                    {
                        new Card(CardRank.Jack, CardSuit.Diamonds),
                        new Card(CardRank.Six, CardSuit.Spades),
                    }),
                    "Jack of Diamonds, 6 of Spades"
                }
            };
        }
}