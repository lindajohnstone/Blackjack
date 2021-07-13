namespace Blackjack
{
    public class Card
    {
        public CardRank Rank { get; private set; }
        public CardSuit Suit { get; private set; }
        public Card(CardRank rank, CardSuit suit)
        {
            Rank = rank;
            Suit = suit;
        }
    }
}