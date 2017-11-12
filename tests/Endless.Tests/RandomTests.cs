using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xunit;

namespace Endless.Tests
{
    public class RandomTests
    {
        private readonly Random _random = new Random(12345);

        [Fact]
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
                Assert.Contains(b, values);
                Debug.WriteLine(b);
            }
        }

        [Fact]
        public void NextChar_500000()
        {
            // action
            var values = new List<char>(500000);
            for (var i = 0; i < 500000; i++)
            {
                values.Add(_random.NextChar());
            }

            // assert
            Assert.Contains(char.MinValue, values);
            Assert.Contains(char.MaxValue, values);
        }
    }
}