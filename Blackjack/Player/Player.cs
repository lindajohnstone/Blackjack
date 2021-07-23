using System.Collections.Generic;

namespace Blackjack
{
    public class Player : IPlayer
    {
        public IHand Hand { get; private set; }
        public Player(IHand hand)
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