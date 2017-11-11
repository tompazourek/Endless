using System.Linq;
using System.Numerics;
using NUnit.Framework;

namespace Endless.Tests
{
    [TestFixture]
    public class NaturalTests
    {
        [Test]
        public void BigNaturalNumbers_10()
        {
            // act
            var numbers = BigNatural.Numbers.Take(10);

            // assert
            CollectionAssert.AreEqual(new BigInteger[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, numbers);
        }

        [Test]
        public void BigNaturalNumbersWithZero_10()
        {
            // act
            var numbers = BigNatural.NumbersWithZero.Take(10);

            // assert
            CollectionAssert.AreEqual(new BigInteger[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, numbers);
        }

        [Test]
        public void NaturalNumbers_10()
        {
            // act
            var numbers = Natural.Numbers.Take(10);

            // assert
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, numbers);
        }

        [Test]
        public void NaturalNumbersWithZero_10()
        {
            // act
            var numbers = Natural.NumbersWithZero.Take(10);

            // assert
            CollectionAssert.AreEqual(new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, numbers);
        }
    }
}