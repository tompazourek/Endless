using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Endless.Tests
{
    public partial class EnumerableExtensionsTests
    {
        [Fact]
        public void Shuffle()
        {
            // arrange
            var collection = Enumerable.Range(1, 20).ToList();

            // action
            var shuffled = collection.Shuffle().ToList();

            // assert
            Assert.Equal(collection, shuffled.OrderBy(x => x));
            Assert.NotEqual(collection, shuffled);
        }

        [Fact]
        public void Shuffle_Empty()
        {
            // arrange
            var collection = Enumerable.Empty<int>();

            // action
            var shuffled = collection.Shuffle();

            // assert
            Assert.Empty(shuffled);
        }
    }
}