using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Endless.Tests
{
    public partial class EnumerableExtensionsTests
    {
        [Fact]
        public void Random()
        {
            // arrange
            var collection = new[] { 1, 2, 3, 4, 5, 6 };

            // action
            var picks = new List<int>();
            for (var i = 0; i < 1000; i++)
            {
                picks.Add(collection.Random());
            }
            var groups = picks.GroupBy(x => x).Select(g => new { g.Key, Count = g.Count() });

            // assert
            Assert.Equal(6, groups.Count());
        }

        [Fact]
        public void Random_Empty()
        {
            // arrange
            var collection = Enumerable.Empty<int>();

            // action
            Assert.Throws<InvalidOperationException>(() => collection.Random());
        }

        [Fact]
        public void Random_Predicate()
        {
            // arrange
            var collection = new[] { 1, 2, 3, 4, 5, 6 };

            // action
            var picks = new List<int>();
            for (var i = 0; i < 1000; i++)
            {
                picks.Add(collection.Random(x => x % 2 == 0));
            }
            var groups = picks.GroupBy(x => x).Select(g => new { g.Key, Count = g.Count() }).ToList();

            // assert
            Assert.Equal(3, groups.Count);
            Assert.Equal(new[] { 2, 4, 6 }, groups.Select(x => x.Key).OrderBy(x => x));
        }

        [Fact]
        public void Random_Predicate_Empty()
        {
            // arrange
            var collection = Enumerable.Empty<int>();

            // action
            Assert.Throws<InvalidOperationException>(() => collection.Random(x => x % 2 == 0));
        }
    }
}