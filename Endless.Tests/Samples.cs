using System.Threading.Tasks;
using System.Text;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using System;
using Endless.Func;
using NUnit.Framework;

namespace Endless.Tests
{
    [TestFixture]
    public class Samples
    {
        [Test]
        public void DigitSum_Sample()
        {
            Func<int, int> digitSum = a => Math.Abs(a).Iterate(x => x / 10).TakeUntil(0).Select(x => x % 10).Sum();
            Assert.AreEqual(0, digitSum(0));
            Assert.AreEqual(1 + 2 + 3, digitSum(123));
            Assert.AreEqual(9 + 5 + 4 + 1 + 6, digitSum(95416));
            Assert.AreEqual(9 + 9 + 0 + 9 + 9, digitSum(99099));
            Assert.AreEqual(9 + 5 + 4 + 1 + 6, digitSum(-95416));
        }

        [Test]
        public void AlternatingDigitSum_Sample()
        {
            Func<int, IEnumerable<int>> digits =
                number => Math.Abs(number).Iterate(x => x / 10).TakeUntil(0).Select(x => x % 10).Reverse();

            Func<IEnumerable<int>, IEnumerable<int>> alternateSequence =
                sequence => sequence.Zip(new[] { 1, -1 }.Cycle(), (x, y) => x * y);

            Func<int, int> alternatingDigitSum = Function.Compose(x => x.Sum(), alternateSequence, digits); // sum of alternating sequence of digits

            Assert.AreEqual(0, alternatingDigitSum(0));
            Assert.AreEqual(1 - 2 + 3, alternatingDigitSum(123));
            Assert.AreEqual(9 - 5 + 4 - 1 + 6, alternatingDigitSum(95416));
            Assert.AreEqual(9 - 9 + 0 - 9 + 9, alternatingDigitSum(99099));
            Assert.AreEqual(9 - 5 + 4 - 1 + 6, alternatingDigitSum(-95416));
        }

        [Test]
        public void FridayThe13th_Sample()
        {
            var today = new DateTime(2013, 11, 3); // DateTime.Today;

            Func<DateTime, DateTime> nextFridayThe13thSince = day =>
                {
                    IEnumerable<DateTime> future = day.Iterate(x => x.AddDays(1));
                    return future.First(x => x.Day == 13 && x.DayOfWeek == DayOfWeek.Friday);
                };

            Assert.AreEqual(new DateTime(2013, 12, 13), nextFridayThe13thSince(today));
        }
    }
}