using System;
using System.Collections.Generic;

namespace Blackjack
{
    public class Controller
    {
        //     1.	Game starts
        //     2.	Deck is created
        //     3.	Deck is shuffled
        //     4.	Player receives Hand of 2 cards = [['ACE', 'HEART '], [4, 'HEART ']]
        //     5.	Score of 15
        //     6.	Dealer receives Hand of 2 cards = [[10, 'CLUB'], [3, 'SPADE']]
        //     7.	Hit or stay? (Hit = 1, Stay = 0) 1
        //     8.	Player draws['QUEEN', 'SPADE']
        //     9.	Player Hand = [['ACE', 'HEART '], [4, 'HEART '], ['QUEEN', 'SPADE']] 
        //     10.	Score of 15
        //     11.	Hit or stay? (Hit = 1, Stay = 0)1
        //     12.	Player draws[2, 'HEART ']
        //     13.	Player Hand = [['ACE', 'HEART '], [4, 'HEART '], ['QUEEN', 'SPADE'], [2, 'HEART ']]
        //     14.	Score of 17
        //     15.	Hit or stay? (Hit = 1, Stay = 0)1
        //     16.	Player draws[3, 'HEART ']
        //     17.	Player Hand = [['ACE', 'HEART '], [4, 'HEART '], ['QUEEN', 'SPADE'], [2, 'HEART '], [3, 'HEART ']]
        //     18.	Score of 20
        //     19.	Hit or stay? (Hit = 1, Stay = 0)0
        //     20.	Dealer is at 13
        //     21.	Dealer score is less than 17
        //     22.	Dealer draws[9, 'SPADE']
        //     23.	Dealer score = 22
        //     24.	Dealer goes ‘bust’
        IInput _input;
        public List<IPlayer> Players { get; private set; }

        public Deck Deck { get; private set; }

        public Controller(IInput input)
        {
            _input = input;
            Initialize();
        }

        private void Initialize()
        {
            Deck = new Deck(new List<Card>());
            Players = GetPlayers();
        }

        private List<IPlayer> GetPlayers()
        {
            return Players = new List<IPlayer> { new Player(), new Dealer() };
        }

        public void Play()
        {
            var shuffledDeck = Shuffle();
            // deal cards - 2 cards to each player
            Deal(shuffledDeck);
            var input = _input.ReadLine();
            var isValid = Validator.IsValid(input);

            while (!isValid)
            {
                input = _input.ReadLine();
                isValid = Validator.IsValid(input);
            }
            ChoiceParser.ParseChoice(input);
        }

        private Deck Shuffle() 
        {
            // based on Fisher-Yates Shuffle algorithm
            var count = Deck.Cards.Count;
            Random rand = new Random();
            var shuffledDeck = new Deck(new List<Card>());

            for (int i = count - 1; i > 0; i--)
            {
                int j = rand.Next(0, i + 1);

                var temp = Deck.Cards[i];
                Deck.Cards[i] = shuffledDeck.Cards[j];
                Deck.Cards[j] = temp;
            }
            return shuffledDeck;
        }

        private void Deal(Deck shuffledDeck)
        {
            var index = 0;
            foreach (var player in Players)
            {
                for (int i = 0; i < 2; i++)
                {
                    player.Hand.AddCard(shuffledDeck.Cards[index]);
                    index++;
                }
            }
        }
    }
}