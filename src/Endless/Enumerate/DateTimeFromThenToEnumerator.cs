using System;
using System.Collections;

namespace Endless
{
    internal class DateTimeFromThenToEnumerator : IFromThenToEnumerator<DateTime>
    {
        private DateTime? _current;
        private TimeSpan _distance;
        private DateTime _then;

        internal DateTimeFromThenToEnumerator(DateTime from, DateTime? then = null, DateTime? to = null)
        {
            From = from;
            unchecked
            {
                Then = then ?? from.AddDays(1);
            }
            To = to;
        }

        public DateTime From { get; }

        public DateTime Then
        {
            get => _then;
            private set
            {
                _then = value;
                unchecked
                {
                    _distance = _then - From;
                }
            }
        }

        public DateTime? To { get; }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (!_current.HasValue)
            {
                if (To.HasValue && From == To.Value)
                {
                    _current = From;
                    return true;
                }

                if (From == Then)
                {
                    _current = From;
                    return true;
                }
            }

            if (_distance == TimeSpan.Zero)
                return false;

            DateTime nextValue;
            unchecked
            {
                nextValue = _current.HasValue ? _current.Value + _distance : (_current = From).Value;
            }

            if (To.HasValue)
            {
                if (From < Then && nextValue > To)
                    return false;

                if (From > Then && nextValue < To)
                    return false;
            }

            _current = nextValue;
            return true;
        }

        public void Reset()
        {
            _current = From;
        }

        public DateTime Current => _current ?? default(DateTime);

        object IEnumerator.Current => Current;

        public IFromThenToEnumerator<DateTime> Clone()
        {
            return new DateTimeFromThenToEnumerator(From, Then, To);
        }

        public IFromThenToEnumerator<DateTime> CloneWithThenRestriction(DateTime then)
        {
            return new DateTimeFromThenToEnumerator(From, then, To);
        }

        public IFromThenToEnumerator<DateTime> CloneWithToRestriction(DateTime to)
        {
            return new DateTimeFromThenToEnumerator(From, Then, to);
        }
    }
}