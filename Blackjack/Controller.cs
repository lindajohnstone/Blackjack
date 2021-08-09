using System;

namespace Blackjack
{
    public class Controller
    {
        IInput _input;
        IOutput _output;
        IParticipant _player;
        IParticipant _dealer;
        GameResult _gameResult;
        public Controller(IInput input, IOutput output, IParticipant player, IParticipant dealer, IDeck deck)
        {
            _input = input;
            _output = output;
            _player = player;
            _dealer = dealer;
            Deck = deck;
            _gameResult = new GameResult(_dealer.Hand, _player.Hand);
        }

        public IDeck Deck { get; private set; }

        public GameResult Play()
        {
            _output.WriteLine(Messages.Welcome);
            Deck.Shuffle();
            DealHand(_player);
            DealHand(_dealer);

            var choice = Choice.None;

            var playerScore = Score.Calculate(_player.Hand);
            var dealerScore = Score.Calculate(_dealer.Hand);
            DisplayInformation(_player, playerScore);

            do
            {
                if (Rules.IsBlackjack(playerScore))
                {
                    break;
                }
                choice = GetPlayerChoice();
                if (choice == Choice.Hit)
                {
                    var playerCard = DealCard(_player);
                    _output.WriteLine(String.Format(Messages.PlayerCard, OutputFormatter.DisplayCard(playerCard)));
                    playerScore = Score.Calculate(_player.Hand);
                    DisplayInformation(_player, playerScore);
                }
            } while (!ShouldTurnEnd(choice, playerScore));

            if (ShouldGameEnd(playerScore, dealerScore))
            {
                return new GameResult(_dealer.Hand, _player.Hand);
            }

            DisplayInformation(_dealer, dealerScore);
            do
            {
                choice = Rules.ShouldDealerHitAgain(dealerScore);
                if (choice == Choice.Hit)
                {
                    var dealerCard = DealCard(_dealer);
                    _output.WriteLine(String.Format(Messages.DealerCard, OutputFormatter.DisplayCard(dealerCard)));
                    dealerScore = Score.Calculate(_dealer.Hand);
                    DisplayInformation(_dealer, dealerScore);
                }
            } while (!ShouldTurnEnd(choice, dealerScore));

            return new GameResult(_dealer.Hand, _player.Hand);
        }

        private void DealHand(IParticipant participant)
        {
            for (int i = 0; i < 2; i++)
            {
                DealCard(participant);
            }
        }

        private Card DealCard(IParticipant participant) // split out so that when player/dealer 'hit' only one card is given
        {
            var card = Deck.DealCard();
            participant.ReceiveCard(card);
            return card;
        }

        private void DisplayInformation(IParticipant participant, int score)
        {
            var message = "";
            message = participant == _player ? Messages.Player : Messages.Dealer;
            if (Rules.IsBlackjack(score))
            {
                _output.WriteLine(String.Format(message, Messages.Blackjack, OutputFormatter.DisplayHand(participant.Hand)));
                return;
            }
            if (Rules.IsBust(score))
            {
                _output.WriteLine(String.Format(message, Messages.Bust, OutputFormatter.DisplayHand(participant.Hand)));
                return;
            }
            _output.WriteLine(String.Format(message, score, OutputFormatter.DisplayHand(participant.Hand)));
        }

        private Choice GetPlayerChoice()
        {
            Choice choice;
            _output.Write(Messages.Choice);
            var input = _input.ReadLine();
            var isValid = Validator.IsValid(input);
            while (!isValid)
            {
                input = _input.ReadLine();
                isValid = Validator.IsValid(input);
            }
            choice = ChoiceParser.ParseChoice(input);
            return choice;
        }

        private bool ShouldTurnEnd(Choice choice, int score)
        {
            if (choice == Choice.Stay) return true;
            if (Rules.IsBlackjack(score)) return true;
            if (Rules.IsBust(score)) return true;
            return false;
        }

        private bool ShouldGameEnd(int playerScore, int dealerScore)
        {
            if (Rules.IsBust(playerScore)) return true;
            if (Rules.IsBust(dealerScore)) return true;
            return false;
        }

        public void DisplayGameResult()
        {
            if (_gameResult.Outcome == Outcome.DealerWin)
            {
                _output.WriteLine(Messages.DealerWins);
                _output.WriteLine(Messages.GameOver);
            }
            if (_gameResult.Outcome == Outcome.PlayerWin)
            {
                _output.WriteLine(Messages.PlayerWins);
                _output.WriteLine(Messages.GameOver);
            }
            else if (_gameResult.Outcome == Outcome.Tie)
            {
                _output.WriteLine(Messages.Tie);
                _output.WriteLine(Messages.GameOver);
            }
        }
    }
}