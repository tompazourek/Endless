using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Endless
{
    public static partial class StreamExtensions
    {
        /// <summary>
        /// Writes sequence of bytes to the stream, byte by byte.
        /// </summary>
        /// <param name="stream">The destination stream</param>
        /// <param name="bytes">Sequence of bytes</param>
        /// <returns>The number of bytes written to the stream</returns>
        public static long Write(this Stream stream, IEnumerable<byte> bytes)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));
            if (bytes == null) throw new ArgumentNullException(nameof(bytes));

            long writtenCount = 0;
            foreach (var b in bytes)
            {
                stream.WriteByte(b);
                writtenCount++;
            }
            return writtenCount;
        }

        /// <summary>
        /// Writes sequence of bytes to the stream, buffered.
        /// </summary>
        /// <param name="stream">The destination stream</param>
        /// <param name="bytes">Sequence of bytes</param>
        /// <param name="bufferSize">Size of block, default is 8 KB</param>
        /// <returns>The number of bytes written to the stream</returns>
        public static long WriteBuffered(this Stream stream, IEnumerable<byte> bytes, int bufferSize = DefaultBufferSize)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));
            if (bytes == null) throw new ArgumentNullException(nameof(bytes));

            long writtenCount = 0;
            var chunked = bytes.Chunk(bufferSize).ToList();
            foreach (var chunk in chunked)
            {
                var buffer = chunk.ToArray();
                stream.Write(buffer, 0, buffer.Length);
                writtenCount += buffer.Length;
            }
            return writtenCount;
        }
    }
}