using System;
using System.Collections.Generic;
using Xunit;

namespace Blackjack.Tests
{
    public class DeckShould
    {
        [Fact]
        public void BeEquivalent_GivenTwoListsOfCards()
        {
            var cards1 = new List<Card>()
            {
                new Card(CardRank.Ace, CardSuit.Clubs),
                new Card(CardRank.Ace, CardSuit.Diamonds),
                new Card(CardRank.Ace, CardSuit.Hearts),
                new Card(CardRank.Ace, CardSuit.Spades)
            };
            var cards2 = new List<Card>()
            {
                new Card(CardRank.Ace, CardSuit.Clubs),
                new Card(CardRank.Ace, CardSuit.Diamonds),
                new Card(CardRank.Ace, CardSuit.Hearts),
                new Card(CardRank.Ace, CardSuit.Spades)
            };

            var result = BlackjackHelper.ListsOfCardsAreEqual(cards1, cards2);

            Assert.True(result);
        }

        [Fact]
        public void NotBeEquivalent_GivenTwoDifferentLists_ofCards()
        {
            var cards1 = new List<Card>()
            {
                new Card(CardRank.Two, CardSuit.Clubs),
                new Card(CardRank.Ace, CardSuit.Diamonds),
                new Card(CardRank.Ace, CardSuit.Hearts),
                new Card(CardRank.Ace, CardSuit.Spades)
            };
            var cards2 = new List<Card>()
            {
                new Card(CardRank.Ace, CardSuit.Clubs),
                new Card(CardRank.Ace, CardSuit.Diamonds),
                new Card(CardRank.Ace, CardSuit.Hearts),
                new Card(CardRank.Ace, CardSuit.Spades)
            };

            var result = BlackjackHelper.ListsOfCardsAreEqual(cards1, cards2);

            Assert.False(result);
        }

        [Fact]
        public void BeEquivalent_GivenTwoDecksOfCards()
        {
            var cards1 = new List<Card>()
            {
                new Card(CardRank.Ace, CardSuit.Clubs),
                new Card(CardRank.Ace, CardSuit.Diamonds),
                new Card(CardRank.Ace, CardSuit.Hearts),
                new Card(CardRank.Ace, CardSuit.Spades)
            };
            var cards2 = new List<Card>()
            {
                new Card(CardRank.Ace, CardSuit.Clubs),
                new Card(CardRank.Ace, CardSuit.Diamonds),
                new Card(CardRank.Ace, CardSuit.Hearts),
                new Card(CardRank.Ace, CardSuit.Spades)
            };
            var deck1 = new Deck(cards1);
            var deck2 = new Deck(cards2);

            var result = BlackjackHelper.DecksOfCardsAreEqual(deck1, deck2);

            Assert.True(result);
        }

        [Fact]
        public void NotBeEquivalent_GivenTwoDifferentDecks()
        {
            var cards1 = new List<Card>()
            {
                new Card(CardRank.Two, CardSuit.Clubs),
                new Card(CardRank.Ace, CardSuit.Diamonds),
                new Card(CardRank.Ace, CardSuit.Hearts),
                new Card(CardRank.Ace, CardSuit.Spades)
            };
            var cards2 = new List<Card>()
            {
                new Card(CardRank.Ace, CardSuit.Clubs),
                new Card(CardRank.Ace, CardSuit.Diamonds),
                new Card(CardRank.Ace, CardSuit.Hearts),
                new Card(CardRank.Ace, CardSuit.Spades)
            };

            var result = BlackjackHelper.ListsOfCardsAreEqual(cards1, cards2);

            Assert.False(result);
        }
        // test to check number of cards
        // check there are 13 cards with same suit
        // 4 cards with different suits
    }
}