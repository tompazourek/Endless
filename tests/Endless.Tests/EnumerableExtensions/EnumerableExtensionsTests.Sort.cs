using Xunit;

namespace Endless.Tests
{
    public partial class EnumerableExtensionsTests
    {
        [Fact]
        public void Sort()
        {
            // arrange
            var sequence = new[] { 2, 3, 1 };

            // action
            var result = sequence.Sort();

            // assert
            Assert.Equal(new[] { 1, 2, 3 }, result);
        }

        [Fact]
        public void Sort_Empty()
        {
            // arrange
            var sequence = new int[] { };

            // action
            var result = sequence.Sort();

            // assert
            Assert.Empty(result);
        }


        [Fact]
        public void Sort_One()
        {
            // arrange
            var sequence = new[] { 1 };

            // action
            var result = sequence.Sort();

            // assert
            Assert.Equal(new[] { 1 }, result);
        }

        [Fact]
        public void SortDescending()
        {
            // arrange
            var sequence = new[] { 2, 3, 1 };

            // action
            var result = sequence.SortDescending();

            // assert
            Assert.Equal(new[] { 3, 2, 1 }, result);
        }

        [Fact]
        public void SortDescending_Empty()
        {
            // arrange
            var sequence = new int[] { };

            // action
            var result = sequence.SortDescending();

            // assert
            Assert.Empty(result);
        }


        [Fact]
        public void SortDescending_One()
        {
            // arrange
            var sequence = new[] { 1 };

            // action
            var result = sequence.SortDescending();

            // assert
            Assert.Equal(new[] { 1 }, result);
        }
    }
}