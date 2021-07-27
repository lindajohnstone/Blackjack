namespace Blackjack
{
    public static class Score
    {
        public static int Calculate(Hand hand)
        {
            var sum = 0;
            var aceCount = 0;
            foreach (Card card in hand.Cards)
            {
                var rank = (int)card.Rank;
                if (rank > 1 && rank <= 10) sum += rank;
                if (rank > 10) sum += 10;
                if (rank == 1) 
                {
                    sum += 1;
                    aceCount++;   
                }
            }
            for (var count = 0; count <= aceCount; count++)
            {
                if (sum <= 11 && aceCount > 0)
                {
                    sum += 10;
                    aceCount--;
                    if (sum > 21) sum -= 10;
                }
            }
            return sum;
        }
    }
}