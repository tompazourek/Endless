using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endless
{
    internal class DynamicFromThenToEnumerator<T> : IFromThenToEnumerator<T> where T : struct
    {
        private T? _current;
        private T _distance;
        private T _then;

        internal DynamicFromThenToEnumerator(T from, T? then = null, T? to = null)
        {
            From = from;
            unchecked
            {
                Then = then ?? Add(from, One);
            }
            To = to;
        }

        public T From { get; private set; }

        public T Then
        {
            get { return _then; }
            private set
            {
                _then = value;
                unchecked
                {
                    _distance = Subtract(_then, From);
                }
            }
        }

        public T? To { get; private set; }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (!_current.HasValue)
            {
                if (To.HasValue && EqualTo(From, To.Value))
                {
                    _current = From;
                    return true;
                }

                if (EqualTo(From, Then))
                {
                    _current = From;
                    return true;
                }
            }

            if (EqualTo(_distance, default(T)))
                return false;

            T nextValue;
            unchecked
            {
                nextValue = _current.HasValue ? Add(_current.Value, _distance) : _current = From;
            }

            if (To.HasValue)
            {
                if (LessThan(From, Then) && GreaterThan(nextValue, To))
                    return false;

                if (GreaterThan(From, Then) && LessThan(nextValue, To))
                    return false;
            }

            _current = nextValue;
            return true;
        }

        public void Reset()
        {
            _current = From;
        }

        public T Current
        {
            get { return _current ?? default(T); }
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        public IFromThenToEnumerator<T> Clone()
        {
            return new DynamicFromThenToEnumerator<T>(From, Then, To);
        }

        public IFromThenToEnumerator<T> CloneWithThenRestriction(T then)
        {
            return new DynamicFromThenToEnumerator<T>(From, then, To);
        }

        public IFromThenToEnumerator<T> CloneWithToRestriction(T to)
        {
            return new DynamicFromThenToEnumerator<T>(From, Then, to);
        }

        private dynamic Add(dynamic x, dynamic y)
        {
            dynamic result = (T)(x + y);
            return result;
        }

        private dynamic Subtract(dynamic x, dynamic y)
        {
            dynamic result = (T)(x - y);
            return result;
        }

        private bool EqualTo(dynamic x, dynamic y)
        {
            bool result = x == y;
            return result;
        }

        private bool LessThan(dynamic x, dynamic y)
        {
            bool result = x < y;
            return result;
        }

        private bool GreaterThan(dynamic x, dynamic y)
        {
            bool result = x > y;
            return result;
        }

        private static dynamic One
        {
            get
            {
                dynamic zero = default(T);
                var one = ++zero;
                return one;
            }
        }
    }
}