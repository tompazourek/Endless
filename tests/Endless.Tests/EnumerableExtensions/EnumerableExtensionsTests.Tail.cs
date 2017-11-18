using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Endless.Tests
{
    public partial class EnumerableExtensionsTests
    {
        [Fact]
        public void Tail()
        {
            // arrange
            var sequence = new[] { 1, 2, 3, 4, 5 };

            // action
            var result = sequence.Tail();

            // assert
            Assert.Equal(new[] { 2, 3, 4, 5 }, result);
        }

        [Fact]
        public void Tail_Empty()
        {
            // arrange
            var sequence = new int[] { };

            // action
            var result = sequence.Tail();

            // assert
            Assert.Empty(result);
        }

        [Fact]
        public void Tail_One()
        {
            // arrange
            var sequence = new[] { 1 };

            // action
            var result = sequence.Tail();

            // assert
            Assert.Empty(result);
        }
    }
}