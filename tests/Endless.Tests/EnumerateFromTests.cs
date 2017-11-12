using System;
using System.Linq;
using System.Numerics;
using Xunit;

namespace Endless.Tests
{
    public class EnumerateFromTests
    {
        [Fact]
        public void EnumerateBigInteger_From()
        {
            // act
            var numbers = Enumerate.From(new BigInteger(1)).Take(5);

            // assert
            Assert.Equal(new BigInteger[] { 1, 2, 3, 4, 5 }, numbers);
        }

        [Fact]
        public void EnumerateByte_From()
        {
            // act
            var numbers = Enumerate.From((byte)1).Take(5);

            // assert
            Assert.Equal(new byte[] { 1, 2, 3, 4, 5 }, numbers);
        }

        [Fact]
        public void EnumerateByte_From_Overflow()
        {
            // act
            var overflow = Enumerate.From((byte)1).ElementAt(255);

            // assert
            Assert.Equal(0, overflow);
        }

        [Fact]
        public void EnumerateChar_From()
        {
            // act
            var numbers = Enumerate.From('a').Take(5);

            // assert
            Assert.Equal(new[] { 'a', 'b', 'c', 'd', 'e' }, numbers);
        }

        [Fact]
        public void EnumerateDateTime_From()
        {
            // act
            var numbers = Enumerate.From(new DateTime(1990, 7, 5)).Take(5);

            // assert
            Assert.Equal(new[] { new DateTime(1990, 7, 5), new DateTime(1990, 7, 6), new DateTime(1990, 7, 7), new DateTime(1990, 7, 8), new DateTime(1990, 7, 9) }, numbers);
        }

        [Fact]
        public void EnumerateDateTimeOffset_From()
        {
            // act
            var numbers = Enumerate.From(new DateTimeOffset(1990, 7, 5, 0, 0, 0, 0, TimeSpan.FromHours(2))).Take(5);

            // assert
            Assert.Equal(new[] { new DateTimeOffset(1990, 7, 5, 0, 0, 0, 0, TimeSpan.FromHours(2)), new DateTimeOffset(1990, 7, 6, 0, 0, 0, 0, TimeSpan.FromHours(2)), new DateTimeOffset(1990, 7, 7, 0, 0, 0, 0, TimeSpan.FromHours(2)), new DateTimeOffset(1990, 7, 8, 0, 0, 0, 0, TimeSpan.FromHours(2)), new DateTimeOffset(1990, 7, 9, 0, 0, 0, 0, TimeSpan.FromHours(2)) }, numbers);
        }

        [Fact]
        public void EnumerateDecimal_From()
        {
            // act
            var numbers = Enumerate.From((decimal)1).Take(5);

            // assert
            Assert.Equal(new decimal[] { 1, 2, 3, 4, 5 }, numbers);
        }

        [Fact]
        public void EnumerateDouble_From()
        {
            // act
            var numbers = Enumerate.From((double)1).Take(5);

            // assert
            Assert.Equal(new double[] { 1, 2, 3, 4, 5 }, numbers);
        }

        [Fact]
        public void EnumerateFloat_From()
        {
            // act
            var numbers = Enumerate.From((float)1).Take(5);

            // assert
            Assert.Equal(new float[] { 1, 2, 3, 4, 5 }, numbers);
        }

        [Fact]
        public void EnumerateInt_From()
        {
            // act
            var numbers = Enumerate.From(1).Take(5);

            // assert
            Assert.Equal(new[] { 1, 2, 3, 4, 5 }, numbers);
        }

        [Fact]
        public void EnumerateLong_From()
        {
            // act
            var numbers = Enumerate.From(1L).Take(5);

            // assert
            Assert.Equal(new long[] { 1, 2, 3, 4, 5 }, numbers);
        }
    }
}