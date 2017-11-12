using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Xunit;

namespace Endless.Tests
{
    public class GenerateTests
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

        [Fact]
        public void Repeat()
        {
            var enumerable = 2.Repeat().Take(5);
            Assert.True(new[] { 2, 2, 2, 2, 2 }.SequenceEqual(enumerable));
        }

        [Fact]
        public void Repeat_Func()
        {
            Func<int> func = () => 3;
            var enumerable = func.Repeat().Take(5);
            Assert.True(new[] { 3, 3, 3, 3, 3 }.SequenceEqual(enumerable));
        }

        [Fact]
        public void Repeat_Func_CalledRepeatedly()
        {
            var calledCount = 0;
            Func<int> func = () =>
            {
                calledCount++;
                return 3;
            };
            // ReSharper disable once UnusedVariable
            var list = func.Repeat().Take(5).ToList();
            Assert.Equal(5, calledCount);
        }

        [Fact]
        public void Repeat_Func_Random()
        {
            var random = new Random(934280932);
            var enumerable = new Func<int>(random.Next).Repeat().Take(10);
            Assert.True(new[] { 359186384, 699044660, 2079248503, 1448139207, 2016071806, 1844770146, 1970954637, 1876823647, 310023636, 976922116 }.SequenceEqual(enumerable));
        }

        [Fact]
        [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull")]
        public void Repeat_null()
        {
            object o = null;
            var enumerable = o.Repeat().Take(5);
            Assert.True(new object[] { null, null, null, null, null }.SequenceEqual(enumerable));
        }

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