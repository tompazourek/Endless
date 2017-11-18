using System;
using System.Linq;
using System.Numerics;
using Xunit;

namespace Endless.Tests
{
    public partial class EnumerableExtensionsTests
    {
        [Fact]
        public void Max()
        {
            // arrange
            var bigNumber = new BigInteger(long.MaxValue);
            var bigNumbers = new[] { bigNumber + 1, bigNumber + 3, bigNumber + 5, bigNumber + 10 };

            // act
            var max = bigNumbers.Max();

            // assert
            Assert.Equal(bigNumber + 10, max);
        }

        [Fact]
        public void Max_Empty()
        {
            // arrange
            var bigNumbers = Enumerable.Empty<BigInteger>();

            // act & assert
            Assert.Throws<InvalidOperationException>(() => bigNumbers.Max());
        }

        [Fact]
        public void Max_Nullable()
        {
            // arrange
            var bigNumber = new BigInteger(long.MaxValue);
            var bigNumbers = new BigInteger?[] { bigNumber + 1, null, bigNumber + 3, bigNumber + 5, bigNumber + 10 };

            // act
            var max = bigNumbers.Max();

            // assert
            Assert.Equal(bigNumber + 10, max);
        }

        [Fact]
        public void Max_Nullable_Empty()
        {
            // arrange
            var bigNumbers = Enumerable.Empty<BigInteger?>();

            // act
            var max = bigNumbers.Max();

            // assert
            Assert.Null(max);
        }

        [Fact]
        public void Min()
        {
            // arrange
            var bigNumber = new BigInteger(long.MaxValue);
            var bigNumbers = new[] { bigNumber + 1, bigNumber + 3, bigNumber + 5, bigNumber + 10 };

            // act
            var min = bigNumbers.Min();

            // assert
            Assert.Equal(bigNumber + 1, min);
        }

        [Fact]
        public void Min_Empty()
        {
            // arrange
            var bigNumbers = Enumerable.Empty<BigInteger>();

            // act & assert
            Assert.Throws<InvalidOperationException>(() => bigNumbers.Min());
        }

        [Fact]
        public void Min_Nullable()
        {
            // arrange
            var bigNumber = new BigInteger(long.MaxValue);
            var bigNumbers = new BigInteger?[] { bigNumber + 1, null, bigNumber + 3, bigNumber + 5, bigNumber + 10 };

            // act
            var min = bigNumbers.Min();

            // assert
            Assert.Equal(bigNumber + 1, min);
        }

        [Fact]
        public void Min_Nullable_Empty()
        {
            // arrange
            var bigNumbers = Enumerable.Empty<BigInteger?>();

            // act
            var min = bigNumbers.Min();

            // assert
            Assert.Null(min);
        }

        [Fact]
        public void Sum()
        {
            // arrange
            var bigNumber = new BigInteger(long.MaxValue);
            var bigNumbers = bigNumber.Repeat().Take(10);

            // act
            var sum = bigNumbers.Sum();

            // assert
            Assert.Equal(bigNumber * 10, sum);
        }

        [Fact]
        public void Sum_Nullable()
        {
            // arrange
            var bigNumber = new BigInteger(long.MaxValue);
            var bigNumbers = new BigInteger?[] { bigNumber, null, bigNumber, bigNumber, null, null, bigNumber };

            // act
            var sum = bigNumbers.Sum();

            // assert
            Assert.Equal(bigNumber * 4, sum);
        }
    }
}