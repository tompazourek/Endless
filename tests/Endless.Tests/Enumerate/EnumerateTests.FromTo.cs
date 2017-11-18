using System;
using System.Numerics;
using Xunit;

namespace Endless.Tests
{
    public partial class EnumerateTests
    {
        [Fact]
        public void EnumerateBigInteger_FromTo()
        {
            // act
            var numbers = Enumerate.From(new BigInteger(1)).To(5);

            // assert
            Assert.Equal(new BigInteger[] { 1, 2, 3, 4, 5 }, numbers);
        }

        [Fact]
        public void EnumerateBigInteger_FromTo_Empty()
        {
            // act
            var numbers = Enumerate.From((BigInteger)5).To(new BigInteger(1));

            // assert
            Assert.Empty(numbers);
        }

        [Fact]
        public void EnumerateByte_FromTo()
        {
            // act
            var numbers = Enumerate.From((byte)1).To(5);

            // assert
            Assert.Equal(new byte[] { 1, 2, 3, 4, 5 }, numbers);
        }

        [Fact]
        public void EnumerateByte_FromTo_Empty()
        {
            // act
            var numbers = Enumerate.From((byte)5).To(1);

            // assert
            Assert.Empty(numbers);
        }

        [Fact]
        public void EnumerateChar_FromTo()
        {
            // act
            var numbers = Enumerate.From('a').To('e');

            // assert
            Assert.Equal(new[] { 'a', 'b', 'c', 'd', 'e' }, numbers);
        }

        [Fact]
        public void EnumerateChar_FromTo_Empty()
        {
            // act
            var numbers = Enumerate.From('e').To('a');

            // assert
            Assert.Empty(numbers);
        }

        [Fact]
        public void EnumerateDateTime_FromTo()
        {
            // act
            var times = Enumerate
                .From(new DateTime(1990, 7, 5, 12, 00, 00))
                .To(new DateTime(1990, 7, 10, 13, 00, 00));

            // assert
            Assert.Equal(new[]
            {
                new DateTime(1990, 7, 5, 12, 00, 00),
                new DateTime(1990, 7, 6, 12, 00, 00),
                new DateTime(1990, 7, 7, 12, 00, 00),
                new DateTime(1990, 7, 8, 12, 00, 00),
                new DateTime(1990, 7, 9, 12, 00, 00),
                new DateTime(1990, 7, 10, 12, 00, 00)
            }, times);
        }

        [Fact]
        public void EnumerateDateTime_FromTo_Empty()
        {
            // act
            var times = Enumerate
                .From(new DateTime(1990, 7, 5, 12, 00, 00))
                .To(new DateTime(1990, 7, 4, 12, 00, 00));

            // assert
            Assert.Empty(times);
        }

        [Fact]
        public void EnumerateDateTimeOffset_FromTo()
        {
            // act
            var times = Enumerate
                .From(new DateTimeOffset(1990, 7, 5, 12, 00, 00, TimeSpan.FromMinutes(30)))
                .To(new DateTimeOffset(1990, 7, 10, 13, 00, 00, TimeSpan.FromMinutes(30)));

            // assert
            Assert.Equal(new[]
            {
                new DateTimeOffset(1990, 7, 5, 12, 00, 00, TimeSpan.FromMinutes(30)),
                new DateTimeOffset(1990, 7, 6, 12, 00, 00, TimeSpan.FromMinutes(30)),
                new DateTimeOffset(1990, 7, 7, 12, 00, 00, TimeSpan.FromMinutes(30)),
                new DateTimeOffset(1990, 7, 8, 12, 00, 00, TimeSpan.FromMinutes(30)),
                new DateTimeOffset(1990, 7, 9, 12, 00, 00, TimeSpan.FromMinutes(30)),
                new DateTimeOffset(1990, 7, 10, 12, 00, 00, TimeSpan.FromMinutes(30))
            }, times);
        }

        [Fact]
        public void EnumerateDateTimeOffset_FromTo_Empty()
        {
            // act
            var times = Enumerate
                .From(new DateTimeOffset(1990, 7, 5, 12, 00, 00, TimeSpan.FromMinutes(30)))
                .To(new DateTimeOffset(1990, 7, 4, 12, 00, 00, TimeSpan.FromMinutes(30)));

            // assert
            Assert.Empty(times);
        }

        [Fact]
        public void EnumerateDecimal_FromTo()
        {
            // act
            var numbers = Enumerate.From((decimal)1).To(5);

            // assert
            Assert.Equal(new decimal[] { 1, 2, 3, 4, 5 }, numbers);
        }

        [Fact]
        public void EnumerateDecimal_FromTo_Empty()
        {
            // act
            var numbers = Enumerate.From((decimal)5).To(1);

            // assert
            Assert.Empty(numbers);
        }

        [Fact]
        public void EnumerateDecimal_FromTo_Unmet()
        {
            // act
            var numbers = Enumerate.From(1M).To(5.5M);

            // assert
            Assert.Equal(new decimal[] { 1, 2, 3, 4, 5 }, numbers);
        }

        [Fact]
        public void EnumerateDouble_FromTo()
        {
            // act
            var numbers = Enumerate.From((double)1).To(5);

            // assert
            Assert.Equal(new double[] { 1, 2, 3, 4, 5 }, numbers);
        }

        [Fact]
        public void EnumerateDouble_FromTo_Empty()
        {
            // act
            var numbers = Enumerate.From((double)5).To(1);

            // assert
            Assert.Empty(numbers);
        }

        [Fact]
        public void EnumerateFloat_FromTo()
        {
            // act
            var numbers = Enumerate.From((float)1).To(5);

            // assert
            Assert.Equal(new float[] { 1, 2, 3, 4, 5 }, numbers);
        }

        [Fact]
        public void EnumerateFloat_FromTo_Empty()
        {
            // act
            var numbers = Enumerate.From((float)5).To(1);

            // assert
            Assert.Empty(numbers);
        }

        [Fact]
        public void EnumerateInt_FromTo()
        {
            // act
            var numbers = Enumerate.From(1).To(5);

            // assert
            Assert.Equal(new[] { 1, 2, 3, 4, 5 }, numbers);
        }

        [Fact]
        public void EnumerateInt_FromTo_Empty()
        {
            // act
            var numbers = Enumerate.From(5).To(1);

            // assert
            Assert.Empty(numbers);
        }

        [Fact]
        public void EnumerateLong_FromTo()
        {
            // act
            var numbers = Enumerate.From(1L).To(5);

            // assert
            Assert.Equal(new long[] { 1, 2, 3, 4, 5 }, numbers);
        }

        [Fact]
        public void EnumerateLong_FromTo_Empty()
        {
            // act
            var numbers = Enumerate.From((long)5).To(1L);

            // assert
            Assert.Empty(numbers);
        }
    }
}