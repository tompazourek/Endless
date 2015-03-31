﻿#region License

// Copyright (C) Tomáš Pažourek, 2014
// All rights reserved.
// 
// Distributed under MIT license as a part of project Endless.
// https://github.com/tompazourek/Endless

#endregion

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using NUnit.Framework;

namespace Endless.Tests
{
    [TestFixture]
    public class EnumerateFromThenTests
    {
        [TestFixtureSetUp]
        public void RunBeforeAnyTest()
        {
            GlobalSettings.DefaultFloatingPointTolerance = 0.01;
        }

        [Test]
        public void EnumerateBigInteger_FromThen()
        {
            // act
            IEnumerable<BigInteger> numbers = Enumerate.From(new BigInteger(1)).Then(3).Take(5);

            // assert
            CollectionAssert.AreEqual(new BigInteger[] { 1, 3, 5, 7, 9 }, numbers);
        }

        [Test]
        public void EnumerateByte_FromThen()
        {
            // act
            IEnumerable<byte> numbers = Enumerate.From((byte) 1).Then(3).Take(5);

            // assert
            CollectionAssert.AreEqual(new byte[] { 1, 3, 5, 7, 9 }, numbers);
        }

        [Test]
        public void EnumerateByte_FromThen_Overflow()
        {
            // act
            byte overflow = Enumerate.From((byte) 1).Then(2).ElementAt(255);

            // assert
            Assert.AreEqual(0, overflow);
        }

        [Test]
        public void EnumerateChar_FromThen()
        {
            // act
            IEnumerable<char> numbers = Enumerate.From('a').Then('c').Take(5);

            // assert
            CollectionAssert.AreEqual(new[] { 'a', 'c', 'e', 'g', 'i' }, numbers);
        }

        [Test]
        public void EnumerateDecimal_FromThen()
        {
            // act
            IEnumerable<decimal> numbers = Enumerate.From((decimal) 1).Then(1.1M).Take(5);

            // assert
            CollectionAssert.AreEqual(new[] { 1, 1.1M, 1.2M, 1.3M, 1.4M }, numbers);
        }

        [Test]
        public void EnumerateDouble_FromThen()
        {
            // act
            IEnumerable<double> numbers = Enumerate.From(1d).Then(0.9).Take(5);

            // assert
            CollectionAssert.AreEqual(new[] { 1, 0.9d, 0.8d, 0.7d, 0.6d }, numbers);
        }

        [Test]
        public void EnumerateFloat_FromThen()
        {
            // act
            IEnumerable<float> numbers = Enumerate.From((float) 1).Then(10f).Take(5);

            // assert
            CollectionAssert.AreEqual(new float[] { 1, 10, 19, 28, 37 }, numbers);
        }

        [Test]
        public void EnumerateInt_FromThen()
        {
            // act
            IEnumerable<int> numbers = Enumerate.From(1).Then(-1).Take(5);

            // assert
            CollectionAssert.AreEqual(new[] { 1, -1, -3, -5, -7 }, numbers);
        }

        [Test]
        public void EnumerateLong_FromThen()
        {
            // act
            IEnumerable<long> numbers = Enumerate.From(1L).Then(1L).Take(5);

            // assert
            CollectionAssert.AreEqual(new long[] { 1 }, numbers);
        }

        [Test]
        public void EnumerateDateTime_FromThen()
        {
            // act
            IEnumerable<DateTime> times = Enumerate
                .From(new DateTime(1990, 7, 5, 12, 00, 00))
                .Then(new DateTime(1990, 7, 5, 12, 15, 00)).Take(5);

            // assert
            CollectionAssert.AreEqual(new DateTime[]
                {
                    new DateTime(1990, 7, 5, 12, 00, 00),
                    new DateTime(1990, 7, 5, 12, 15, 00),
                    new DateTime(1990, 7, 5, 12, 30, 00),
                    new DateTime(1990, 7, 5, 12, 45, 00),
                    new DateTime(1990, 7, 5, 13, 00, 00)
                }, times);
        }

        [Test]
        public void EnumerateDateTimeOffset_FromThen()
        {
            // act
            IEnumerable<DateTimeOffset> times = Enumerate
                .From(new DateTimeOffset(1990, 7, 5, 12, 00, 00, TimeSpan.FromHours(1)))
                .Then(new DateTimeOffset(1990, 7, 5, 12, 15, 00, TimeSpan.FromHours(1))).Take(5);

            // assert
            CollectionAssert.AreEqual(new DateTimeOffset[]
                {
                    new DateTimeOffset(1990, 7, 5, 12, 00, 00, TimeSpan.FromHours(1)),
                    new DateTimeOffset(1990, 7, 5, 12, 15, 00, TimeSpan.FromHours(1)),
                    new DateTimeOffset(1990, 7, 5, 12, 30, 00, TimeSpan.FromHours(1)),
                    new DateTimeOffset(1990, 7, 5, 12, 45, 00, TimeSpan.FromHours(1)),
                    new DateTimeOffset(1990, 7, 5, 13, 00, 00, TimeSpan.FromHours(1))
                }, times);
        }
    }
}