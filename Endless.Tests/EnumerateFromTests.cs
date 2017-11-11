using System;
using System.Linq;
using System.Numerics;
using NUnit.Framework;

namespace Endless.Tests
{
    [TestFixture]
    public class EnumerateFromTests
    {
        [Test]
        public void EnumerateBigInteger_From()
        {
            // act
            var numbers = Enumerate.From(new BigInteger(1)).Take(5);

            // assert
            CollectionAssert.AreEqual(new BigInteger[] { 1, 2, 3, 4, 5 }, numbers);
        }

        [Test]
        public void EnumerateByte_From()
        {
            // act
            var numbers = Enumerate.From((byte)1).Take(5);

            // assert
            CollectionAssert.AreEqual(new byte[] { 1, 2, 3, 4, 5 }, numbers);
        }

        [Test]
        public void EnumerateByte_From_Overflow()
        {
            // act
            var overflow = Enumerate.From((byte)1).ElementAt(255);

            // assert
            Assert.AreEqual(0, overflow);
        }

        [Test]
        public void EnumerateChar_From()
        {
            // act
            var numbers = Enumerate.From('a').Take(5);

            // assert
            CollectionAssert.AreEqual(new[] { 'a', 'b', 'c', 'd', 'e' }, numbers);
        }

        [Test]
        public void EnumerateDateTime_From()
        {
            // act
            var numbers = Enumerate.From(new DateTime(1990, 7, 5)).Take(5);

            // assert
            CollectionAssert.AreEqual(new[] { new DateTime(1990, 7, 5), new DateTime(1990, 7, 6), new DateTime(1990, 7, 7), new DateTime(1990, 7, 8), new DateTime(1990, 7, 9) }, numbers);
        }

        [Test]
        public void EnumerateDateTimeOffset_From()
        {
            // act
            var numbers = Enumerate.From(new DateTimeOffset(1990, 7, 5, 0, 0, 0, 0, TimeSpan.FromHours(2))).Take(5);

            // assert
            CollectionAssert.AreEqual(new[] { new DateTimeOffset(1990, 7, 5, 0, 0, 0, 0, TimeSpan.FromHours(2)), new DateTimeOffset(1990, 7, 6, 0, 0, 0, 0, TimeSpan.FromHours(2)), new DateTimeOffset(1990, 7, 7, 0, 0, 0, 0, TimeSpan.FromHours(2)), new DateTimeOffset(1990, 7, 8, 0, 0, 0, 0, TimeSpan.FromHours(2)), new DateTimeOffset(1990, 7, 9, 0, 0, 0, 0, TimeSpan.FromHours(2)) }, numbers);
        }

        [Test]
        public void EnumerateDecimal_From()
        {
            // act
            var numbers = Enumerate.From((decimal)1).Take(5);

            // assert
            CollectionAssert.AreEqual(new decimal[] { 1, 2, 3, 4, 5 }, numbers);
        }

        [Test]
        public void EnumerateDouble_From()
        {
            // act
            var numbers = Enumerate.From((double)1).Take(5);

            // assert
            CollectionAssert.AreEqual(new double[] { 1, 2, 3, 4, 5 }, numbers);
        }

        [Test]
        public void EnumerateFloat_From()
        {
            // act
            var numbers = Enumerate.From((float)1).Take(5);

            // assert
            CollectionAssert.AreEqual(new float[] { 1, 2, 3, 4, 5 }, numbers);
        }

        [Test]
        public void EnumerateInt_From()
        {
            // act
            var numbers = Enumerate.From(1).Take(5);

            // assert
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5 }, numbers);
        }

        [Test]
        public void EnumerateLong_From()
        {
            // act
            var numbers = Enumerate.From(1L).Take(5);

            // assert
            CollectionAssert.AreEqual(new long[] { 1, 2, 3, 4, 5 }, numbers);
        }
    }
}