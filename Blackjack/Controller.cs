using System;
using System.Collections;
using System.Collections.Generic;

namespace Blackjack
{
    public class Controller
    {
        IInput _input;
        IOutput _output;
        public List<IParticipant> Participants { get; private set; }
        public IDeck Deck { get; private set; }

        public Controller(IInput input, IOutput output, List<IParticipant> players, IDeck deck)
        {
            _input = input;
            _output = output;
            Participants = players;
            Deck = deck;
        }


        // game starts
            // both dealer + player get 2 cards each
        // player's phase of play
            // player chooses to hit repeatedly until
                // they hit blackjack
                // they go bust
                // they choose to stay
        // player has a score
            // they could be <21, blackjack, or bust
            // we only care if the player is bust because dealer's phase of play only goes ahead if player isn't bust
        
        // if player is bust i.e. has score > 21:
            // end game, create gameresult

        // if player isn't bust i.e. has score 2-21:
            // dealer's phase of play
                // dealer chooses to hit repeatedly until
                    // they hit blackjack
                    // they go bust
                    // they choose to stay because score is >= 17
            // if dealer goes bust
                // end game, create gameresult
            // else compare score with player
                // higher score wins, create gameresult
                // same score ties, create gameresult

        // output gameresult

        public void Play()
        {
            _output.WriteLine(Messages.Welcome);
            Deck.Shuffle();
            DealHand();
            // this logic is for player

            var player = Participants[0];
            var choice = Choice.None;
            var playerScore = 0;
            var dealerScore = 0;
            foreach (var participant in Participants) // another word that could be used for both player & dealer
            {
                // specify score for each participant 
                // if (participant == player)
                // {
                //     playerScore = Score.Calculate(player.Hand);
                //     if (Rules.IsBlackjack(playerScore))
                //         _output.Write(String.Format(Messages.Player, Messages.Blackjack));
                //     if (Rules.IsBust(playerScore))
                //         _output.Write(String.Format(Messages.Player, Messages.Bust));
                //     else _output.Write(String.Format(Messages.Player, playerScore));
                //     _output.WriteLine(string.Format(Messages.Hand, OutputFormatter.DisplayHand(player.Hand)));
                // }
                // else
                // {
                //        dealerScore = Score.Calculate(dealer.Hand);
                        // if (Rules.IsBlackjack(dealerScore))
                        //     _output.WriteLine(String.Format(Messages.Dealer, Messages.Blackjack));
                        // if (Rules.IsBust(dealerScore))
                        //     _output.Write(String.Format(Messages.Dealer, Messages.Bust));
                        // else _output.Write(String.Format(Messages.Dealer, dealerScore));
                        // _output.WriteLine(String.Format(Messages.Hand, OutputFormatter.DisplayHand(dealer.Hand)));
                // }
            }
            playerScore = Score.Calculate(player.Hand);
            if (Rules.IsBlackjack(playerScore))
                _output.Write(String.Format(Messages.Player, Messages.Blackjack));
            if (Rules.IsBust(playerScore))
                _output.Write(String.Format(Messages.Player, Messages.Bust));
            else _output.Write(String.Format(Messages.Player, playerScore));
            _output.WriteLine(string.Format(Messages.Hand, OutputFormatter.DisplayHand(player.Hand)));
            do
            {
                _output.Write(Messages.Choice);
                var input = _input.ReadLine();
                var isValid = Validator.IsValid(input);
                while (!isValid)
                {
                    input = _input.ReadLine();
                    isValid = Validator.IsValid(input);
                }
                choice = ChoiceParser.ParseChoice(input);
                if (choice == Choice.Hit) 
                {
                    var playerCard = DealCard(player);
                    _output.WriteLine(String.Format(Messages.PlayerCard, OutputFormatter.DisplayCard(playerCard))); 
                    playerScore = Score.Calculate(player.Hand);
                    if (Rules.IsBlackjack(playerScore)) 
                        _output.Write(String.Format(Messages.Player, Messages.Blackjack));
                    if (Rules.IsBust(playerScore))
                        _output.Write(String.Format(Messages.Player, Messages.Bust));
                    else _output.Write(String.Format(Messages.Player, playerScore));
                    _output.WriteLine(string.Format(Messages.Hand, OutputFormatter.DisplayHand(player.Hand)));
                }
            }
            while (!ShouldTurnEnd(choice, playerScore));

            // different logic for dealer
            var dealer = Participants[1];
            // must hit if score < 17
            dealerScore = Score.Calculate(dealer.Hand);
            if (Rules.IsBlackjack(dealerScore))
                _output.WriteLine(String.Format(Messages.Dealer, Messages.Blackjack));
            if (Rules.IsBust(dealerScore))
                _output.Write(String.Format(Messages.Dealer, Messages.Bust));
            else _output.Write(String.Format(Messages.Dealer, dealerScore));
            _output.WriteLine(String.Format(Messages.Hand, OutputFormatter.DisplayHand(dealer.Hand)));

            do
            {
                choice = Rules.ShouldDealerHitAgain(dealerScore);
                if (choice == Choice.Hit)
                {
                    var dealerCard = DealCard(dealer);
                    _output.WriteLine(String.Format(Messages.DealerCard, OutputFormatter.DisplayCard(dealerCard)));
                    dealerScore = Score.Calculate(dealer.Hand);
                    if (Rules.IsBlackjack(dealerScore))
                        _output.WriteLine(String.Format(Messages.Dealer, Messages.Blackjack));
                    if (Rules.IsBust(dealerScore))
                        _output.Write(String.Format(Messages.Dealer, Messages.Bust));
                    else _output.Write(String.Format(Messages.Dealer, dealerScore));
                    _output.WriteLine(String.Format(Messages.Hand, OutputFormatter.DisplayHand(dealer.Hand)));
                }
            }
            while (!ShouldTurnEnd(choice, dealerScore));
        }

        private void DealHand()
        {
            foreach (var participant in Participants)
            {
                for (int i = 0; i < 2; i++)
                {
                    DealCard(participant);
                }
            }
        }

        private Card DealCard(IParticipant participant) // split out so that when player/dealer 'hit' only one card is given
        {
            var card = Deck.DealCard();
            participant.ReceiveCard(card);
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