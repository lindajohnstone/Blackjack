using System;
using System.Collections;
using System.Collections.Generic;

namespace Blackjack
{
    public class Controller
    {
        IInput _input;
        IOutput _output;
        IParticipant _player;
        IParticipant _dealer;
        public Controller(IInput input, IOutput output, IParticipant player, IParticipant dealer, IDeck deck)
        {
            _input = input;
            _output = output;
            _player = player;
            _dealer = dealer;
            Deck = deck;
        }

        public IDeck Deck { get; private set; }

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

            var choice = Choice.None;
            var playerScore = Score.Calculate(_player.Hand);
            
            if (Rules.IsBlackjack(playerScore))
                _output.WriteLine(String.Format(Messages.Player, Messages.Blackjack, OutputFormatter.DisplayHand(_player.Hand)));
            if (Rules.IsBust(playerScore))
                _output.WriteLine(String.Format(Messages.Player, Messages.Bust, OutputFormatter.DisplayHand(_player.Hand)));
            else 
                _output.WriteLine(String.Format(Messages.Player, playerScore, OutputFormatter.DisplayHand(_player.Hand)));
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
                    var playerCard = DealCard(_player);
                    _output.WriteLine(String.Format(Messages.PlayerCard, OutputFormatter.DisplayCard(playerCard))); 
                    playerScore = Score.Calculate(_player.Hand);
                    if (Rules.IsBlackjack(playerScore))
                        _output.WriteLine(String.Format(Messages.Player, Messages.Blackjack, OutputFormatter.DisplayHand(_player.Hand)));
                    if (Rules.IsBust(playerScore))
                        _output.WriteLine(String.Format(Messages.Player, Messages.Bust, OutputFormatter.DisplayHand(_player.Hand)));
                    else 
                        _output.WriteLine(String.Format(Messages.Player, playerScore, OutputFormatter.DisplayHand(_player.Hand)));
                }
            }
            while (!ShouldTurnEnd(choice, playerScore));

            // different logic for dealer
            // must hit if score < 17
            var dealerScore = Score.Calculate(_dealer.Hand);

            if (Rules.IsBlackjack(dealerScore))
                _output.WriteLine(String.Format(Messages.Dealer, Messages.Blackjack, OutputFormatter.DisplayHand(_dealer.Hand)));
            if (Rules.IsBust(dealerScore))
                _output.WriteLine(String.Format(Messages.Dealer, Messages.Bust, OutputFormatter.DisplayHand(_dealer.Hand)));
            else 
                _output.WriteLine(String.Format(Messages.Dealer, dealerScore, OutputFormatter.DisplayHand(_dealer.Hand)));
            do
            {
                choice = Rules.ShouldDealerHitAgain(dealerScore);
                if (choice == Choice.Hit)
                {
                    var dealerCard = DealCard(_dealer);
                    _output.WriteLine(String.Format(Messages.DealerCard, OutputFormatter.DisplayCard(dealerCard)));
                    dealerScore = Score.Calculate(_dealer.Hand);
                    if (Rules.IsBlackjack(dealerScore))
                        _output.WriteLine(String.Format(Messages.Dealer, Messages.Blackjack, OutputFormatter.DisplayHand(_dealer.Hand)));
                    if (Rules.IsBust(dealerScore))
                        _output.WriteLine(String.Format(Messages.Dealer, Messages.Bust, OutputFormatter.DisplayHand(_dealer.Hand)));
                    else 
                        _output.WriteLine(String.Format(Messages.Dealer, dealerScore, OutputFormatter.DisplayHand(_dealer.Hand)));
                }
            }
            while (!ShouldTurnEnd(choice, dealerScore));
        }

        private void DealHand()
        {
            var participants = new List<IParticipant>
            {
                _player,
                _dealer
            };
            foreach (var participant in participants)
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