using System.Collections.Generic;

namespace Blackjack
{
    public interface IPlayer
    {
        Hand Hand { get; }
        void ReceiveCard(Card card);

        bool ChooseHit();

        bool ChooseStay();

    }
}