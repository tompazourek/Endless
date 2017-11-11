using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Endless.Tests
{
    [TestFixture]
    public class GenerateTests
    {
        [Test]
        public void Cycle()
        {
            var finite = new[] { 1, 2, 3 };
            var enumerable = finite.Cycle().Take(7);
            Assert.IsTrue(new[] { 1, 2, 3, 1, 2, 3, 1 }.SequenceEqual(enumerable));
        }

        [Test]
        public void Cycle_Empty()
        {
            var finite = Enumerable.Empty<int>();
            var list = finite.Cycle().Take(10).ToList();
            Assert.IsEmpty(list);
        }

        [Test]
        public void Iterate()
        {
            var enumerable = 2.Iterate(x => x * x).Take(5);
            Assert.IsTrue(new[] { 2, 4, 16, 256, 65536 }.SequenceEqual(enumerable));
        }

        [Test]
        public void Iterate2()
        {
            var enumerable = Generate.Iterate(0, 1, (a, b) => a + b).Take(10);
            Assert.IsTrue(new[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34 }.SequenceEqual(enumerable));
        }

        [Test]
        public void Repeat()
        {
            var enumerable = 2.Repeat().Take(5);
            Assert.IsTrue(new[] { 2, 2, 2, 2, 2 }.SequenceEqual(enumerable));
        }

        [Test]
        public void Repeat_Func()
        {
            Func<int> func = () => 3;
            var enumerable = func.Repeat().Take(5);
            Assert.IsTrue(new[] { 3, 3, 3, 3, 3 }.SequenceEqual(enumerable));
        }

        [Test]
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
            Assert.AreEqual(calledCount, 5);
        }

        [Test]
        public void Repeat_Func_Random()
        {
            var random = new Random(934280932);
            var enumerable = new Func<int>(random.Next).Repeat().Take(10);
            Assert.IsTrue(new[] { 359186384, 699044660, 2079248503, 1448139207, 2016071806, 1844770146, 1970954637, 1876823647, 310023636, 976922116 }.SequenceEqual(enumerable));
        }

        [Test]
        public void Repeat_null()
        {
            object o = null;
            var enumerable = o.Repeat().Take(5);
            Assert.IsTrue(new object[] { null, null, null, null, null }.SequenceEqual(enumerable));
        }

        [Test]
        public void Yield()
        {
            const int number = 5;
            var enumerable = number.Yield();
            IList<int> list = enumerable.ToList();

            Assert.IsTrue(list.Contains(number));
            Assert.AreEqual(1, list.Count);
        }

        [Test]
        public void Yield_null()
        {
            const object obj = null;
            var enumerable = obj.Yield();
            IList<object> list = enumerable.ToList();

            Assert.IsTrue(list.Contains(obj));
            Assert.AreEqual(1, list.Count);
        }
    }
}