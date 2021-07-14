namespace Blackjack
{
    public interface IPlayer
    {
        public Hand Hand { get; }

        public bool ChooseHit();

        public bool ChooseStay();

    }
}