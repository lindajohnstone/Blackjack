using System;
using Xunit;

namespace Blackjack.Tests
{
    public class InputParserShould
    {
        [Theory]
        [InlineData("0", Choice.Stay)]
        [InlineData("1", Choice.Hit)]
        public void ReturnZeroOrOne_FromValidString(string input, Choice expected) 
        {
            Assert.Equal(expected, InputParser.ParseChoice(input));
        }
    }
}