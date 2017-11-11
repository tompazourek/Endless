using System;
using System.Numerics;
using NUnit.Framework;

namespace Endless.Tests
{
    [TestFixture]
    [DefaultFloatingPointTolerance(0.01)]
    public class EnumerateFromThenToTests
    {
        [Test]
        public void EnumerateBigInteger_FromThenTo()
        {
            // act
            var numbers = Enumerate.From(new BigInteger(1)).Then(3).To(9);

            // assert
            CollectionAssert.AreEqual(new BigInteger[] { 1, 3, 5, 7, 9 }, numbers);
        }

        [Test]
        public void EnumerateByte_FromThenTo()
        {
            // act
            var numbers = Enumerate.From((byte)1).Then(3).To(9);

            // assert
            CollectionAssert.AreEqual(new byte[] { 1, 3, 5, 7, 9 }, numbers);
        }

        [Test]
        public void EnumerateByte_FromThenTo_Empty()
        {
            // act
            var numbers = Enumerate.From((byte)253).Then(254).To(3);

            // assert
            CollectionAssert.IsEmpty(numbers);
        }

        [Test]
        public void EnumerateChar_FromThenTo()
        {
            // act
            var numbers = Enumerate.From('a').Then('b').To('f');

            // assert
            CollectionAssert.AreEqual(new[] { 'a', 'b', 'c', 'd', 'e', 'f' }, numbers);
        }

        [Test]
        public void EnumerateDateTime_FromThenTo1()
        {
            // act
            var numbers = Enumerate
                .From(new DateTime(1990, 7, 5, 12, 00, 00))
                .Then(new DateTime(1990, 7, 5, 12, 15, 00))
                .To(new DateTime(1990, 7, 5, 13, 00, 00));

            // assert
            CollectionAssert.AreEqual(new[]
            {
                new DateTime(1990, 7, 5, 12, 00, 00),
                new DateTime(1990, 7, 5, 12, 15, 00),
                new DateTime(1990, 7, 5, 12, 30, 00),
                new DateTime(1990, 7, 5, 12, 45, 00),
                new DateTime(1990, 7, 5, 13, 00, 00)
            }, numbers);
        }

        [Test]
        public void EnumerateDateTime_FromThenTo2()
        {
            // act
            var times = Enumerate
                .From(new DateTime(1990, 7, 5, 12, 00, 00))
                .Then(new DateTime(1990, 7, 5, 12, 15, 00))
                .To(new DateTime(1990, 7, 5, 13, 04, 00));

            // assert
            CollectionAssert.AreEqual(new[]
            {
                new DateTime(1990, 7, 5, 12, 00, 00),
                new DateTime(1990, 7, 5, 12, 15, 00),
                new DateTime(1990, 7, 5, 12, 30, 00),
                new DateTime(1990, 7, 5, 12, 45, 00),
                new DateTime(1990, 7, 5, 13, 00, 00)
            }, times);
        }

        [Test]
        public void EnumerateDateTimeOffset_FromThenTo1()
        {
            // act
            var numbers = Enumerate
                .From(new DateTimeOffset(1990, 7, 5, 12, 00, 00, TimeSpan.Zero))
                .Then(new DateTimeOffset(1990, 7, 5, 13, 15, 00, TimeSpan.FromHours(1)))
                .To(new DateTimeOffset(1990, 7, 5, 13, 00, 00, TimeSpan.Zero));

            // assert
            CollectionAssert.AreEqual(new[]
            {
                new DateTimeOffset(1990, 7, 5, 12, 00, 00, TimeSpan.Zero),
                new DateTimeOffset(1990, 7, 5, 12, 15, 00, TimeSpan.Zero),
                new DateTimeOffset(1990, 7, 5, 12, 30, 00, TimeSpan.Zero),
                new DateTimeOffset(1990, 7, 5, 12, 45, 00, TimeSpan.Zero),
                new DateTimeOffset(1990, 7, 5, 13, 00, 00, TimeSpan.Zero)
            }, numbers);
        }

        [Test]
        public void EnumerateDateTimeOffset_FromThenTo2()
        {
            // act
            var times = Enumerate
                .From(new DateTimeOffset(1990, 7, 5, 12, 00, 00, TimeSpan.Zero))
                .Then(new DateTimeOffset(1990, 7, 5, 13, 15, 00, TimeSpan.FromHours(1)))
                .To(new DateTimeOffset(1990, 7, 5, 13, 04, 00, TimeSpan.Zero));

            // assert
            CollectionAssert.AreEqual(new[]
            {
                new DateTimeOffset(1990, 7, 5, 12, 00, 00, TimeSpan.Zero),
                new DateTimeOffset(1990, 7, 5, 12, 15, 00, TimeSpan.Zero),
                new DateTimeOffset(1990, 7, 5, 12, 30, 00, TimeSpan.Zero),
                new DateTimeOffset(1990, 7, 5, 12, 45, 00, TimeSpan.Zero),
                new DateTimeOffset(1990, 7, 5, 13, 00, 00, TimeSpan.Zero)
            }, times);
        }

        [Test]
        public void EnumerateDecimal_FromThenTo()
        {
            // act
            var numbers = Enumerate.From((decimal)1).Then(1.1M).To(2M);

            // assert
            CollectionAssert.AreEqual(new[] { 1, 1.1M, 1.2M, 1.3M, 1.4M, 1.5M, 1.6M, 1.7M, 1.8M, 1.9M, 2M }, numbers);
        }

        [Test]
        public void EnumerateDouble_FromThenTo()
        {
            // act
            var numbers = Enumerate.From(1d).Then(0.5).To(-1);

            // assert
            CollectionAssert.AreEqual(new[] { 1, 0.5, 0, -0.5, -1 }, numbers);
        }

        [Test]
        public void EnumerateFloat_FromThenTo()
        {
            // act
            var numbers = Enumerate.From(1f).Then(10).To(40);

            // assert
            CollectionAssert.AreEqual(new float[] { 1, 10, 19, 28, 37 }, numbers);
        }

        [Test]
        public void EnumerateInt_FromThenTo()
        {
            // act
            var numbers = Enumerate.From(1).Then(-1).To(-10);

            // assert
            CollectionAssert.AreEqual(new[] { 1, -1, -3, -5, -7, -9 }, numbers);
        }

        [Test]
        public void EnumerateLong_FromThenTo()
        {
            // act
            var numbers = Enumerate.From(1L).Then(1).To(1);

            // assert
            CollectionAssert.AreEqual(new long[] { 1 }, numbers);
        }
    }
}