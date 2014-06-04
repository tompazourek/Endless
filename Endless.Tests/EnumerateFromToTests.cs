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
            IEnumerable<BigInteger> numbers = Enumerate.From(new BigInteger(1)).To(5);

            // assert
            CollectionAssert.AreEqual(new BigInteger[] { 1, 2, 3, 4, 5 }, numbers);
        }

        [Test]
        public void EnumerateBigInteger_FromTo_Empty()
        {
            // act
            IEnumerable<BigInteger> numbers = Enumerate.From((BigInteger) 5).To(new BigInteger(1));

            // assert
            CollectionAssert.IsEmpty(numbers);
        }

        [Test]
        public void EnumerateByte_FromTo()
        {
            // act
            IEnumerable<byte> numbers = Enumerate.From((byte) 1).To(5);

            // assert
            CollectionAssert.AreEqual(new byte[] { 1, 2, 3, 4, 5 }, numbers);
        }

        [Test]
        public void EnumerateByte_FromTo_Empty()
        {
            // act
            IEnumerable<byte> numbers = Enumerate.From((byte) 5).To(1);

            // assert
            CollectionAssert.IsEmpty(numbers);
        }

        [Test]
        public void EnumerateChar_FromTo()
        {
            // act
            IEnumerable<char> numbers = Enumerate.From('a').To('e');

            // assert
            CollectionAssert.AreEqual(new[] { 'a', 'b', 'c', 'd', 'e' }, numbers);
        }

        [Test]
        public void EnumerateChar_FromTo_Empty()
        {
            // act
            IEnumerable<char> numbers = Enumerate.From('e').To('a');

            // assert
            CollectionAssert.IsEmpty(numbers);
        }

        [Test]
        public void EnumerateDecimal_FromTo()
        {
            // act
            IEnumerable<decimal> numbers = Enumerate.From((decimal) 1).To(5);

            // assert
            CollectionAssert.AreEqual(new decimal[] { 1, 2, 3, 4, 5 }, numbers);
        }

        [Test]
        public void EnumerateDecimal_FromTo_Unmet()
        {
            // act
            IEnumerable<decimal> numbers = Enumerate.From(1M).To(5.5M);

            // assert
            CollectionAssert.AreEqual(new decimal[] { 1, 2, 3, 4, 5 }, numbers);
        }

        [Test]
        public void EnumerateDecimal_FromTo_Empty()
        {
            // act
            IEnumerable<decimal> numbers = Enumerate.From((decimal) 5).To(1);

            // assert
            CollectionAssert.IsEmpty(numbers);
        }

        [Test]
        public void EnumerateDouble_FromTo()
        {
            // act
            IEnumerable<double> numbers = Enumerate.From((double) 1).To(5);

            // assert
            CollectionAssert.AreEqual(new double[] { 1, 2, 3, 4, 5 }, numbers);
        }

        [Test]
        public void EnumerateDouble_FromTo_Empty()
        {
            // act
            IEnumerable<double> numbers = Enumerate.From((double) 5).To(1);

            // assert
            CollectionAssert.IsEmpty(numbers);
        }

        [Test]
        public void EnumerateFloat_FromTo()
        {
            // act
            IEnumerable<float> numbers = Enumerate.From((float) 1).To(5);

            // assert
            CollectionAssert.AreEqual(new float[] { 1, 2, 3, 4, 5 }, numbers);
        }

        [Test]
        public void EnumerateFloat_FromTo_Empty()
        {
            // act
            IEnumerable<float> numbers = Enumerate.From((float) 5).To(1);

            // assert
            CollectionAssert.IsEmpty(numbers);
        }

        [Test]
        public void EnumerateInt_FromTo()
        {
            // act
            IEnumerable<int> numbers = Enumerate.From(1).To(5);

            // assert
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5 }, numbers);
        }

        [Test]
        public void EnumerateInt_FromTo_Empty()
        {
            // act
            IEnumerable<int> numbers = Enumerate.From(5).To(1);

            // assert
            CollectionAssert.IsEmpty(numbers);
        }

        [Test]
        public void EnumerateLong_FromTo()
        {
            // act
            IEnumerable<long> numbers = Enumerate.From(1L).To(5);

            // assert
            CollectionAssert.AreEqual(new long[] { 1, 2, 3, 4, 5 }, numbers);
        }

        [Test]
        public void EnumerateLong_FromTo_Empty()
        {
            // act
            IEnumerable<long> numbers = Enumerate.From((long) 5).To(1L);

            // assert
            CollectionAssert.IsEmpty(numbers);
        }

        [Test]
        public void EnumerateDateTime_FromTo()
        {
            // act
            IEnumerable<DateTime> times = Enumerate
                .From(new DateTime(1990, 7, 5, 12, 00, 00))
                .To(new DateTime(1990, 7, 10, 13, 00, 00));

            // assert
            CollectionAssert.AreEqual(new DateTime[] {
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
            IEnumerable<DateTime> times = Enumerate
                .From(new DateTime(1990, 7, 5, 12, 00, 00))
                .To(new DateTime(1990, 7, 4, 12, 00, 00));

            // assert
            CollectionAssert.IsEmpty(times);
        }
    }
}