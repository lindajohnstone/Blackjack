using System;
using System.Text;

namespace Blackjack
{
    public static class OutputFormatter
    {
        public static string DisplayHand(Hand hand)
        {
            StringBuilder stringBuilder = new StringBuilder();
            var cards = hand.Cards;
            for (var i = 0; i < hand.Cards.Count; i++)
            {
                stringBuilder.Append(cards[i].Rank); // TODO: cast as int; if statement if face card return the value else int + 1 // check out Yatzy CategoryExtensions
                stringBuilder.Append(" of ");
                stringBuilder.Append(cards[i].Suit);
                stringBuilder.Append(", ");
            }
            return stringBuilder.ToString().Trim(',');
        }
    }
}