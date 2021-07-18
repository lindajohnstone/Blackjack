using System.Collections.Generic;

namespace Blackjack
{
    public interface IPlayer
    {
        List<Card> Hand { get; }
        void ReceiveCard(Card card);

        bool ChooseHit();

        bool ChooseStay();

    }
}