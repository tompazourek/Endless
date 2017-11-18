using System.Linq;
using System.Numerics;
using Xunit;

namespace Endless.Tests
{
    public class BigNaturalTests
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
    }
}