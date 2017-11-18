using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Endless.Tests
{
    public partial class EnumerableExtensionsTests
    {
        [Fact]
        public void IndexOf_Exists1()
        {
            // arrange
            IEnumerable<int> sequence = new[] { 1, 2, 3 };

            // action
            var result = sequence.IndexOf(1);

            // assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void IndexOf_Exists2()
        {
            // arrange
            IEnumerable<int> sequence = new[] { 1, 2, 3 };

            // action
            var result = sequence.IndexOf(3);

            // assert
            Assert.Equal(2, result);
        }

        [Fact]
        public void IndexOf_Exists3()
        {
            // arrange
            IEnumerable<int> sequence = new[] { 1, 2, 3, 1, 2, 3 };

            // action
            var result = sequence.IndexOf(3);

            // assert
            Assert.Equal(2, result);
        }

        [Fact]
        public void IndexOf_NotExists1()
        {
            // arrange
            IEnumerable<int> sequence = new[] { 1, 2, 3 };

            // action
            var result = sequence.IndexOf(4);

            // assert
            Assert.Equal(-1, result);
        }

        [Fact]
        public void IndexOf_NotExists2()
        {
            // arrange
            IEnumerable<int> sequence = new[] { 1, 2, 3 };

            // action
            var result = sequence.IndexOf(0);

            // assert
            Assert.Equal(-1, result);
        }
    }
}