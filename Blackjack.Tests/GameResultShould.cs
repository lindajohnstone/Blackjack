using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using Xunit;

namespace Blackjack.Tests
{
    public class GameResultShould
    {
        [Theory]
        [InlineData(CardRank.Jack, CardRank.Queen, CardRank.King)]
        [InlineData(CardRank.Jack, CardRank.Two, CardRank.Ten)]
        public void ReturnDealerWin_GivenPlayerGoneBust(params CardRank[] cardRanks)
        {
            var mockPlayerHand = new Mock<IHand>();
            mockPlayerHand.Setup(h => h.Cards)
                .Returns(
                    cardRanks.Select(
                        cr => new Card(cr, It.IsAny<CardSuit>())
                    ).ToList()
                );
            var gameResult = new GameResult(It.IsAny<IHand>(), mockPlayerHand.Object);
            var expected = Outcome.DealerWin;

            var actual = gameResult.Outcome;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(CardRank.Jack, CardRank.Queen, CardRank.King)]
        [InlineData(CardRank.Jack, CardRank.Two, CardRank.Ten)]
        public void ReturnPlayerWin_GivenDealerGoneBust(params CardRank[] cardRanks)
        {
            var mockDealerHand = new Mock<IHand>();
            mockDealerHand.Setup(h => h.Cards)
                .Returns(
                    cardRanks.Select(
                        cr => new Card(cr, It.IsAny<CardSuit>())
                    ).ToList()
                );
            var mockPlayerHand = new Mock<IHand>();
            mockPlayerHand.Setup(h => h.Cards)
                .Returns(new List<Card>
                    {
                        new Card(CardRank.Ace, It.IsAny<CardSuit>()),
                        new Card(CardRank.Ace, It.IsAny<CardSuit>())
                    }
                );
            var gameResult = new GameResult(mockDealerHand.Object, mockPlayerHand.Object);
            var expected = Outcome.PlayerWin;

            var actual = gameResult.Outcome;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(CardRank.Jack, CardRank.Eight)]
        [InlineData(CardRank.Jack, CardRank.Two, CardRank.Five)]
        public void ReturnDealerWin_GivenPlayerScoreIsLower(params CardRank[] cardRanks)
        {
            var mockDealerHand = new Mock<IHand>();
            mockDealerHand.Setup(h => h.Cards)
                .Returns(new List<Card>
                    {
                        new Card(CardRank.King, It.IsAny<CardSuit>()),
                        new Card(CardRank.Queen, It.IsAny<CardSuit>())
                    }
                );
            var mockPlayerHand = new Mock<IHand>();
            mockPlayerHand.Setup(h => h.Cards)
                .Returns(
                    cardRanks.Select(
                        cr => new Card(cr, It.IsAny<CardSuit>())
                    ).ToList()
                );
            var gameResult = new GameResult(mockDealerHand.Object, mockPlayerHand.Object);
            var expected = Outcome.DealerWin;

            var actual = gameResult.Outcome;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(CardRank.Jack, CardRank.Eight)]
        [InlineData(CardRank.Jack, CardRank.Two, CardRank.Five)]
        public void ReturnPlayerWin_GivenDealerScoreIsLower(params CardRank[] cardRanks)
        {
            var mockDealerHand = new Mock<IHand>();
            mockDealerHand.Setup(h => h.Cards)
                .Returns(
                    cardRanks.Select(
                        cr => new Card(cr, It.IsAny<CardSuit>())
                    ).ToList()
                );
            var mockPlayerHand = new Mock<IHand>();
            mockPlayerHand.Setup(h => h.Cards)
                .Returns(new List<Card>
                    {
                        new Card(CardRank.King, It.IsAny<CardSuit>()),
                        new Card(CardRank.Queen, It.IsAny<CardSuit>())
                    }
                );
            var gameResult = new GameResult(mockDealerHand.Object, mockPlayerHand.Object);
            var expected = Outcome.PlayerWin;

            var actual = gameResult.Outcome;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(CardRank.Jack, CardRank.Eight, CardRank.Three)]
        [InlineData(CardRank.Jack, CardRank.Two, CardRank.Five, CardRank.Four)]
        public void ReturnTie_GivenBothPlayersHaveBlackjack(params CardRank[] cardRanks)
        {
            var mockDealerHand = new Mock<IHand>();
            mockDealerHand.Setup(h => h.Cards)
                .Returns(
                    cardRanks.Select(
                        cr => new Card(cr, It.IsAny<CardSuit>())
                    ).ToList()
                );
            var mockPlayerHand = new Mock<IHand>();
            mockPlayerHand.Setup(h => h.Cards)
                .Returns(new List<Card>
                    {
                        new Card(CardRank.King, It.IsAny<CardSuit>()),
                        new Card(CardRank.Queen, It.IsAny<CardSuit>()),
                        new Card(CardRank.Ace, It.IsAny<CardSuit>())
                    }
                );
            var gameResult = new GameResult(mockDealerHand.Object, mockPlayerHand.Object);
            var expected = Outcome.Tie;

            var actual = gameResult.Outcome;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(CardRank.Jack, CardRank.Eight, CardRank.Two)]
        [InlineData(CardRank.Jack, CardRank.Two, CardRank.Five, CardRank.Three)]
        public void ReturnTie_GivenBothPlayersHaveSameScore(params CardRank[] cardRanks)
        {
            var mockDealerHand = new Mock<IHand>();
            mockDealerHand.Setup(h => h.Cards)
                .Returns(
                    cardRanks.Select(
                        cr => new Card(cr, It.IsAny<CardSuit>())
                    ).ToList()
                );
            var mockPlayerHand = new Mock<IHand>();
            mockPlayerHand.Setup(h => h.Cards)
                .Returns(new List<Card>
                    {
                        new Card(CardRank.King, It.IsAny<CardSuit>()),
                        new Card(CardRank.Queen, It.IsAny<CardSuit>())
                    }
                );
            var gameResult = new GameResult(mockDealerHand.Object, mockPlayerHand.Object);
            var expected = Outcome.Tie;

            var actual = gameResult.Outcome;

            Assert.Equal(expected, actual);
        }

    }
}