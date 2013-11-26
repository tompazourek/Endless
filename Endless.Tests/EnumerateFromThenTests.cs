using System;
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
            IEnumerable<BigInteger> numbers = Enumerate.FromThen(new BigInteger(1), 3).Take(5);

            // assert
            CollectionAssert.AreEqual(new BigInteger[] { 1, 3, 5, 7, 9 }, numbers);
        }

        [Test]
        public void EnumerateByte_FromThen()
        {
            // act
            IEnumerable<byte> numbers = Enumerate.FromThen((byte) 1, (byte) 3).Take(5);

            // assert
            CollectionAssert.AreEqual(new byte[] { 1, 3, 5, 7, 9 }, numbers);
        }

        [Test]
        public void EnumerateByte_FromThen_Overflow()
        {
            // act
            byte overflow = Enumerate.FromThen((byte) 1, (byte) 2).ElementAt(255);

            // assert
            Assert.AreEqual(0, overflow);
        }

        [Test]
        public void EnumerateChar_FromThen()
        {
            // act
            IEnumerable<char> numbers = Enumerate.FromThen('a', 'c').Take(5);

            // assert
            CollectionAssert.AreEqual(new[] { 'a', 'c', 'e', 'g', 'i' }, numbers);
        }

        [Test]
        public void EnumerateDecimal_FromThen()
        {
            // act
            IEnumerable<decimal> numbers = Enumerate.FromThen(1, 1.1M).Take(5);

            // assert
            CollectionAssert.AreEqual(new[] { 1, 1.1M, 1.2M, 1.3M, 1.4M }, numbers);
        }

        [Test]
        public void EnumerateDouble_FromThen()
        {
            // act
            IEnumerable<double> numbers = Enumerate.FromThen(1d, 0.9d).Take(5);

            // assert
            CollectionAssert.AreEqual(new[] { 1, 0.9d, 0.8d, 0.7d, 0.6d }, numbers);
        }

        [Test]
        public void EnumerateFloat_FromThen()
        {
            // act
            IEnumerable<float> numbers = Enumerate.FromThen(1, 10f).Take(5);

            // assert
            CollectionAssert.AreEqual(new float[] { 1, 10, 19, 28, 37 }, numbers);
        }

        [Test]
        public void EnumerateInt_FromThen()
        {
            // act
            IEnumerable<int> numbers = Enumerate.FromThen(1, -1).Take(5);

            // assert
            CollectionAssert.AreEqual(new[] { 1, -1, -3, -5, -7 }, numbers);
        }

        [Test]
        public void EnumerateLong_FromThen()
        {
            // act
            IEnumerable<long> numbers = Enumerate.FromThen(1L, 1L).Take(5);

            // assert
            CollectionAssert.AreEqual(new long[] { 1 }, numbers);
        }
    }
}