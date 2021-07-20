using System.Collections.Generic;

namespace Blackjack
{
    public class Player : IPlayer
    {
        public Hand Hand { get; private set; }
        public Player()
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
    }
}