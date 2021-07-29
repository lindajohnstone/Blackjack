using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack
{
    public static class OutputFormatter
    {
        public static string DisplayHand(IHand hand)
        {
            var stringBuilder = new StringBuilder();
            var cards = hand.Cards;
            foreach (var card in cards)
            {
                stringBuilder.Append(DisplayCard(card));
                stringBuilder.Append(", ");
            }
            stringBuilder.Length--;
            return stringBuilder.ToString().TrimEnd(',');
        }

        public static string DisplayCard(Card card)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(card.Rank.GetDescription());
            stringBuilder.Append(" of ");
            stringBuilder.Append(card.Suit);
            return stringBuilder.ToString();
        }
    }
}