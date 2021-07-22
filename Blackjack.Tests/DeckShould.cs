using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
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
            
            deck.Shuffle();
            var result = deck.Cards;
            var numberOfCardsInSuit = result.Count(x => x.Suit == CardSuit.Clubs);
            var numberOfCardsOfRank = result.Count(x => x.Rank == CardRank.Ace);

            Assert.Equal(52, result.Count);
            Assert.Equal(13, numberOfCardsInSuit);
            Assert.Equal(4, numberOfCardsOfRank);
        }

        [Fact]
        public void HaveLessCards_AfterDealingCard()
        {
            var deck = new Deck();

            Assert.Equal(52, deck.Cards.Count);
            deck.DealCard();

            Assert.Equal(51, deck.Cards.Count);
        }
    }
}