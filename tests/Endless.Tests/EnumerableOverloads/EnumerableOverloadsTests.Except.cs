using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Xunit;

namespace Endless.Tests
{
    public partial class EnumerableOverloadsTests
    {
        [Fact]
        public void Except1()
        {
            // arrange
            var sequence = new[] { "Hello", "I", "am", "a", "Hello", "dog" };

            // action
            var result = sequence.Except("Hello");

            // assert
            Assert.Equal(new[] { "I", "am", "a", "dog" }, result);
        }

        [Fact]
        public void Except2()
        {
            // arrange
            var sequence = new[] { "I", "am", "a", null, "dog" };

            // action
            Assert.Throws<ArgumentNullException>(() =>
            {
                // ReSharper disable once UnusedVariable
                var result = sequence.Except(null);
            });
        }

        [Fact]
        public void Except3()
        {
            // arrange
            var sequence = new[] { "I", "am", "a", "dog" };

            // action
            var result = sequence.Except();

            // assert
            Assert.Equal(new[] { "I", "am", "a", "dog" }, result);
        }

        [Fact]
        public void Except4()
        {
            // arrange
            var sequence = new[] { "I", "am", "a", "dog" };

            // action
            var result = sequence.Except("am", "x", "dog");

            // assert
            Assert.Equal(new[] { "I", "a" }, result);
        }
    }
}