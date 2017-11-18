using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Endless.Tests
{
    public partial class EnumerableExtensionsTests
    {
        [Fact]
        public void SkipUntil_Any1()
        {
            // arrange
            var sequence = new[] { 1, 2, 3 };

            // action
            var result = sequence.SkipUntil(3);

            // assert
            Assert.Equal(new[] { 3 }, result);
        }

        [Fact]
        public void SkipUntil_Any2()
        {
            // arrange
            var sequence = new[] { 1, 2, 3 };

            // action
            var result = sequence.SkipUntil(x => x == 3);

            // assert
            Assert.Equal(new[] { 3 }, result);
        }

        [Fact]
        public void SkipUntil_Any3()
        {
            // arrange
            var sequence = new[] { 1, 2, 3 };

            // action
            var result = sequence.SkipUntil(x => true);

            // assert
            Assert.Equal(new[] { 1, 2, 3 }, result);
        }

        [Fact]
        public void SkipUntil_Empty1()
        {
            // arrange
            var sequence = new int[] { };

            // action
            var result = sequence.SkipUntil(5);

            // assert
            Assert.Empty(result);
        }

        [Fact]
        public void SkipUntil_Empty2()
        {
            // arrange
            var sequence = new int[] { };

            // action
            var result = sequence.SkipUntil(x => true);

            // assert
            Assert.Empty(result);
        }

        [Fact]
        public void SkipUntil_Empty3()
        {
            // arrange
            var sequence = new int[] { };

            // action
            var result = sequence.SkipUntil(x => false);

            // assert
            Assert.Empty(result);
        }

        [Fact]
        public void SkipUntil_Empty4()
        {
            // arrange
            var sequence = new int[] { };

            // action
            var result = sequence.SkipUntil((i, x) => false);

            // assert
            Assert.Empty(result);
        }

        [Fact]
        public void SkipUntil_Empty5()
        {
            // arrange
            var sequence = new int[] { };

            // action
            var result = sequence.SkipUntil((i, x) => false);

            // assert
            Assert.Empty(result);
        }

        [Fact]
        public void SkipUntil_None1()
        {
            // arrange
            var sequence = new[] { 1, 2, 3 };

            // action
            var result = sequence.SkipUntil(-1);

            // assert
            Assert.Empty(result);
        }

        [Fact]
        public void SkipUntil_None2()
        {
            // arrange
            var sequence = new[] { 1, 2, 3 };

            // action
            var result = sequence.SkipUntil(x => x == -1);

            // assert
            Assert.Empty(result);
        }

        [Fact]
        public void SkipUntil_None3()
        {
            // arrange
            var sequence = new[] { 1, 2, 3 };

            // action
            var result = sequence.SkipUntil(x => false);

            // assert
            Assert.Empty(result);
        }
    }
}