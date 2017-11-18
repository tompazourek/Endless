using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Xunit;

namespace Endless.Tests
{
    public partial class EnumerableOverloadsTests
    {
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
    }
}