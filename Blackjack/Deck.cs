using System;
using System.Collections.Generic;

namespace Blackjack
{
    public class Deck
    {
        public List<Card> Cards { get; private set; }
        public Deck(List<Card> cards)
        {
            Cards = cards;
            Initialize(cards);
        }

        private List<Card> Initialize(List<Card> cards) // TODO: is there a way to set this via a loop?
        {
            cards.Add(new Card(CardRank.Ace, CardSuit.Clubs));
            cards.Add(new Card(CardRank.Two, CardSuit.Clubs));
            cards.Add(new Card(CardRank.Three, CardSuit.Clubs));
            cards.Add(new Card(CardRank.Four, CardSuit.Clubs));
            cards.Add(new Card(CardRank.Five, CardSuit.Clubs));
            cards.Add(new Card(CardRank.Six, CardSuit.Clubs));
            cards.Add(new Card(CardRank.Seven, CardSuit.Clubs));
            cards.Add(new Card(CardRank.Eight, CardSuit.Clubs));
            cards.Add(new Card(CardRank.Nine, CardSuit.Clubs));
            cards.Add(new Card(CardRank.Ten, CardSuit.Clubs));
            cards.Add(new Card(CardRank.Jack, CardSuit.Clubs));
            cards.Add(new Card(CardRank.Queen, CardSuit.Clubs));
            cards.Add(new Card(CardRank.King, CardSuit.Clubs));

            cards.Add(new Card(CardRank.Ace, CardSuit.Diamonds));
            cards.Add(new Card(CardRank.Two, CardSuit.Diamonds));
            cards.Add(new Card(CardRank.Three, CardSuit.Diamonds));
            cards.Add(new Card(CardRank.Four, CardSuit.Diamonds));
            cards.Add(new Card(CardRank.Five, CardSuit.Diamonds));
            cards.Add(new Card(CardRank.Six, CardSuit.Diamonds));
            cards.Add(new Card(CardRank.Seven, CardSuit.Diamonds));
            cards.Add(new Card(CardRank.Eight, CardSuit.Diamonds));
            cards.Add(new Card(CardRank.Nine, CardSuit.Diamonds));
            cards.Add(new Card(CardRank.Ten, CardSuit.Diamonds));
            cards.Add(new Card(CardRank.Jack, CardSuit.Diamonds));
            cards.Add(new Card(CardRank.Queen, CardSuit.Diamonds));
            cards.Add(new Card(CardRank.King, CardSuit.Diamonds));

            cards.Add(new Card(CardRank.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardRank.Two, CardSuit.Hearts));
            cards.Add(new Card(CardRank.Three, CardSuit.Hearts));
            cards.Add(new Card(CardRank.Four, CardSuit.Hearts));
            cards.Add(new Card(CardRank.Five, CardSuit.Hearts));
            cards.Add(new Card(CardRank.Six, CardSuit.Hearts));
            cards.Add(new Card(CardRank.Seven, CardSuit.Hearts));
            cards.Add(new Card(CardRank.Eight, CardSuit.Hearts));
            cards.Add(new Card(CardRank.Nine, CardSuit.Hearts));
            cards.Add(new Card(CardRank.Ten, CardSuit.Hearts));
            cards.Add(new Card(CardRank.Jack, CardSuit.Hearts));
            cards.Add(new Card(CardRank.Queen, CardSuit.Hearts));
            cards.Add(new Card(CardRank.King, CardSuit.Hearts));

            cards.Add(new Card(CardRank.Ace, CardSuit.Spades));
            cards.Add(new Card(CardRank.Two, CardSuit.Spades));
            cards.Add(new Card(CardRank.Three, CardSuit.Spades));
            cards.Add(new Card(CardRank.Four, CardSuit.Spades));
            cards.Add(new Card(CardRank.Five, CardSuit.Spades));
            cards.Add(new Card(CardRank.Six, CardSuit.Spades));
            cards.Add(new Card(CardRank.Seven, CardSuit.Spades));
            cards.Add(new Card(CardRank.Eight, CardSuit.Spades));
            cards.Add(new Card(CardRank.Nine, CardSuit.Spades));
            cards.Add(new Card(CardRank.Ten, CardSuit.Spades));
            cards.Add(new Card(CardRank.Jack, CardSuit.Spades));
            cards.Add(new Card(CardRank.Queen, CardSuit.Spades));
            cards.Add(new Card(CardRank.King, CardSuit.Spades));

            return cards;
        }
    }
}