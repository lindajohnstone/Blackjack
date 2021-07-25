using System.Collections.Generic;

namespace Blackjack
{
    public class Dealer : IPlayer
    {
        public IHand Hand { get; private set; }
        public Dealer()
        {
            Hand = new Hand();
        }        

        public void ReceiveCard(Card card)
        {
            throw new System.NotImplementedException();
        }

        public bool Choice()
        {
            throw new System.NotImplementedException();
        }
    }
}