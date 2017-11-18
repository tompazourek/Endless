using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Xunit;

namespace Endless.Tests
{
    public class CachedEnumerableExtensionTests
    {
        [Fact]
        public void Cached()
        {
            // arrange
            var random = new Random(666);
            using (var cached = new Func<int>(random.Next).Repeat().Cached())
            {
                // action
                var sequence1 = cached.Take(10).ToList();
                var sequence2 = cached.Take(10).ToList();

                // assert
                Assert.Equal(sequence1, sequence2);
            }
        }

        [Fact]
        [SuppressMessage("ReSharper", "UnusedVariable")]
        public void Cached_TakeMore()
        {
            // arrange
            var random1 = new Random(666);
            var random2 = new Random(666);
            var uncached = new Func<int>(random2.Next).Repeat();
            using (var cached = new Func<int>(random1.Next).Repeat().Cached())
            {
                // action
                var sequence1 = cached.Take(10).ToList();
                var sequence2 = cached.Take(15).ToList();
                var sequence3 = uncached.Take(15).ToList();

                // assert
                Assert.Equal(sequence3, sequence2);
            }
        }

        [Fact]
        [SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
        public void Cached_Without()
        {
            // arrange
            var random = new Random(666);
            var uncached = new Func<int>(random.Next).Repeat();

            // action
            var sequence1 = uncached.Take(10).ToList();
            var sequence2 = uncached.Take(10).ToList();

            // assert
            Assert.NotEqual(sequence1, sequence2);
        }
    }
}