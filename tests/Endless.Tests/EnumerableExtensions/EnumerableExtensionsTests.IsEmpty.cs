using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Endless.Tests
{
    public partial class EnumerableExtensionsTests
    {
        [Fact]
        public void IsEmpty_Empty()
        {
            // arrange
            var sequence = new int[] { };

            // action
            var result = sequence.IsEmpty();

            // assert
            Assert.True(result);
        }

        [Fact]
        public void IsEmpty_NotEmpty()
        {
            // arrange
            var sequence = new[] { 1 };

            // action
            var result = sequence.IsEmpty();

            // assert
            Assert.False(result);
        }
    }
}