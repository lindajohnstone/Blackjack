using System;
using System.Diagnostics.CodeAnalysis;

namespace Blackjack
{
    [ExcludeFromCodeCoverage]
    public class ConsoleInput : IInput
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}