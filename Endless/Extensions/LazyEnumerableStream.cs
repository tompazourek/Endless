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
    /// The stream provides <see cref="Stream"/>-like interface to <see cref="IEnumerable{T}"/> of bytes.
    /// Is uses underlying <see cref="MemoryStream"/> to store the data from the source <see cref="IEnumerable{T}"/>.
    /// The data is stored on-demand, which makes the reading of the <see cref="IEnumerable{T}"/> lazy.
    /// This allows for infinite enumerables to be the input of this stream.
    /// </summary>
    /// <remarks>
    /// No byte from the underlying enumerable should be enumerated twice. All the bytes that were already read are written in <see cref="MemoryStream"/>.
    /// </remarks>
    internal class LazyEnumerableStream : Stream
    {
        #region Stream loading implementation

        /// <summary>
        /// Enumerator of the bytes 
        /// </summary>
        private readonly IEnumerator<byte> _enumerator;

        /// <summary>
        /// Memory stream that contains the required bytes
        /// </summary>
        private readonly MemoryStream _memoryStream;

        /// <summary>
        /// The total length of bytes
        /// </summary>
        private long? _length;

        /// <summary>
        /// How many bytes were already loaded to the memory stream
        /// </summary>
        private long _loadedBytes;

        /// <summary>
        /// True if all the bytes have been enumerated
        /// </summary>
        private bool _enumeratedAllBytes;

        /// <summary>
        /// Ensures that the number of bytes is loaded in tne memory stream
        /// </summary>
        private void EnsureLoadedBytes(long requiredBytes)
        {
            if (_enumeratedAllBytes)
                return;

            if (requiredBytes <= _loadedBytes)
                return;

            long newBytesCount = requiredBytes - _loadedBytes;
            IEnumerable<byte> newData = TakeBytes(newBytesCount);

            long writtenCount = WriteToStream(newData);
            _loadedBytes += writtenCount;
            if (_enumeratedAllBytes)
                _length = _loadedBytes;
        }

        /// <summary>
        /// Ensures that all bytes were loaded in the memory stream
        /// </summary>
        private void EnsureLoadedAllBytes()
        {
            if (_enumeratedAllBytes)
                return;

            if (_loadedBytes == _length)
                return;

            IEnumerable<byte> newData = TakeAllBytes();
            long writtenCount = WriteToStream(newData);
            _loadedBytes += writtenCount;
            _length = _loadedBytes;
        }

        /// <summary>
        /// Enumerates next number of bytes from the enumerator
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        private IEnumerable<byte> TakeBytes(long count)
        {
            if (count <= 0)
                throw new InvalidOperationException(string.Format("The number of bytes read must be a number greater than zero, {0} given.", count));

            long returnedBytes = 0;
            while (_enumerator.MoveNext())
            {
                yield return _enumerator.Current;
                returnedBytes++;
                if (returnedBytes == count)
                    yield break;
            }
            _enumeratedAllBytes = true;
        }

        /// <summary>
        /// Enumerates all remaining bytes from the enumerator
        /// </summary>
        /// <returns></returns>
        private IEnumerable<byte> TakeAllBytes()
        {
            while (_enumerator.MoveNext())
            {
                yield return _enumerator.Current;
            }
            _enumeratedAllBytes = true;
        }

        /// <summary>
        /// Writes data to stream and returns the number of written bytes
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private long WriteToStream(IEnumerable<byte> data)
        {
            var position = _memoryStream.Position;
            long writtenBytes = _memoryStream.WriteBuffered(data);
            _memoryStream.Seek(position, SeekOrigin.Begin);
            return writtenBytes;
        }

        #endregion

        #region Constructor

        public LazyEnumerableStream(IEnumerable<byte> bytes)
        {
            if (bytes == null) throw new ArgumentNullException("bytes");
            _enumerator = bytes.GetEnumerator();
            _memoryStream = new MemoryStream();
        }

        #endregion

        #region Stream overrides

        public override bool CanRead
        {
            get { return true; }
        }

        public override bool CanSeek
        {
            get { return true; }
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override long Length
        {
            get
            {
                EnsureLoadedAllBytes();
                return _memoryStream.Length;
            }
        }

        public override long Position
        {
            get { return _memoryStream.Position; }
            set
            {
                EnsureLoadedBytes(value);
                _memoryStream.Position = value;
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (!disposing) return;
            _memoryStream.Dispose();
            _enumerator.Dispose();
        }

        public override void Flush()
        {
            throw new NotSupportedException("Stream is read-only.");
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            switch (origin)
            {
                case SeekOrigin.Begin:
                    EnsureLoadedBytes(offset);
                    break;
                case SeekOrigin.Current:
                    EnsureLoadedBytes(_memoryStream.Position + offset);
                    break;
                case SeekOrigin.End:
                    EnsureLoadedAllBytes();
                    break;
                default:
                    throw new ArgumentOutOfRangeException("origin");
            }
            return _memoryStream.Seek(offset, origin);
        }

        public override void SetLength(long value)
        {
            throw new NotSupportedException("Stream is read-only.");
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            long requiredBytes = _memoryStream.Position + count;
            EnsureLoadedBytes(requiredBytes);
            return _memoryStream.Read(buffer, offset, count);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotSupportedException("Stream is read-only.");
        }

        #endregion
    }
}