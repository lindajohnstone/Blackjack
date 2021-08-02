using System.Collections.Generic;

namespace Blackjack
{
    public class Dealer : IParticipant
    {
        public IHand Hand { get; private set; }
        public Dealer(IHand hand)
        {
            Hand = hand;
        }        

        public void ReceiveCard(Card card)
        {
            Hand.AddCard(card);
        }

        public bool Choice()
        {
            throw new System.NotImplementedException();
        }
    }
}