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

        public static string GoneBlackjack(int playerScore, int dealerScore) // TODO: ternary operator
        {
            if (IsBlackjack(playerScore) && IsBlackjack(dealerScore)) return Messages.Tie;
            if (IsBlackjack(playerScore)) return Messages.PlayerWins;
            if (IsBlackjack(dealerScore)) return Messages.DealerWins;
            return ""; // TODO: what to return here
        }

        public static string GoneBust(int playerScore, int dealerScore) // TODO: ternary operator
        {
            if (IsBust(playerScore)) return Messages.DealerWins;
            if (IsBust(dealerScore)) return Messages.PlayerWins;
            return "";
        }


        public static string WinningHand(int playerScore, int dealerScore) // TODO: name? // TODO: ternary operator
        {
            if (playerScore > dealerScore) return Messages.PlayerWins;
            if (dealerScore > playerScore) return Messages.DealerWins;
            else return Messages.Tie;
        }
    }
}