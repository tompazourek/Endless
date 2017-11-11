using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            for (var i = 0; i < 5000; i++)
            {
                values.Add(_random.NextByte());
            }

            // assert
            for (int i = byte.MinValue; i <= byte.MaxValue; i++)
            {
                var b = (byte)i;
                CollectionAssert.Contains(values, b);
                Debug.WriteLine(b);
            }
        }

        [Test]
        public void NextChar_500000()
        {
            // action
            var values = new List<char>(500000);
            for (var i = 0; i < 500000; i++)
            {
                values.Add(_random.NextChar());
            }

            // assert
            CollectionAssert.Contains(values, char.MinValue);
            CollectionAssert.Contains(values, char.MaxValue);
        }
    }
}