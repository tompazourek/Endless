using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Endless
{
    /// <summary>
    /// Extensions to <see cref="Stream" />
    /// </summary>
    public static class StreamExtensions
    {
        private const int DefaultBufferSize = 8 * 1024;

        /// <summary>
        /// Reads stream as sequence of bytes. Each byte is read from stream lazily when enumerated.
        /// </summary>
        /// <param name="stream">Input stream</param>
        /// <param name="seekToBegining">Seek to beginning before reading the stream. Default is true.</param>
        public static IEnumerable<byte> Enumerate(this Stream stream, bool seekToBegining = true)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));

            if (seekToBegining)
                SeekToBeginning(stream);

            return Generate.Repeat(stream.ReadByte).TakeUntil(-1).Select(x => (byte)x);
        }

        /// <summary>
        /// Reads stream as sequence of bytes. The stream is read by fixed-size blocks (buffer).
        /// </summary>
        /// <param name="stream">Input stream</param>
        /// <param name="bufferSize">Size of block, default is 8 KB</param>
        /// <param name="seekToBegining">Seek to beginning before reading the stream. Default is true.</param>
        public static IEnumerable<byte> EnumerateBuffered(this Stream stream, int bufferSize = DefaultBufferSize, bool seekToBegining = true)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));

            if (seekToBegining)
                SeekToBeginning(stream);

            var buffer = new byte[bufferSize];
            int bytesRead;

            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
            {
                for (var i = 0; i < bytesRead; i++)
                {
                    yield return buffer[i];
                }
            }
        }

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

        private static void SeekToBeginning(Stream stream)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));

            if (!stream.CanSeek)
                throw new NotSupportedException("Stream doesn't support seek.");

            stream.Seek(0, SeekOrigin.Begin);
        }

        /// <summary>
        /// Provides stream interface to given sequence of bytes. The underlying stream is <see cref="MemoryStream" />,
        /// but the bytes are only written to memory when needed. This allows for infinite sequences.
        /// </summary>
        /// <param name="bytes">Sequence of bytes</param>
        /// <returns>Read-only stream</returns>
        public static Stream ToStream(this IEnumerable<byte> bytes)
        {
            if (bytes == null) throw new ArgumentNullException(nameof(bytes));
            return new LazyEnumerableStream(bytes);
        }
    }
}