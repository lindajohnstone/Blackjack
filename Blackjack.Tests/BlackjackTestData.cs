using System;
using System.Collections.Generic;
using Xunit;

namespace Blackjack.Tests
{
    public class BlackjackTestData
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

       public static TheoryData<Hand, int> HandsWithNumberCardsData =
            new TheoryData<Hand, int>
            {
                {
                    new Hand(new List<Card>
                    {
                        new Card(CardRank.Seven, CardSuit.Hearts),
                        new Card(CardRank.Six, CardSuit.Spades),
                        new Card(CardRank.Two, CardSuit.Clubs)
                    }),
                    15
                },
                {
                    new Hand(new List<Card>
                    {
                        new Card(CardRank.Ten, CardSuit.Diamonds),
                        new Card(CardRank.Six, CardSuit.Spades),
                        new Card(CardRank.Eight, CardSuit.Clubs)
                    }),
                    24
                },
                {
                    new Hand(new List<Card>
                    {
                        new Card(CardRank.Two, CardSuit.Diamonds),
                        new Card(CardRank.Six, CardSuit.Spades),
                        new Card(CardRank.Two, CardSuit.Clubs),
                        new Card(CardRank.Four, CardSuit.Spades)
                    }),
                    14
                }
            };

        public static TheoryData<Hand, int> HandsWithFaceCardsNoAcesData =
            new TheoryData<Hand, int>
            {
                {
                    new Hand(new List<Card>
                    {
                        new Card(CardRank.Jack, CardSuit.Hearts),
                        new Card(CardRank.Six, CardSuit.Spades),
                        new Card(CardRank.Two, CardSuit.Clubs)
                    }),
                    18
                },
                {
                    new Hand(new List<Card>
                    {
                        new Card(CardRank.Jack, CardSuit.Spades),
                        new Card(CardRank.Ten, CardSuit.Clubs)
                    }),
                    20
                },
                {
                    new Hand(new List<Card>
                    {
                        new Card(CardRank.King, CardSuit.Diamonds),
                        new Card(CardRank.Six, CardSuit.Spades),
                        new Card(CardRank.Queen, CardSuit.Clubs)
                    }),
                    26
                }
            };

        public static TheoryData<Hand, int> HandsWithFaceCardsIncludingAcesData =
            new TheoryData<Hand, int>
            {
                {
                    new Hand(new List<Card>
                    {
                        new Card(CardRank.Ace, CardSuit.Diamonds),
                        new Card(CardRank.Two, CardSuit.Clubs)
                    }),
                    13
                },
                {
                    new Hand(new List<Card>
                    {
                        new Card(CardRank.Ace, CardSuit.Diamonds),
                        new Card(CardRank.Two, CardSuit.Clubs),
                        new Card(CardRank.Eight, CardSuit.Spades)
                    }),
                    21
                },
                {
                    new Hand(new List<Card>
                    {
                        new Card(CardRank.Ace, CardSuit.Diamonds),
                        new Card(CardRank.Ace, CardSuit.Clubs)
                    }),
                    12
                },
                {
                    new Hand(new List<Card>
                    {
                        new Card(CardRank.Ace, CardSuit.Clubs),
                        new Card(CardRank.Ace, CardSuit.Diamonds),
                        new Card(CardRank.Two, CardSuit.Clubs),
                        new Card(CardRank.Seven, CardSuit.Spades)
                    }),
                    21
                }
            };
        }
}