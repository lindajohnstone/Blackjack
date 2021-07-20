using System;
using Xunit;

namespace Blackjack.Tests
{
    public class ValidatorShould
    {
        [Theory]
        [InlineData("0")]
        [InlineData("1")]
        public void ReturnTrue_GivenValidString(string input) 
        {
            var result = Validator.IsValid(input);

            Assert.True(result);
        }

        [Theory]
        [InlineData("a")]
        [InlineData("-11")]
        [InlineData("2")]
        public void ReturnFalse_GivenInvalidString(string input)
        {
            var result = Validator.IsValid(input);

            Assert.False(result);
        }
    }
}