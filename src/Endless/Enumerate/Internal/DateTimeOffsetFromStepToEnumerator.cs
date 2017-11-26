using System;

namespace Endless
{
    internal class DateTimeOffsetFromStepToEnumerator : BaseFromStepToEnumerator<DateTimeOffset>
    {
        public DateTimeOffsetFromStepToEnumerator(DateTimeOffset from, Func<DateTimeOffset, DateTimeOffset> step = null, DateTimeOffset then = default(DateTimeOffset), DateTimeOffset to = default(DateTimeOffset), bool hasThenRestriction = false, bool hasToRestriction = false)
            : base(from, step, then, to, hasThenRestriction, hasToRestriction)
        {
        }

        protected override IFromStepToEnumerator<DateTimeOffset> Construct(DateTimeOffset from, Func<DateTimeOffset, DateTimeOffset> step, DateTimeOffset then, DateTimeOffset to, bool hasThenRestriction, bool hasToRestriction)
            => new DateTimeOffsetFromStepToEnumerator(from, step, then, to, hasThenRestriction, hasToRestriction);

        protected override DateTimeOffset DefaultStep(DateTimeOffset x) => x.AddDays(1);

        protected override Func<DateTimeOffset, DateTimeOffset> GetThenStep()
        {
            TimeSpan distance;
            unchecked
            {
                // ReSharper disable once PossibleInvalidOperationException
                distance = Then - From;
            }

            DateTimeOffset step(DateTimeOffset x)
            {
                // ReSharper disable once RedundantOverflowCheckingContext
                unchecked
                {
                    return x + distance;
                }
            }

            return step;
        }

        protected override DateTimeOffset Add(DateTimeOffset x, DateTimeOffset y) => throw new NotSupportedException();
        protected override DateTimeOffset Subtract(DateTimeOffset x, DateTimeOffset y) => throw new NotSupportedException();
        protected override bool EqualTo(DateTimeOffset x, DateTimeOffset y) => x == y;
        protected override bool LessThan(DateTimeOffset x, DateTimeOffset y) => x < y;
        protected override bool GreaterThan(DateTimeOffset x, DateTimeOffset y) => x > y;
    }
}