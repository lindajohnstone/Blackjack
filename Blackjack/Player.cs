namespace Blackjack
{
    public class Player : IPlayer
    {
        public Hand Hand { get; private set; }
        public Player()
        {
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