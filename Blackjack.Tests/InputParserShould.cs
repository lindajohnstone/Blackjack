using System;
using Xunit;

namespace Blackjack.Tests
{
    public class InputParserShould
    {
        [Theory]
        [InlineData("0", 0)]
        [InlineData("1", 1)]
        public void ReturnZeroOrOne_FromValidString(string input, int expected) 
        {
            Assert.Equal(expected, InputParser.ParseChoice(input));
        }
    }
}