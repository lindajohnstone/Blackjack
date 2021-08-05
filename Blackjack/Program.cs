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
            var output = new ConsoleOutput();
            var playerHand = new Hand();
            var player = new Player(playerHand);
            var dealerHand = new Hand();
            var dealer = new Dealer(dealerHand);
            var players = new List<IParticipant> { player, dealer };
            var deck = new Deck();
            var controller = new Controller(input, output, player, dealer, deck);
            controller.Play(); // TODO: should lines 23 - 24 be a method on Controller?
            controller.DisplayGameResult();
        }
    }
}
