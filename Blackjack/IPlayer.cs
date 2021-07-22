using System.Collections.Generic;

namespace Blackjack
{
    public interface IPlayer
    {
        IHand Hand { get; }
        
        bool ChooseHit();

        bool ChooseStay();

        void ReceiveCard(Card card);
    }
}