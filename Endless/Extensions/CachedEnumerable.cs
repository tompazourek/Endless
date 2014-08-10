﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endless
{
    /// <summary>
    /// <see cref="ICachedEnumerable{T}"/>
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
            private TT _current;
            private bool _switched; // switched from first to second

            public CachedEnumerator(IEnumerator<TT> firstEnumerator, IEnumerator<TT> secondEnumerator, CachedEnumerable<TT> parent)
            {
                _first = firstEnumerator;
                _second = secondEnumerator;
                _parent = parent;
                _current = _first.Current;
            }

            public void Dispose()
            {
                _first.Dispose();
            }

            public bool MoveNext()
            {
                if (!_switched && _first.MoveNext())
                {
                    _current = _first.Current;
                    return true;
                }
                _switched = true;
                if (_second.MoveNext())
                {
                    _current = _second.Current;
                    _parent._cache.AddLast(_current); // add to cache
                    return true;
                }
                return false;
            }

            public void Reset()
            {
                _first.Reset();
            }

            public TT Current
            {
                get { return _current; }
            }

            object IEnumerator.Current
            {
                get { return Current; }
            }
        }
    }
}