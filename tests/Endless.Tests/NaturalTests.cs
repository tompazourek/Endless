using System.Linq;
using System.Numerics;
using Xunit;

namespace Endless.Tests
{
    public class NaturalTests
    {
        [Fact]
        public void BigNaturalNumbers_10()
        {
            // act
            var numbers = BigNatural.Numbers.Take(10);

            // assert
            Assert.Equal(new BigInteger[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, numbers);
        }

        [Fact]
        public void BigNaturalNumbersWithZero_10()
        {
            // act
            var numbers = BigNatural.NumbersWithZero.Take(10);

            // assert
            Assert.Equal(new BigInteger[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, numbers);
        }

        [Fact]
        public void NaturalNumbers_10()
        {
            // act
            var numbers = Natural.Numbers.Take(10);

            // assert
            Assert.Equal(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, numbers);
        }

        [Fact]
        public void NaturalNumbersWithZero_10()
        {
            // act
            var numbers = Natural.NumbersWithZero.Take(10);

            // assert
            Assert.Equal(new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, numbers);
        }
    }
}