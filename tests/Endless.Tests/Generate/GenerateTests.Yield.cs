using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Endless.Tests
{
    public partial class GenerateTests
    {
        [Fact]
        public void Yield()
        {
            const int number = 5;
            var enumerable = number.Yield();
            IList<int> list = enumerable.ToList();

            Assert.True(list.Contains(number));
            Assert.Equal(1, list.Count);
        }

        [Fact]
        public void Yield_null()
        {
            const object obj = null;
            var enumerable = obj.Yield();
            IList<object> list = enumerable.ToList();

            Assert.True(list.Contains(obj));
            Assert.Equal(1, list.Count);
        }
    }
}