using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Xunit;

namespace Endless.Tests
{
    public partial class EnumerableOverloadsTests
    {

        [Fact]
        public void Zip_ToTuples()
        {
            // arrange
            var sequence1 = new[] { 'a', 'b', 'c' };
            var sequence2 = new[] { 1, 2, 3, 4, 5 };

            // action
            var zipped = sequence1.Zip(sequence2);

            // assert
            Assert.Equal(new[]
            {
                Tuple.Create('a', 1),
                Tuple.Create('b', 2),
                Tuple.Create('c', 3)
            }, zipped);
        }
    }
}