using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Endless.Tests
{
    public partial class EnumerableExtensionsTests
    {
        [Fact]
        public void And_Empty()
        {
            // arrange
            var conditions = Enumerable.Empty<bool>();

            // act
            var result = conditions.And();

            // assert
            Assert.True(result);
        }

        [Fact]
        public void And_False()
        {
            // arrange
            IEnumerable<bool> conditions = new[] { true, true, false, true };

            // act
            var result = conditions.And();

            // assert
            Assert.False(result);
        }

        [Fact]
        public void And_Lazy_True()
        {
            // arrange
            var funcResults = new[] { true, true, true, true };
            var funcWasCalled = new bool[funcResults.Length];
            var predicates = funcResults.Select((_, i) => new Func<bool>(() =>
            {
                funcWasCalled[i] = true;
                return funcResults[i];
            })).ToList();

            // act
            var result = predicates.And();

            // assert
            Assert.True(result);
            Assert.True(funcWasCalled[0]);
            Assert.True(funcWasCalled[1]);
            Assert.True(funcWasCalled[2]);
            Assert.True(funcWasCalled[3]);
        }

        [Fact]
        public void And_True()
        {
            // arrange
            IEnumerable<bool> conditions = new[] { true, true, true, true };

            // act
            var result = conditions.And();

            // assert
            Assert.True(result);
        }

        [Fact]
        public void Or_Empty()
        {
            // arrange
            var conditions = Enumerable.Empty<bool>();

            // act
            var result = conditions.Or();

            // assert
            Assert.False(result);
        }

        [Fact]
        public void Or_False()
        {
            // arrange
            IEnumerable<bool> conditions = new[] { false, false, false, false };

            // act
            var result = conditions.Or();

            // assert
            Assert.False(result);
        }

        [Fact]
        public void Or_Lazy_True()
        {
            // arrange
            var funcResults = new[] { false, true, true, true };
            var funcWasCalled = new bool[funcResults.Length];
            var predicates = funcResults.Select((_, i) => new Func<bool>(() =>
            {
                funcWasCalled[i] = true;
                return funcResults[i];
            })).ToList();

            // act
            var result = predicates.Or();

            // assert
            Assert.True(result);
            Assert.True(funcWasCalled[0]);
            Assert.True(funcWasCalled[1]);
            Assert.False(funcWasCalled[2]);
            Assert.False(funcWasCalled[3]);
        }

        [Fact]
        public void Or_True()
        {
            // arrange
            IEnumerable<bool> conditions = new[] { false, true, false, true };

            // act
            var result = conditions.Or();

            // assert
            Assert.True(result);
        }
    }
}