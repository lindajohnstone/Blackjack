using System.Collections.Generic;

namespace Blackjack
{
    public class Player : IParticipant
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

        public bool Choice()// ChoiceParser.ParseChoice(input); - string as parameter
        {
            throw new System.NotImplementedException();
        }
    }
}