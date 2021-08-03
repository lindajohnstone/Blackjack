using System.Collections.Generic;

namespace Blackjack.Tests
{
    public class StubOutput : IOutput
    {
        public List<string> OutputList { get; private set; } = new List<string>();

        public void Write(string value)
        {
            OutputList.Add(value);
        }

        public void WriteLine(string value)
        {
            OutputList.Add(value);
        }

        public string GetLastOutput()
        {
            return OutputList[^1];
        }
    }
}