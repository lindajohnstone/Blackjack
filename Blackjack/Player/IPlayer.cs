using System.Collections.Generic;

namespace Blackjack
{
    public interface IParticipant
    {
        IHand Hand { get; }
        
        bool Choice();

        void ReceiveCard(Card card);
    }
}