using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using NUnit.Framework;

namespace Endless.Tests
{
    [TestFixture]
    public class IEnumerableOverloadsExtensionsTest
    {
        [Test]
        public void Except1()
        {
            // arrange
            var sequence = new[] { "Hello", "I", "am", "a", "Hello", "dog" };

            // action
            var result = sequence.Except("Hello");

            // assert
            CollectionAssert.AreEqual(new[] { "I", "am", "a", "dog" }, result);
        }

        [Test]
        public void Except2()
        {
            // arrange
            var sequence = new[] { "I", "am", "a", null, "dog" };

            // action
            Assert.Throws<ArgumentNullException>(() =>
            {
                // ReSharper disable once UnusedVariable
                var result = sequence.Except(null);
            });
        }

        [Test]
        public void Except3()
        {
            // arrange
            var sequence = new[] { "I", "am", "a", "dog" };

            // action
            var result = sequence.Except();

            // assert
            CollectionAssert.AreEqual(new[] { "I", "am", "a", "dog" }, result);
        }

        [Test]
        public void Except4()
        {
            // arrange
            var sequence = new[] { "I", "am", "a", "dog" };

            // action
            var result = sequence.Except("am", "x", "dog");

            // assert
            CollectionAssert.AreEqual(new[] { "I", "a" }, result);
        }

        [Test]
        [SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
        public void LazyConcat()
        {
            // arrange
            var sequence = new[] { 'a', 'b', 'c' };

            var generatorCalled = false;
            var generator = new Func<char[]>(() =>
            {
                generatorCalled = true;
                return new[] { 'd', 'e', 'f' };
            });

            // action
            var concatenated = sequence.Concat(generator);

            var result1 = concatenated.Take(3).ToList();
            var generatorCalledAfterResult1 = generatorCalled;

            var result2 = concatenated.ToList();
            var generatorCalledAfterResult2 = generatorCalled;

            // assert
            CollectionAssert.AreEqual(new[] { 'a', 'b', 'c' }, result1);
            CollectionAssert.AreEqual(new[] { 'a', 'b', 'c', 'd', 'e', 'f' }, result2);
            Assert.IsFalse(generatorCalledAfterResult1);
            Assert.IsTrue(generatorCalledAfterResult2);
        }

        [Test]
        public void SelectMany1()
        {
            // arrange
            var numberSequences = new[]
            {
                new[] { 5 },
                new int[] { },
                new[] { 1, 2, 3 },
                new[] { 4, 6 }
            };

            // action
            var numbers = numberSequences.SelectMany();

            // assert
            CollectionAssert.AreEqual(new[] { 5, 1, 2, 3, 4, 6 }, numbers);
        }

        [Test]
        public void SelectMany2()
        {
            // arrange
            var numberSequences = new int[][] { };

            // action
            var numbers = numberSequences.SelectMany();

            // assert
            CollectionAssert.AreEqual(new int[] { }, numbers);
        }

        [Test]
        public void TupleToDictionary()
        {
            // arrange
            var tuples = new[]
            {
                Tuple.Create('a', 1),
                Tuple.Create('b', 2),
                Tuple.Create('c', 3)
            };

            // action
            var dictionary = tuples.ToDictionary();

            // assert
            Assert.AreEqual(3, dictionary.Keys.Count);
            Assert.AreEqual(1, dictionary['a']);
            Assert.AreEqual(2, dictionary['b']);
            Assert.AreEqual(3, dictionary['c']);
        }

        [Test]
        public void ZipToTuples()
        {
            // arrange
            var sequence1 = new[] { 'a', 'b', 'c' };
            var sequence2 = new[] { 1, 2, 3, 4, 5 };

            // action
            var zipped = sequence1.Zip(sequence2);

            // assert
            CollectionAssert.AreEqual(new[]
            {
                Tuple.Create('a', 1),
                Tuple.Create('b', 2),
                Tuple.Create('c', 3)
            }, zipped);
        }
    }
}