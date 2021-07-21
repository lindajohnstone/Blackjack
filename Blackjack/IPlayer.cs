using System.Collections.Generic;

namespace Blackjack
{
    public interface IPlayer
    {
        Hand Hand { get; }
        
        bool ChooseHit();

        bool ChooseStay();

        void ReceiveCard(Card card);
    }
}