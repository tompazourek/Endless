using System;

namespace Endless
{
    internal class LongFromStepToEnumerator : BaseFromStepToEnumerator<long>
    {
        public LongFromStepToEnumerator(long from, Func<long, long> step = null, long then = default(long), long to = default(long), bool hasThenRestriction = false, bool hasToRestriction = false)
            : base(from, step, then, to, hasThenRestriction, hasToRestriction)
        {
        }

        protected override IFromStepToEnumerator<long> Construct(long from, Func<long, long> step, long then, long to, bool hasThenRestriction, bool hasToRestriction)
            => new LongFromStepToEnumerator(from, step, then, to, hasThenRestriction, hasToRestriction);

        protected override long Add(long x, long y) => x + y;
        protected override long Subtract(long x, long y) => x - y;
        protected override bool EqualTo(long x, long y) => x == y;
        protected override bool LessThan(long x, long y) => x < y;
        protected override bool GreaterThan(long x, long y) => x > y;
    }
}