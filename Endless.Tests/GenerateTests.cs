using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            IEnumerable<int> enumerable = finite.Cycle().Take(7);
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
            IEnumerable<int> enumerable = 2.Iterate(x => x * x).Take(5);
            Assert.IsTrue(new[] { 2, 4, 16, 256, 65536 }.SequenceEqual(enumerable));
        }

        [Test]
        public void Repeat()
        {
            IEnumerable<int> enumerable = 2.Repeat().Take(5);
            Assert.IsTrue(new[] { 2, 2, 2, 2, 2 }.SequenceEqual(enumerable));
        }

        [Test]
        public void Repeat_Func()
        {
            Func<int> func = () => 3;
            IEnumerable<int> enumerable = func.Repeat().Take(5);
            Assert.IsTrue(new[] { 3, 3, 3, 3, 3 }.SequenceEqual(enumerable));
        }

        [Test]
        public void Repeat_Func_CalledRepeatedly()
        {
            int calledCount = 0;
            Func<int> func = () =>
                {
                    calledCount++;
                    return 3;
                };
            List<int> list = func.Repeat().Take(5).ToList();
            Assert.AreEqual(calledCount, 5);
        }

        [Test]
        public void Repeat_null()
        {
            object o = null;
            IEnumerable<object> enumerable = o.Repeat().Take(5);
            Assert.IsTrue(new object[] { null, null, null, null, null }.SequenceEqual(enumerable));
        }

        [Test]
        public void Yield()
        {
            const int number = 5;
            IEnumerable<int> enumerable = number.Yield();
            IList<int> list = enumerable.ToList();

            Assert.IsTrue(list.Contains(number));
            Assert.AreEqual(1, list.Count);
        }

        [Test]
        public void Yield_null()
        {
            const object obj = null;
            IEnumerable<object> enumerable = obj.Yield();
            IList<object> list = enumerable.ToList();

            Assert.IsTrue(list.Contains(obj));
            Assert.AreEqual(1, list.Count);
        }
    }
}