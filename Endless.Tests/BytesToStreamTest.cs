#region License

// Copyright (C) Tomáš Pažourek, 2014
// All rights reserved.
// 
// Distributed under MIT license as a part of project Endless.
// https://github.com/tompazourek/Endless

#endregion

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Endless.Tests
{
    [TestFixture]
    public class BytesToStreamTest
    {
        // ReSharper disable FunctionNeverReturns

        private static IEnumerable<byte> GetTestBytes(IDictionary<long, int> enumeratedStatistics = null)
        {
            var random = new Random(4);
            long currentPosition = 0;
            while (true)
            {
                byte b = random.NextByte();
                currentPosition++;

                if (enumeratedStatistics != null)
                {
                    if (enumeratedStatistics.ContainsKey(currentPosition))
                        enumeratedStatistics[currentPosition]++;
                    else
                        enumeratedStatistics.Add(currentPosition, 1);
                }
                //Debug.WriteLine(string.Format("Byte #{0:d5}: {1:d3}", currentPosition, b));
                yield return b;
            }
        }

        // ReSharper restore FunctionNeverReturns

        [Test]
        public void BytesToStream_EnumeratedOnce()
        {
            // arrange
            const int bytesCount = 10 * 1024;
            var statistics = new Dictionary<long, int>();
            IEnumerable<byte> bytes = GetTestBytes(statistics).Take(bytesCount);

            // action
            using (Stream stream = bytes.ToStream())
            {
                const int bufferSize = 200;
                var buffer = new byte[bufferSize];
                stream.Read(buffer, 0, bufferSize);
                stream.Seek(5, SeekOrigin.Begin);
                stream.Read(buffer, 0, bufferSize);
                stream.Seek(-10, SeekOrigin.End);
                stream.Read(buffer, 0, bufferSize);
            }

            // assert
            Assert.AreEqual(bytesCount, statistics.Keys.Count);
            foreach (var enumeratedByte in statistics)
            {
                Assert.AreEqual(1, enumeratedByte.Value);
            }
        }

        [Test]
        public void BytesToStream_StreamReader()
        {
            IEnumerable<byte> bytes = GetTestBytes().Take(4096);

            var getLineLength = new Func<Stream, int>(stream =>
                {
                    using (var streamReader = new StreamReader(stream))
                    {
                        string line = streamReader.ReadLine();
                        return line.Length;
                    }
                });

            int bytesStreamLineLength;
            using (Stream stream = bytes.ToStream())
            {
                bytesStreamLineLength = getLineLength(stream);
            }

            int memoryStreamLineLength;
            using (Stream stream = new MemoryStream(bytes.ToArray()))
            {
                memoryStreamLineLength = getLineLength(stream);
            }

            Assert.AreEqual(memoryStreamLineLength, bytesStreamLineLength);
        }
    }
}