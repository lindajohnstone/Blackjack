using System;
using System.Collections.Generic;

namespace Blackjack
{
    class Program
    {
        static void Main(string[] args)
        {
            // create input
            // create players & list of players
            // create your deck
            // create your controller and pass the input, players, deck into controller
            var input = new ConsoleInput();
            var player = new Player();
            var dealer = new Dealer();
            var players = new List<IPlayer> { player, dealer };
            var deck = new Deck();
            var controller = new Controller(input, players, deck);

        }
    }
}
