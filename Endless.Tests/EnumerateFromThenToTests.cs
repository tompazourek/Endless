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
    public class EnumerateFromThenToTests
    {
        [TestFixtureSetUp]
        public void RunBeforeAnyTest()
        {
            GlobalSettings.DefaultFloatingPointTolerance = 0.01;
        }

        [Test]
        public void EnumerateBigInteger_FromThenTo()
        {
            // act
            IEnumerable<BigInteger> numbers = Enumerate.From(new BigInteger(1)).Then(3).To(9);

            // assert
            CollectionAssert.AreEqual(new BigInteger[] { 1, 3, 5, 7, 9 }, numbers);
        }

        [Test]
        public void EnumerateByte_FromThenTo()
        {
            // act
            IEnumerable<byte> numbers = Enumerate.From((byte) 1).Then(3).To(9);

            // assert
            CollectionAssert.AreEqual(new byte[] { 1, 3, 5, 7, 9 }, numbers);
        }

        [Test]
        public void EnumerateByte_FromThenTo_Empty()
        {
            // act
            IEnumerable<byte> numbers = Enumerate.From((byte) 253).Then(254).To(3);

            // assert
            CollectionAssert.IsEmpty(numbers);
        }

        [Test]
        public void EnumerateChar_FromThenTo()
        {
            // act
            IEnumerable<char> numbers = Enumerate.From('a').Then('b').To('f');

            // assert
            CollectionAssert.AreEqual(new[] { 'a', 'b', 'c', 'd', 'e', 'f' }, numbers);
        }

        [Test]
        public void EnumerateDecimal_FromThenTo()
        {
            // act
            IEnumerable<decimal> numbers = Enumerate.From((decimal) 1).Then(1.1M).To(2M);

            // assert
            CollectionAssert.AreEqual(new[] { 1, 1.1M, 1.2M, 1.3M, 1.4M, 1.5M, 1.6M, 1.7M, 1.8M, 1.9M, 2M }, numbers);
        }

        [Test]
        public void EnumerateDouble_FromThenTo()
        {
            // act
            IEnumerable<double> numbers = Enumerate.From((double) 1).Then(0.5).To(-1);

            // assert
            CollectionAssert.AreEqual(new[] { 1, 0.5, 0, -0.5, -1 }, numbers);
        }

        [Test]
        public void EnumerateFloat_FromThenTo()
        {
            // act
            IEnumerable<float> numbers = Enumerate.From((float) 1).Then(10f).To(40);

            // assert
            CollectionAssert.AreEqual(new float[] { 1, 10, 19, 28, 37 }, numbers);
        }

        [Test]
        public void EnumerateInt_FromThenTo()
        {
            // act
            IEnumerable<int> numbers = Enumerate.From(1).Then(-1).To(-10);

            // assert
            CollectionAssert.AreEqual(new[] { 1, -1, -3, -5, -7, -9 }, numbers);
        }

        [Test]
        public void EnumerateLong_FromThenTo()
        {
            // act
            IEnumerable<long> numbers = Enumerate.From(1L).Then(1).To(1);

            // assert
            CollectionAssert.AreEqual(new long[] { 1 }, numbers);
        }
    }
}