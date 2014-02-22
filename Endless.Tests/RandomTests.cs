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
    public class RandomTests
    {
        private readonly Random _random = new Random(12345);

        [Test]
        public void NextByte_5000()
        {
            // action
            var values = new List<byte>(5000);
            for (int i = 0; i < 5000; i++)
            {
                values.Add(_random.NextByte());
            }

            // assert
            for (int i = byte.MinValue; i <= byte.MaxValue; i++)
            {
                var b = (byte) i;
                CollectionAssert.Contains(values, b);
                Debug.WriteLine(b);
            }
        }

        [Test]
        public void NextChar_1000000()
        {
            // action
            var values = new List<char>(1000000);
            for (int i = 0; i < 1000000; i++)
            {
                values.Add(_random.NextChar());
            }

            // assert
            CollectionAssert.Contains(values, char.MinValue);
            CollectionAssert.Contains(values, char.MaxValue);
        }
    }
}