using System.Collections.Generic;

namespace Blackjack
{
    public interface IDeck
    {
        public List<Card> Cards { get; }
        Deck Shuffle();
    }
}