using System;
using System.Numerics;
using NUnit.Framework;

namespace Endless.Tests
{
    [TestFixture]
    public class EnumerateFromToTests
    {
        [Test]
        public void EnumerateBigInteger_FromTo()
        {
            // act
            var numbers = Enumerate.From(new BigInteger(1)).To(5);

            // assert
            CollectionAssert.AreEqual(new BigInteger[] { 1, 2, 3, 4, 5 }, numbers);
        }

        [Test]
        public void EnumerateBigInteger_FromTo_Empty()
        {
            // act
            var numbers = Enumerate.From((BigInteger)5).To(new BigInteger(1));

            // assert
            CollectionAssert.IsEmpty(numbers);
        }

        [Test]
        public void EnumerateByte_FromTo()
        {
            // act
            var numbers = Enumerate.From((byte)1).To(5);

            // assert
            CollectionAssert.AreEqual(new byte[] { 1, 2, 3, 4, 5 }, numbers);
        }

        [Test]
        public void EnumerateByte_FromTo_Empty()
        {
            // act
            var numbers = Enumerate.From((byte)5).To(1);

            // assert
            CollectionAssert.IsEmpty(numbers);
        }

        [Test]
        public void EnumerateChar_FromTo()
        {
            // act
            var numbers = Enumerate.From('a').To('e');

            // assert
            CollectionAssert.AreEqual(new[] { 'a', 'b', 'c', 'd', 'e' }, numbers);
        }

        [Test]
        public void EnumerateChar_FromTo_Empty()
        {
            // act
            var numbers = Enumerate.From('e').To('a');

            // assert
            CollectionAssert.IsEmpty(numbers);
        }

        [Test]
        public void EnumerateDateTime_FromTo()
        {
            // act
            var times = Enumerate
                .From(new DateTime(1990, 7, 5, 12, 00, 00))
                .To(new DateTime(1990, 7, 10, 13, 00, 00));

            // assert
            CollectionAssert.AreEqual(new[]
            {
                new DateTime(1990, 7, 5, 12, 00, 00),
                new DateTime(1990, 7, 6, 12, 00, 00),
                new DateTime(1990, 7, 7, 12, 00, 00),
                new DateTime(1990, 7, 8, 12, 00, 00),
                new DateTime(1990, 7, 9, 12, 00, 00),
                new DateTime(1990, 7, 10, 12, 00, 00)
            }, times);
        }

        [Test]
        public void EnumerateDateTime_FromTo_Empty()
        {
            // act
            var times = Enumerate
                .From(new DateTime(1990, 7, 5, 12, 00, 00))
                .To(new DateTime(1990, 7, 4, 12, 00, 00));

            // assert
            CollectionAssert.IsEmpty(times);
        }

        [Test]
        public void EnumerateDateTimeOffset_FromTo()
        {
            // act
            var times = Enumerate
                .From(new DateTimeOffset(1990, 7, 5, 12, 00, 00, TimeSpan.FromMinutes(30)))
                .To(new DateTimeOffset(1990, 7, 10, 13, 00, 00, TimeSpan.FromMinutes(30)));

            // assert
            CollectionAssert.AreEqual(new[]
            {
                new DateTimeOffset(1990, 7, 5, 12, 00, 00, TimeSpan.FromMinutes(30)),
                new DateTimeOffset(1990, 7, 6, 12, 00, 00, TimeSpan.FromMinutes(30)),
                new DateTimeOffset(1990, 7, 7, 12, 00, 00, TimeSpan.FromMinutes(30)),
                new DateTimeOffset(1990, 7, 8, 12, 00, 00, TimeSpan.FromMinutes(30)),
                new DateTimeOffset(1990, 7, 9, 12, 00, 00, TimeSpan.FromMinutes(30)),
                new DateTimeOffset(1990, 7, 10, 12, 00, 00, TimeSpan.FromMinutes(30))
            }, times);
        }

        [Test]
        public void EnumerateDateTimeOffset_FromTo_Empty()
        {
            // act
            var times = Enumerate
                .From(new DateTimeOffset(1990, 7, 5, 12, 00, 00, TimeSpan.FromMinutes(30)))
                .To(new DateTimeOffset(1990, 7, 4, 12, 00, 00, TimeSpan.FromMinutes(30)));

            // assert
            CollectionAssert.IsEmpty(times);
        }

        [Test]
        public void EnumerateDecimal_FromTo()
        {
            // act
            var numbers = Enumerate.From((decimal)1).To(5);

            // assert
            CollectionAssert.AreEqual(new decimal[] { 1, 2, 3, 4, 5 }, numbers);
        }

        [Test]
        public void EnumerateDecimal_FromTo_Empty()
        {
            // act
            var numbers = Enumerate.From((decimal)5).To(1);

            // assert
            CollectionAssert.IsEmpty(numbers);
        }

        [Test]
        public void EnumerateDecimal_FromTo_Unmet()
        {
            // act
            var numbers = Enumerate.From(1M).To(5.5M);

            // assert
            CollectionAssert.AreEqual(new decimal[] { 1, 2, 3, 4, 5 }, numbers);
        }

        [Test]
        public void EnumerateDouble_FromTo()
        {
            // act
            var numbers = Enumerate.From((double)1).To(5);

            // assert
            CollectionAssert.AreEqual(new double[] { 1, 2, 3, 4, 5 }, numbers);
        }

        [Test]
        public void EnumerateDouble_FromTo_Empty()
        {
            // act
            var numbers = Enumerate.From((double)5).To(1);

            // assert
            CollectionAssert.IsEmpty(numbers);
        }

        [Test]
        public void EnumerateFloat_FromTo()
        {
            // act
            var numbers = Enumerate.From((float)1).To(5);

            // assert
            CollectionAssert.AreEqual(new float[] { 1, 2, 3, 4, 5 }, numbers);
        }

        [Test]
        public void EnumerateFloat_FromTo_Empty()
        {
            // act
            var numbers = Enumerate.From((float)5).To(1);

            // assert
            CollectionAssert.IsEmpty(numbers);
        }

        [Test]
        public void EnumerateInt_FromTo()
        {
            // act
            var numbers = Enumerate.From(1).To(5);

            // assert
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5 }, numbers);
        }

        [Test]
        public void EnumerateInt_FromTo_Empty()
        {
            // act
            var numbers = Enumerate.From(5).To(1);

            // assert
            CollectionAssert.IsEmpty(numbers);
        }

        [Test]
        public void EnumerateLong_FromTo()
        {
            // act
            var numbers = Enumerate.From(1L).To(5);

            // assert
            CollectionAssert.AreEqual(new long[] { 1, 2, 3, 4, 5 }, numbers);
        }

        [Test]
        public void EnumerateLong_FromTo_Empty()
        {
            // act
            var numbers = Enumerate.From((long)5).To(1L);

            // assert
            CollectionAssert.IsEmpty(numbers);
        }
    }
}