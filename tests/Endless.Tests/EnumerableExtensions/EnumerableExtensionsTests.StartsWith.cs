using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Endless.Tests
{
    public partial class EnumerableExtensionsTests
    {
        [Fact]
        public void StartsWith_Empty1()
        {
            // arrange
            IEnumerable<int> collection = new[] { 1, 2, 3, 4, 5 };
            var subsequence = Enumerable.Empty<int>();

            // action
            var result = collection.StartsWith(subsequence);

            // assert
            Assert.True(result);
        }

        [Fact]
        public void StartsWith_Empty2()
        {
            // arrange
            var collection = Enumerable.Empty<int>();
            IEnumerable<int> subsequence = new[] { 1, 2, 3, 4, 5 };

            // action
            var result = collection.StartsWith(subsequence);

            // assert
            Assert.False(result);
        }

        [Fact]
        public void StartsWith_False()
        {
            // arrange
            IEnumerable<int> collection = new[] { 1, 2, 3, 4, 5 };
            IEnumerable<int> subsequence = new[] { 1, 3 };

            // action
            var result = collection.StartsWith(subsequence);

            // assert
            Assert.False(result);
        }

        [Fact]
        public void StartsWith_Longer()
        {
            // arrange
            IEnumerable<int> collection = new[] { 1, 2, 3, 4, 5 };
            IEnumerable<int> subsequence = new[] { 1, 2, 3, 4, 5, 6 };

            // action
            var result = collection.StartsWith(subsequence);

            // assert
            Assert.False(result);
        }

        [Fact]
        public void StartsWith_True()
        {
            // arrange
            IEnumerable<int> collection = new[] { 1, 2, 3, 4, 5 };
            IEnumerable<int> subsequence = new[] { 1, 2 };

            // action
            var result = collection.StartsWith(subsequence);

            // assert
            Assert.True(result);
        }
    }
}