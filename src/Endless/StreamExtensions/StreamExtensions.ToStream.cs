using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Endless
{
    public static partial class StreamExtensions
    {
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