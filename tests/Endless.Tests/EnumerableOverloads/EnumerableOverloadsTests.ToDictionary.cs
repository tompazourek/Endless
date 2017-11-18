using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Xunit;

namespace Endless.Tests
{
    public partial class EnumerableOverloadsTests
    {
        [Fact]
        public void ToDictionary_Tuple()
        {
            // arrange
            var tuples = new[]
            {
                Tuple.Create('a', 1),
                Tuple.Create('b', 2),
                Tuple.Create('c', 3)
            };

            // action
            var dictionary = tuples.ToDictionary();

            // assert
            Assert.Equal(3, dictionary.Keys.Count);
            Assert.Equal(1, dictionary['a']);
            Assert.Equal(2, dictionary['b']);
            Assert.Equal(3, dictionary['c']);
        }
    }
}