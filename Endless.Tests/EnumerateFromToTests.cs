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
    public class EnumerateFromToTests
    {
        [Test]
        public void EnumerateBigInteger_FromTo()
        {
            // act
            IEnumerable<BigInteger> numbers = Enumerate.FromTo(new BigInteger(1), 5);

            // assert
            CollectionAssert.AreEqual(new BigInteger[] { 1, 2, 3, 4, 5 }, numbers);
        }

        [Test]
        public void EnumerateBigInteger_FromTo_Empty()
        {
            // act
            IEnumerable<BigInteger> numbers = Enumerate.FromTo(5, new BigInteger(1));

            // assert
            CollectionAssert.IsEmpty(numbers);
        }

        [Test]
        public void EnumerateByte_FromTo()
        {
            // act
            IEnumerable<byte> numbers = Enumerate.FromTo((byte) 1, (byte) 5);

            // assert
            CollectionAssert.AreEqual(new byte[] { 1, 2, 3, 4, 5 }, numbers);
        }

        [Test]
        public void EnumerateByte_FromTo_Empty()
        {
            // act
            IEnumerable<byte> numbers = Enumerate.FromTo((byte) 5, (byte) 1);

            // assert
            CollectionAssert.IsEmpty(numbers);
        }

        [Test]
        public void EnumerateChar_FromTo()
        {
            // act
            IEnumerable<char> numbers = Enumerate.FromTo('a', 'e');

            // assert
            CollectionAssert.AreEqual(new[] { 'a', 'b', 'c', 'd', 'e' }, numbers);
        }

        [Test]
        public void EnumerateChar_FromTo_Empty()
        {
            // act
            IEnumerable<char> numbers = Enumerate.FromTo('e', 'a');

            // assert
            CollectionAssert.IsEmpty(numbers);
        }

        [Test]
        public void EnumerateDecimal_FromTo()
        {
            // act
            IEnumerable<decimal> numbers = Enumerate.FromTo((decimal) 1, 5);

            // assert
            CollectionAssert.AreEqual(new decimal[] { 1, 2, 3, 4, 5 }, numbers);
        }

        [Test]
        public void EnumerateDecimal_FromTo_Empty()
        {
            // act
            IEnumerable<decimal> numbers = Enumerate.FromTo(5, (decimal) 1);

            // assert
            CollectionAssert.IsEmpty(numbers);
        }

        [Test]
        public void EnumerateDouble_FromTo()
        {
            // act
            IEnumerable<double> numbers = Enumerate.FromTo((double) 1, 5);

            // assert
            CollectionAssert.AreEqual(new double[] { 1, 2, 3, 4, 5 }, numbers);
        }

        [Test]
        public void EnumerateDouble_FromTo_Empty()
        {
            // act
            IEnumerable<double> numbers = Enumerate.FromTo(5, (double) 1);

            // assert
            CollectionAssert.IsEmpty(numbers);
        }

        [Test]
        public void EnumerateFloat_FromTo()
        {
            // act
            IEnumerable<float> numbers = Enumerate.FromTo((float) 1, 5);

            // assert
            CollectionAssert.AreEqual(new float[] { 1, 2, 3, 4, 5 }, numbers);
        }

        [Test]
        public void EnumerateFloat_FromTo_Empty()
        {
            // act
            IEnumerable<float> numbers = Enumerate.FromTo(5, (float) 1);

            // assert
            CollectionAssert.IsEmpty(numbers);
        }

        [Test]
        public void EnumerateInt_FromTo()
        {
            // act
            IEnumerable<int> numbers = Enumerate.FromTo(1, 5);

            // assert
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5 }, numbers);
        }

        [Test]
        public void EnumerateInt_FromTo_Empty()
        {
            // act
            IEnumerable<int> numbers = Enumerate.FromTo(5, 1);

            // assert
            CollectionAssert.IsEmpty(numbers);
        }

        [Test]
        public void EnumerateLong_FromTo()
        {
            // act
            IEnumerable<long> numbers = Enumerate.FromTo(1L, 5);

            // assert
            CollectionAssert.AreEqual(new long[] { 1, 2, 3, 4, 5 }, numbers);
        }

        [Test]
        public void EnumerateLong_FromTo_Empty()
        {
            // act
            IEnumerable<long> numbers = Enumerate.FromTo(5, 1L);

            // assert
            CollectionAssert.IsEmpty(numbers);
        }
    }
}