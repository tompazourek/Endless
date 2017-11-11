using System;
using System.Collections;
using System.Collections.Generic;

namespace Endless
{
    /// <summary>
    ///     <see cref="ICachedEnumerable{T}" />
    /// </summary>
    internal class CachedEnumerable<T> : ICachedEnumerable<T>
    {
        private readonly LinkedList<T> _cache = new LinkedList<T>();
        private readonly IEnumerator<T> _sourceEnumerator;
        private bool _disposed;

        internal CachedEnumerable(IEnumerable<T> source)
        {
            _sourceEnumerator = source.GetEnumerator();
        }

        public void Dispose()
        {
            if (_disposed) return;
            _disposed = true;
            _sourceEnumerator.Dispose();
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (_disposed)
                throw new ObjectDisposedException("CachedEnumerable was already disposed");

            return new CachedEnumerator<T>(_cache.GetEnumerator(), _sourceEnumerator, this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class CachedEnumerator<TT> : IEnumerator<TT>
        {
            private readonly IEnumerator<TT> _first;
            private readonly CachedEnumerable<TT> _parent;
            private readonly IEnumerator<TT> _second;
            private bool _switched; // switched from first to second

            public CachedEnumerator(IEnumerator<TT> firstEnumerator, IEnumerator<TT> secondEnumerator, CachedEnumerable<TT> parent)
            {
                _first = firstEnumerator;
                _second = secondEnumerator;
                _parent = parent;
                Current = _first.Current;
            }

            public void Dispose()
            {
                _first.Dispose();
            }

            public bool MoveNext()
            {
                if (!_switched && _first.MoveNext())
                {
                    Current = _first.Current;
                    return true;
                }
                _switched = true;
                if (_second.MoveNext())
                {
                    Current = _second.Current;
                    _parent._cache.AddLast(Current); // add to cache
                    return true;
                }
                return false;
            }

            public void Reset()
            {
                _first.Reset();
            }

            public TT Current { get; private set; }

            object IEnumerator.Current => Current;
        }
    }
}