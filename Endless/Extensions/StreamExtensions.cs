using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endless
{
    /// <summary>
    /// Extensions to <see cref="Stream"/>
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
            if (seekToBegining)
                SeekToBeginning(stream);

            return Generate.Repeat(stream.ReadByte).TakeUntil(-1).Select(x => (byte) x);
        }

        /// <summary>
        /// Reads stream as sequence of bytes. The stream is read by fixed-size blocks (buffer).
        /// </summary>
        /// <param name="stream">Input stream</param>
        /// <param name="bufferSize">Size of block, default is 8 KB</param>
        /// <param name="seekToBegining">Seek to beginning before reading the stream. Default is true.</param>
        public static IEnumerable<byte> EnumerateBuffered(this Stream stream, int bufferSize = DefaultBufferSize, bool seekToBegining = true)
        {
            if (seekToBegining)
                SeekToBeginning(stream);

            var buffer = new byte[bufferSize];
            int bytesRead;

            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
            {
                for (int i = 0; i < bytesRead; i++)
                {
                    yield return buffer[i];
                }
            }
        }

        /// <summary>
        /// Writes sequence of bytes to the stream, byte by byte.
        /// </summary>
        /// <param name="stream">The destination stream</param>
        ///  <param name="bytes">Sequence of bytes</param>
        public static void Write(this Stream stream, IEnumerable<byte> bytes)
        {
            foreach (byte b in bytes)
            {
                stream.WriteByte(b);
            }
        }

        /// <summary>
        /// Writes sequence of bytes to the stream, buffered.
        /// </summary>
        /// <param name="stream">The destination stream</param>
        /// <param name="bytes">Sequence of bytes</param>
        /// <param name="bufferSize">Size of block, default is 8 KB</param>
        public static void WriteBuffered(this Stream stream, IEnumerable<byte> bytes, int bufferSize = DefaultBufferSize)
        {
            List<IEnumerable<byte>> chunked = bytes.Chunk(bufferSize).ToList();
            for (int index = 0; index < chunked.Count; index++)
            {
                IEnumerable<byte> chunk = chunked[index];
                byte[] buffer = chunk.ToArray();
                stream.Write(buffer, 0, buffer.Count());
            }
        }

        private static void SeekToBeginning(Stream stream)
        {
            if (!stream.CanSeek)
                throw new NotSupportedException("Stream doesn't support seek.");

            stream.Seek(0, SeekOrigin.Begin);
        }
    }
}