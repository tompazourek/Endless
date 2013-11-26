﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
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
            IEnumerable<BigInteger> numbers = Enumerate.From(new BigInteger(1)).Take(5);

            // assert
            CollectionAssert.AreEqual(new BigInteger[] { 1, 2, 3, 4, 5 }, numbers);
        }

        [Test]
        public void EnumerateByte_From()
        {
            // act
            IEnumerable<byte> numbers = Enumerate.From((byte) 1).Take(5);

            // assert
            CollectionAssert.AreEqual(new byte[] { 1, 2, 3, 4, 5 }, numbers);
        }

        [Test]
        public void EnumerateByte_From_Overflow()
        {
            // act
            byte overflow = Enumerate.From((byte) 1).ElementAt(255);

            // assert
            Assert.AreEqual(0, overflow);
        }

        [Test]
        public void EnumerateChar_From()
        {
            // act
            IEnumerable<char> numbers = Enumerate.From('a').Take(5);

            // assert
            CollectionAssert.AreEqual(new[] { 'a', 'b', 'c', 'd', 'e' }, numbers);
        }

        [Test]
        public void EnumerateDecimal_From()
        {
            // act
            IEnumerable<decimal> numbers = Enumerate.From((decimal) 1).Take(5);

            // assert
            CollectionAssert.AreEqual(new decimal[] { 1, 2, 3, 4, 5 }, numbers);
        }

        [Test]
        public void EnumerateDouble_From()
        {
            // act
            IEnumerable<double> numbers = Enumerate.From((double) 1).Take(5);

            // assert
            CollectionAssert.AreEqual(new double[] { 1, 2, 3, 4, 5 }, numbers);
        }

        [Test]
        public void EnumerateFloat_From()
        {
            // act
            IEnumerable<float> numbers = Enumerate.From((float) 1).Take(5);

            // assert
            CollectionAssert.AreEqual(new float[] { 1, 2, 3, 4, 5 }, numbers);
        }

        [Test]
        public void EnumerateInt_From()
        {
            // act
            IEnumerable<int> numbers = Enumerate.From(1).Take(5);

            // assert
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5 }, numbers);
        }

        [Test]
        public void EnumerateLong_From()
        {
            // act
            IEnumerable<long> numbers = Enumerate.From(1L).Take(5);

            // assert
            CollectionAssert.AreEqual(new long[] { 1, 2, 3, 4, 5 }, numbers);
        }
    }
}