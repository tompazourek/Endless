using System.Collections.Generic;
using Xunit;

namespace Endless.Tests
{
    public partial class EnumerableExtensionsTests
    {
        [Fact]
        public void TakeUntil_Any1()
        {
            // arrange
            var sequence = new[] { 1, 2, 3 };

            // action
            var result = sequence.TakeUntil(3);

            // assert
            Assert.Equal(new[] { 1, 2 }, result);
        }

        [Fact]
        public void TakeUntil_Any2()
        {
            // arrange
            var sequence = new[] { 1, 2, 3 };

            // action
            var result = sequence.TakeUntil(x => x == 3);

            // assert
            Assert.Equal(new[] { 1, 2 }, result);
        }

        [Fact]
        public void TakeUntil_Any3()
        {
            // arrange
            var sequence = new[] { 1, 2, 3 };

            // action
            var result = sequence.TakeUntil(x => true);

            // assert
            Assert.Empty(result);
        }

        [Fact]
        public void TakeUntil_Empty1()
        {
            // arrange
            var sequence = new int[] { };

            // action
            var result = sequence.TakeUntil(5);

            // assert
            Assert.Empty(result);
        }

        [Fact]
        public void TakeUntil_Empty2()
        {
            // arrange
            var sequence = new int[] { };

            // action
            var result = sequence.TakeUntil(x => true);

            // assert
            Assert.Empty(result);
        }

        [Fact]
        public void TakeUntil_Empty3()
        {
            // arrange
            var sequence = new int[] { };

            // action
            var result = sequence.TakeUntil(x => false);

            // assert
            Assert.Empty(result);
        }

        [Fact]
        public void TakeUntil_Empty4()
        {
            // arrange
            var sequence = new int[] { };

            // action
            var result = sequence.TakeUntil((i, x) => false);

            // assert
            Assert.Empty(result);
        }

        [Fact]
        public void TakeUntil_Empty5()
        {
            // arrange
            var sequence = new int[] { };

            // action
            var result = sequence.TakeUntil((i, x) => false);

            // assert
            Assert.Empty(result);
        }

        [Fact]
        public void TakeUntil_None1()
        {
            // arrange
            var sequence = new[] { 1, 2, 3 };

            // action
            var result = sequence.TakeUntil(-1);

            // assert
            Assert.Equal(new[] { 1, 2, 3 }, result);
        }

        [Fact]
        public void TakeUntil_None2()
        {
            // arrange
            var sequence = new[] { 1, 2, 3 };

            // action
            var result = sequence.TakeUntil(x => x == -1);

            // assert
            Assert.Equal(new[] { 1, 2, 3 }, result);
        }

        [Fact]
        public void TakeUntil_None3()
        {
            // arrange
            var sequence = new[] { 1, 2, 3 };

            // action
            var result = sequence.TakeUntil(x => false);

            // assert
            Assert.Equal(new[] { 1, 2, 3 }, result);
        }
    }
}