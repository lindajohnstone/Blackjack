namespace Blackjack.Tests
{
    public class StubInput : IInput
    {
        public string ReadLine()
        {
            throw new System.NotImplementedException();
        }
    }
}