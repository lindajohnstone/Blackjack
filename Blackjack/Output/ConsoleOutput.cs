using System;
using System.Diagnostics.CodeAnalysis;

namespace Blackjack
{
    [ExcludeFromCodeCoverage]
    public class ConsoleOutput : IOutput
    {
        public void WriteLine(string value)
        {
            Console.WriteLine(value);
        }

        public void Write(string value)
        {
            Console.Write(value);
        }
    }
}