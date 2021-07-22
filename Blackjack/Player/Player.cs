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

        public bool ChooseHit()
        {
            throw new System.NotImplementedException();
        }

        public bool ChooseStay()
        {
            throw new System.NotImplementedException();
        }

        public void ReceiveCard(Card card)
        {
            Hand.AddCard(card);
        }
    }
}