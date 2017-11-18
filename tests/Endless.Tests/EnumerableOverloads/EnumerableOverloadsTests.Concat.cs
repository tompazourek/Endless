using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Xunit;

namespace Endless.Tests
{
    public partial class EnumerableOverloadsTests
    {
        [Fact]
        [SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
        public void Concat_Lazy()
        {
            // arrange
            var sequence = new[] { 'a', 'b', 'c' };

            var generatorCalled = false;
            var generator = new Func<char[]>(() =>
            {
                generatorCalled = true;
                return new[] { 'd', 'e', 'f' };
            });

            // action
            var concatenated = sequence.Concat(generator);

            var result1 = concatenated.Take(3).ToList();
            var generatorCalledAfterResult1 = generatorCalled;

            var result2 = concatenated.ToList();
            var generatorCalledAfterResult2 = generatorCalled;

            // assert
            Assert.Equal(new[] { 'a', 'b', 'c' }, result1);
            Assert.Equal(new[] { 'a', 'b', 'c', 'd', 'e', 'f' }, result2);
            Assert.False(generatorCalledAfterResult1);
            Assert.True(generatorCalledAfterResult2);
        }
    }
}