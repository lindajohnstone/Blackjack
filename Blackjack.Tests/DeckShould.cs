using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Blackjack.Tests
{
    public class DeckShould
    {
        [Fact]
        public void BeInitialized()
        {
            var deck = new Deck();
            var numberOfCardsInSuit = deck.Cards.Count(x => x.Suit == CardSuit.Clubs);
            var numberOfCardsOfRank = deck.Cards.Count(x => x.Rank == CardRank.Ace);

            Assert.Equal(52, deck.Cards.Count);
            Assert.Equal(13, numberOfCardsInSuit);
            Assert.Equal(4, numberOfCardsOfRank);
        }

        [Fact]
        public void WhenShuffled_DeckHasSameCards() 
        {
            var deck = new Deck();
            
            var result = deck.Shuffle();
            var numberOfCardsInSuit = result.Cards.Count(x => x.Suit == CardSuit.Clubs);
            var numberOfCardsOfRank = result.Cards.Count(x => x.Rank == CardRank.Ace);

            //Assert.True(BlackjackHelper.DecksOfCardsAreEqual(deck, result));// TODO: is it shuffling properly 
            Assert.Equal(52, result.Cards.Count);
            Assert.Equal(13, numberOfCardsInSuit);
            Assert.Equal(4, numberOfCardsOfRank);
        }
    }
}