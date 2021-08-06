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
                if (PlayerScore > 21 && DealerScore > 21) return Outcome.InvalidResult; // TODO: test this // TODO: use Rules
                if (PlayerScore > 21) return Outcome.DealerWin;
                if (DealerScore > 21) return Outcome.PlayerWin;
                if (DealerScore > PlayerScore) return Outcome.DealerWin;
                if (PlayerScore > DealerScore) return Outcome.PlayerWin;
                return Outcome.Tie;
            }
        }
    }
}