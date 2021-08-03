using System;

namespace Blackjack
{
    public static class Rules
    {
        // Blackjack if score == 21
        // Bust if score > 21
        // Dealer must 'hit' if score < 17
        // If the player has blackjack, they win, unless the dealer also has blackjack, in which case the game is a tie.
        // If the dealer busts and the player doesn't, the player wins.
        // If the player busts, the dealer wins.
        // If the player and the dealer both don't bust, whoever is closest to 21 wins.
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