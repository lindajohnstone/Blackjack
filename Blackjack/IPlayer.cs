using System.Collections.Generic;

namespace Blackjack
{
    public interface IPlayer
    {
        public List<Card> ReceiveCard(Card card);

        public bool ChooseHit();

        public bool ChooseStay();

    }
}