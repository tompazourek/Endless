using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Endless.Tests
{
    public partial class GenerateTests
    {
        [Fact]
        public void Cycle()
        {
            var finite = new[] { 1, 2, 3 };
            var enumerable = finite.Cycle().Take(7);
            Assert.True(new[] { 1, 2, 3, 1, 2, 3, 1 }.SequenceEqual(enumerable));
        }

        [Fact]
        public void Cycle_Empty()
        {
            var finite = Enumerable.Empty<int>();
            var list = finite.Cycle().Take(10).ToList();
            Assert.Empty(list);
        }
    }
}