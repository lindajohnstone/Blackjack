using System.Collections.Generic;

namespace Blackjack
{
    public class Dealer : IPlayer
    {
        public Hand Hand { get; private set; }
        public Dealer()
        {
            Hand = new Hand();
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