using System.Collections.Generic;

namespace Blackjack
{
    public interface IPlayer
    {
        IHand Hand { get; }
        
        bool Choice();

        void ReceiveCard(Card card);
    }
}