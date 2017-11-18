using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using Xunit;

namespace Endless.Tests
{
    public partial class StreamExtensionsTests
    {
        // ReSharper disable FunctionNeverReturns

        [SuppressMessage("ReSharper", "IteratorNeverReturns")]
        private static IEnumerable<byte> GetTestBytes(IDictionary<long, int> enumeratedStatistics = null)
        {
            var random = new Random(4);
            long currentPosition = 0;
            while (true)
            {
                var b = random.NextByte();
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

        [Fact]
        public void BytesToStream_EnumeratedOnce()
        {
            // arrange
            const int bytesCount = 10 * 1024;
            var statistics = new Dictionary<long, int>();
            var bytes = GetTestBytes(statistics).Take(bytesCount);

            // action
            using (var stream = bytes.ToStream())
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
            Assert.Equal(bytesCount, statistics.Keys.Count);
            foreach (var enumeratedByte in statistics)
            {
                Assert.Equal(1, enumeratedByte.Value);
            }
        }

        [Fact]
        [SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
        public void BytesToStream_StreamReader()
        {
            var bytes = GetTestBytes().Take(4096);

            var getLineLength = new Func<Stream, int>(stream =>
            {
                using (var streamReader = new StreamReader(stream))
                {
                    var line = streamReader.ReadLine();
                    return line.Length;
                }
            });

            int bytesStreamLineLength;
            using (var stream = bytes.ToStream())
            {
                bytesStreamLineLength = getLineLength(stream);
            }

            int memoryStreamLineLength;
            using (Stream stream = new MemoryStream(bytes.ToArray()))
            {
                memoryStreamLineLength = getLineLength(stream);
            }

            Assert.Equal(memoryStreamLineLength, bytesStreamLineLength);
        }
    }
}