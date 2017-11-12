using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Xunit;

namespace Endless.Tests
{
    public class EnumerableOverloadsExtensionsTest
    {
        [Fact]
        public void Except1()
        {
            // arrange
            var sequence = new[] { "Hello", "I", "am", "a", "Hello", "dog" };

            // action
            var result = sequence.Except("Hello");

            // assert
            Assert.Equal(new[] { "I", "am", "a", "dog" }, result);
        }

        [Fact]
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

        [Fact]
        public void Except3()
        {
            // arrange
            var sequence = new[] { "I", "am", "a", "dog" };

            // action
            var result = sequence.Except();

            // assert
            Assert.Equal(new[] { "I", "am", "a", "dog" }, result);
        }

        [Fact]
        public void Except4()
        {
            // arrange
            var sequence = new[] { "I", "am", "a", "dog" };

            // action
            var result = sequence.Except("am", "x", "dog");

            // assert
            Assert.Equal(new[] { "I", "a" }, result);
        }

        [Fact]
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
            Assert.Equal(new[] { 'a', 'b', 'c' }, result1);
            Assert.Equal(new[] { 'a', 'b', 'c', 'd', 'e', 'f' }, result2);
            Assert.False(generatorCalledAfterResult1);
            Assert.True(generatorCalledAfterResult2);
        }

        [Fact]
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
            Assert.Equal(new[] { 5, 1, 2, 3, 4, 6 }, numbers);
        }

        [Fact]
        public void SelectMany2()
        {
            // arrange
            var numberSequences = new int[][] { };

            // action
            var numbers = numberSequences.SelectMany();

            // assert
            Assert.Equal(new int[] { }, numbers);
        }

        [Fact]
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
            Assert.Equal(3, dictionary.Keys.Count);
            Assert.Equal(1, dictionary['a']);
            Assert.Equal(2, dictionary['b']);
            Assert.Equal(3, dictionary['c']);
        }

        [Fact]
        public void ZipToTuples()
        {
            // arrange
            var sequence1 = new[] { 'a', 'b', 'c' };
            var sequence2 = new[] { 1, 2, 3, 4, 5 };

            // action
            var zipped = sequence1.Zip(sequence2);

            // assert
            Assert.Equal(new[]
            {
                Tuple.Create('a', 1),
                Tuple.Create('b', 2),
                Tuple.Create('c', 3)
            }, zipped);
        }
    }
}