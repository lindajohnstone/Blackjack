using System;

namespace Blackjack
{
    public static class Rules
    {
        // Blackjack if score == 21
        // Bust if score > 21
        // Dealer must 'hit' if score < 17
        public static bool IsBust(int score)
        {
            return score > 21 ? true : false;
        }

        public static bool IsBlackjack(int score)
        {
            return score == 21 ? true : false;
        }

        public static Choice ShouldDealerHitAgain(int score)
        {
            return score < 17 ? Choice.Hit : Choice.Stay;
        }
    }
}