namespace Blackjack.Tests
{
    public static class GameResultHelper
    {
        public static bool GameResultsAreEqual(GameResult gameResult1, GameResult gameResult2)
        {
            if (gameResult1 == null || gameResult2 == null) return false;
            if (gameResult1.DealerScore != gameResult2.DealerScore) return false;
            if (gameResult1.Outcome != gameResult2.Outcome) return false;
            if (gameResult1.PlayerScore != gameResult2.PlayerScore) return false;
            return true;
        }
    }
}