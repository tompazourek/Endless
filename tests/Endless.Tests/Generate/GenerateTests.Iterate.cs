using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Endless.Tests
{
    public partial class GenerateTests
    {
        [Fact]
        public void Iterate()
        {
            var enumerable = 2.Iterate(x => x * x).Take(5);
            Assert.True(new[] { 2, 4, 16, 256, 65536 }.SequenceEqual(enumerable));
        }

        [Fact]
        public void Iterate2()
        {
            var enumerable = Generate.Iterate(0, 1, (a, b) => a + b).Take(10);
            Assert.True(new[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34 }.SequenceEqual(enumerable));
        }
    }
}