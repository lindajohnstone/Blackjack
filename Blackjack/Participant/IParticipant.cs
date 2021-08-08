using System.Collections.Generic;

namespace Blackjack
{
    public interface IParticipant
    {
        IHand Hand { get; }

        void ReceiveCard(Card card);
    }
}