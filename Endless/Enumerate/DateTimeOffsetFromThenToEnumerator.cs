#region License

// Copyright (C) Tomáš Pažourek, 2014
// All rights reserved.
// 
// Distributed under MIT license as a part of project Endless.
// https://github.com/tompazourek/Endless

#endregion

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Endless
{
    internal class DateTimeOffsetFromThenToEnumerator : IFromThenToEnumerator<DateTimeOffset>
    {
        private DateTimeOffset? _current;
        private TimeSpan _distance;
        private DateTimeOffset _then;

        internal DateTimeOffsetFromThenToEnumerator(DateTimeOffset from, DateTimeOffset? then = null, DateTimeOffset? to = null)
        {
            From = from;
            unchecked
            {
                Then = then ?? from.AddDays(1);
            }
            To = to;
        }

        public DateTimeOffset From { get; private set; }

        public DateTimeOffset Then
        {
            get { return _then; }
            private set
            {
                _then = value;
                unchecked
                {
                    _distance = _then - From;
                }
            }
        }

        public DateTimeOffset? To { get; private set; }

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

            DateTimeOffset nextValue;
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

        public DateTimeOffset Current
        {
            get { return _current ?? default(DateTimeOffset); }
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        public IFromThenToEnumerator<DateTimeOffset> Clone()
        {
            return new DateTimeOffsetFromThenToEnumerator(From, Then, To);
        }

        public IFromThenToEnumerator<DateTimeOffset> CloneWithThenRestriction(DateTimeOffset then)
        {
            return new DateTimeOffsetFromThenToEnumerator(From, then, To);
        }

        public IFromThenToEnumerator<DateTimeOffset> CloneWithToRestriction(DateTimeOffset to)
        {
            return new DateTimeOffsetFromThenToEnumerator(From, Then, to);
        }
    }
}