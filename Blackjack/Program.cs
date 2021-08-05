using System;
using System.Collections.Generic;

namespace Blackjack
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new ConsoleInput();
            var output = new ConsoleOutput();
            var playerHand = new Hand();
            var player = new Player(playerHand);
            var dealerHand = new Hand();
            var dealer = new Dealer(dealerHand);
            var players = new List<IParticipant> { player, dealer };
            var deck = new Deck();
            var controller = new Controller(input, output, player, dealer, deck);
            controller.Play(); 
            controller.DisplayGameResult();
        }
    }
}
