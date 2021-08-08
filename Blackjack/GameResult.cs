namespace Blackjack
{
    public enum Outcome
    {
        DealerWin,
        PlayerWin,
        Tie,
        InvalidResult
    }

    public class GameResult
    {
        private IHand _dealerHand;
        private IHand _playerHand;

        public GameResult(IHand dealerHand, IHand playerHand)
        {
            _dealerHand = dealerHand;
            _playerHand = playerHand;
        }

        public int DealerScore { get => Score.Calculate(_dealerHand); }
        public int PlayerScore { get => Score.Calculate(_playerHand); }
        public Outcome Outcome
        {
            get
            {
                if (Rules.IsBust(PlayerScore) && Rules.IsBust(DealerScore)) return Outcome.InvalidResult; 
                if (Rules.IsBust(PlayerScore)) return Outcome.DealerWin;
                if (Rules.IsBust(DealerScore)) return Outcome.PlayerWin;
                if (DealerScore > PlayerScore) return Outcome.DealerWin;
                if (PlayerScore > DealerScore) return Outcome.PlayerWin;
                return Outcome.Tie;
            }
        }
    }
}