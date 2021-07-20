using System;
using Xunit;

namespace Blackjack.Tests
{
    public class ValidatorShould
    {
        [Theory]
        [InlineData("0")]
        [InlineData("1")]
        public void ReturnTrue_GivenValidInput(string input) // TODO string or input as part of name. line 24 also
        {
            var result = Validator.IsValid(input);

            Assert.True(result);
        }

        [Theory]
        [InlineData("a")]
        [InlineData("-11")]
        [InlineData("2")]
        public void ReturnFalse_GivenInvalidInput(string input)
        {
            var result = Validator.IsValid(input);

            Assert.False(result);
        }
    }
}