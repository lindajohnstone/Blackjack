using System.Collections.Generic;

namespace Blackjack
{
    public class Dealer : IPlayer
    {
        public List<Card> Hand { get; private set; }
        public Dealer()
        {
            Hand = new List<Card>();
        }        
        public bool ChooseHit()
        {
            throw new System.NotImplementedException();
        }

        public bool ChooseStay()
        {
            throw new System.NotImplementedException();
        }

        public List<Card> ReceiveCard(Card card)
        {
            Hand.Add(card);
            return Hand;
        }
    }
}