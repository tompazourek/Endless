#region License

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
    public class BigIntegerAggregationsTests
    {
        [Test]
        public void Sum()
        {
            // arrange
            var bigNumber = new BigInteger(Int64.MaxValue);
            var bigNumbers = bigNumber.Repeat().Take(10);

            // act
            var sum = bigNumbers.Sum();

            // assert
            Assert.AreEqual(bigNumber * 10, sum);
        }

        [Test]
        public void Sum_Nullable()
        {
            // arrange
            var bigNumber = new BigInteger(Int64.MaxValue);
            var bigNumbers = new BigInteger?[] { bigNumber, null, bigNumber, bigNumber, null, null, bigNumber };

            // act
            var sum = bigNumbers.Sum();

            // assert
            Assert.AreEqual(bigNumber * 4, sum);
        }

        [Test]
        public void Min()
        {
            // arrange
            var bigNumber = new BigInteger(Int64.MaxValue);
            var bigNumbers = new[] { bigNumber + 1, bigNumber + 3, bigNumber + 5, bigNumber + 10 };

            // act
            BigInteger min = bigNumbers.Min();

            // assert
            Assert.AreEqual(bigNumber + 1, min);
        }

        [Test]
        public void Min_Empty()
        {
            // arrange
            var bigNumbers = Enumerable.Empty<BigInteger>();

            // act & assert
            Assert.Throws<InvalidOperationException>(() => bigNumbers.Min());
        }

        [Test]
        public void Min_Nullable()
        {
            // arrange
            var bigNumber = new BigInteger(Int64.MaxValue);
            var bigNumbers = new BigInteger?[] { bigNumber + 1, null, bigNumber + 3, bigNumber + 5, bigNumber + 10 };

            // act
            BigInteger? min = bigNumbers.Min();

            // assert
            Assert.AreEqual(bigNumber + 1, min);
        }

        [Test]
        public void Min_Nullable_Empty()
        {
            // arrange
            var bigNumbers = Enumerable.Empty<BigInteger?>();

            // act
            BigInteger? min = bigNumbers.Min();

            // assert
            Assert.IsNull(min);
        }

        [Test]
        public void Max()
        {
            // arrange
            var bigNumber = new BigInteger(Int64.MaxValue);
            var bigNumbers = new[] { bigNumber + 1, bigNumber + 3, bigNumber + 5, bigNumber + 10 };

            // act
            BigInteger max = bigNumbers.Max();

            // assert
            Assert.AreEqual(bigNumber + 10, max);
        }

        [Test]
        public void Max_Empty()
        {
            // arrange
            var bigNumbers = Enumerable.Empty<BigInteger>();

            // act & assert
            Assert.Throws<InvalidOperationException>(() => bigNumbers.Max());
        }

        [Test]
        public void Max_Nullable()
        {
            // arrange
            var bigNumber = new BigInteger(Int64.MaxValue);
            var bigNumbers = new BigInteger?[] { bigNumber + 1, null, bigNumber + 3, bigNumber + 5, bigNumber + 10 };

            // act
            BigInteger? max = bigNumbers.Max();

            // assert
            Assert.AreEqual(bigNumber + 10, max);
        }

        [Test]
        public void Max_Nullable_Empty()
        {
            // arrange
            var bigNumbers = Enumerable.Empty<BigInteger?>();

            // act
            BigInteger? max = bigNumbers.Max();

            // assert
            Assert.IsNull(max);
        }
    }
}