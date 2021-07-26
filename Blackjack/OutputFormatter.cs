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
                stringBuilder.Append(cards[i].Rank.GetDescription()); 
                stringBuilder.Append(" of ");
                stringBuilder.Append(cards[i].Suit);
                stringBuilder.Append(", ");
            }
            stringBuilder.Length--;
            return stringBuilder.ToString().TrimEnd(',');
        }
    }
}