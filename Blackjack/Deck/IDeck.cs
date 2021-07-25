using System.Collections.Generic;

namespace Blackjack
{
    public interface IDeck
    {
        List<Card> Cards { get; }
        void Shuffle();
        Card DealCard();
    }
}