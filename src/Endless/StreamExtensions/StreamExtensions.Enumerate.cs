using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Endless
{
    /// <summary>
    /// Extensions to <see cref="Stream" />
    /// </summary>
    public static partial class StreamExtensions
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

        private static void SeekToBeginning(Stream stream)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));

            if (!stream.CanSeek)
                throw new NotSupportedException("Stream doesn't support seek.");

            stream.Seek(0, SeekOrigin.Begin);
        }
    }
}