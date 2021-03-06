using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Blackjack
{
    [ExcludeFromCodeCoverage]
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
            var deck = new Deck();
            var controller = new Controller(input, output, player, dealer, deck);
            controller.Play(); 
            controller.DisplayGameResult();
        }
    }
}
