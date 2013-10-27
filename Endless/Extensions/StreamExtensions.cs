using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endless
{
    public static class StreamExtensions
    {
        private const int DefaultBufferSize = 8 * 1024;

        public static IEnumerable<byte> Enumerate(this Stream stream, bool seekToBegining = true)
        {
            if (seekToBegining)
                SeekToBeginning(stream);

            return Generate.Repeat(stream.ReadByte).TakeUntil(-1).Select(x => (byte) x);
        }

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

        public static void Write(this Stream stream, IEnumerable<byte> bytes)
        {
            foreach (var b in bytes)
            {
                stream.WriteByte(b);
            }
        }

        public static void WriteBuffered(this Stream stream, IEnumerable<byte> bytes, int bufferSize = DefaultBufferSize)
        {
            var chunked = bytes.Chunk(bufferSize).ToList();
            for (int index = 0; index < chunked.Count; index++)
            {
                var chunk = chunked[index];
                var buffer = chunk.ToArray();
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