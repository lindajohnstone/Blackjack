using System;
using System.Collections;
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
        IOutput _output;
        public List<IPlayer> Players { get; private set; }
        public IDeck Deck { get; private set; }

        public Controller(IInput input, IOutput output, List<IPlayer> players, IDeck deck)
        {
            _input = input;
            _output = output;
            Players = players;
            Deck = deck;
        }

        public void Play()
        {
            // game starts
            _output.WriteLine(Messages.Welcome);
            // deck shuffled
            Deck.Shuffle();
            // deal cards - 2 cards to each player
            DealHand();
            // this logic is for player
            var player = Players[0];
            var choice = Choice.None;
            var playerScore = Score.Calculate(player.Hand);
            _output.WriteLine(String.Format(Messages.PlayerScore, playerScore, OutputFormatter.DisplayHand(player.Hand)));
            do
            {
                _output.Write(Messages.Choice);
                // receive input
                var input = _input.ReadLine();
                // validate input
                var isValid = Validator.IsValid(input);
                while (!isValid)
                {
                    input = _input.ReadLine();
                    isValid = Validator.IsValid(input);
                }
                // parse input
                choice = ChoiceParser.ParseChoice(input);
                if (choice == Choice.Hit) 
                {
                    var playerCard = DealCard(player);
                    _output.WriteLine(String.Format(Messages.PlayerCard, OutputFormatter.DisplayCard(playerCard))); 
                }
                // calculate players score
                playerScore = Score.Calculate(player.Hand);
                _output.WriteLine(String.Format(Messages.PlayerScore, playerScore, OutputFormatter.DisplayHand(player.Hand)));
            }
            while (!ShouldTurnEnd(choice, playerScore));

            // different logic for dealer
            var dealer = Players[1];
            // must hit if score < 17
            var dealerScore = Score.Calculate(dealer.Hand);
            _output.WriteLine(String.Format(Messages.DealerScore, dealerScore, OutputFormatter.DisplayHand(dealer.Hand)));
            do
            {
                choice = Rules.ShouldDealerHitAgain(dealerScore);
                if (choice == Choice.Hit)
                {
                    var dealerCard = DealCard(dealer);
                    _output.WriteLine(String.Format(Messages.DealerCard, OutputFormatter.DisplayCard(dealerCard)));
                    dealerScore = Score.Calculate(dealer.Hand);
                    _output.WriteLine(String.Format(Messages.DealerScore, dealerScore, OutputFormatter.DisplayHand(dealer.Hand)));
                }
            } 
            while (!ShouldTurnEnd(choice, dealerScore));
        }

        private void DealHand()
        {
            foreach (var player in Players)
            {
                for (int i = 0; i < 2; i++)
                {
                    DealCard(player);
                }
            }
        }

        private Card DealCard(IPlayer player) // split out so that when player/dealer 'hit' only one card is given
        {
            var card = Deck.DealCard();
            player.ReceiveCard(card);
            return card;
        }

        private bool ShouldTurnEnd(Choice choice, int score)
        {
            if (choice == Choice.Stay ) return true; 
            if (Rules.IsBlackjack(score)) return true;
            if (Rules.IsBust(score)) return true;
            return false;
        }
    }
}