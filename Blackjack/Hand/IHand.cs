using System.Collections.Generic;

namespace Blackjack
{
    public interface IHand
    {
        List<Card> Cards { get; }
        void AddCard(Card card);
    }
}