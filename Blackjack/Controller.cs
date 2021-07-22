using System;
using System.Collections.Generic;

namespace Blackjack
{
    public class Controller
    {
        //     1.	Game starts
        //     2.	Deck is created
        //     3.	Deck is shuffled
        //     4.	Player receives Hand of 2 cards = [['ACE', 'HEART '], [4, 'HEART ']]
        //     5.	Score of 15
        //     6.	Dealer receives Hand of 2 cards = [[10, 'CLUB'], [3, 'SPADE']]
        //     7.	Hit or stay? (Hit = 1, Stay = 0) 1
        //     8.	Player draws['QUEEN', 'SPADE']
        //     9.	Player Hand = [['ACE', 'HEART '], [4, 'HEART '], ['QUEEN', 'SPADE']] 
        //     10.	Score of 15
        //     11.	Hit or stay? (Hit = 1, Stay = 0)1
        //     12.	Player draws[2, 'HEART ']
        //     13.	Player Hand = [['ACE', 'HEART '], [4, 'HEART '], ['QUEEN', 'SPADE'], [2, 'HEART ']]
        //     14.	Score of 17
        //     15.	Hit or stay? (Hit = 1, Stay = 0)1
        //     16.	Player draws[3, 'HEART ']
        //     17.	Player Hand = [['ACE', 'HEART '], [4, 'HEART '], ['QUEEN', 'SPADE'], [2, 'HEART '], [3, 'HEART ']]
        //     18.	Score of 20
        //     19.	Hit or stay? (Hit = 1, Stay = 0)0
        //     20.	Dealer is at 13
        //     21.	Dealer score is less than 17
        //     22.	Dealer draws[9, 'SPADE']
        //     23.	Dealer score = 22
        //     24.	Dealer goes ‘bust’
        IInput _input;
        public List<IPlayer> Players { get; private set; }

        public IDeck Deck { get; private set; }

        public Controller(IInput input, List<IPlayer> players, IDeck deck)
        {
            _input = input;
            Players = players;
            Deck = deck; 
        }

        public void Play()
        {
            Deck.Shuffle();
            // deal cards - 2 cards to each player
            DealHand();
            // this logic is for player
            var input = _input.ReadLine();
            var isValid = Validator.IsValid(input);
            while (!isValid)
            {
                input = _input.ReadLine();
                isValid = Validator.IsValid(input);
            }
            // need to assign to a variable so player can either hit or stay
            var choice = ChoiceParser.ParseChoice(input);
            if (choice == Choice.Hit) DealCard(Players[0], Deck.Cards[0]);
            // different logic for dealer
        }

        private void DealHand()
        {
            foreach (var player in Players)
            {
                for (int i = 0; i < 2; i++)
                {
                    var card = Deck.Cards[i];
                    DealCard(player, card);
                }
            }
        }

        private void DealCard(IPlayer player, Card card) // split out so that when player/dealer 'hit' only one card is given
        {
            player.ReceiveCard(card);
            Deck.Cards.Remove(card);
        }
    }
}