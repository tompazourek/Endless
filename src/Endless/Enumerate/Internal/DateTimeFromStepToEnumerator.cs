using System;

namespace Endless
{
    internal class DateTimeFromStepToEnumerator : BaseFromStepToEnumerator<DateTime>
    {
        public DateTimeFromStepToEnumerator(DateTime from, Func<DateTime, DateTime> step = null, DateTime then = default(DateTime), DateTime to = default(DateTime), bool hasThenRestriction = false, bool hasToRestriction = false)
            : base(from, step, then, to, hasThenRestriction, hasToRestriction)
        {
        }

        protected override IFromStepToEnumerator<DateTime> Construct(DateTime from, Func<DateTime, DateTime> step, DateTime then, DateTime to, bool hasThenRestriction, bool hasToRestriction)
            => new DateTimeFromStepToEnumerator(from, step, then, to, hasThenRestriction, hasToRestriction);

        protected override DateTime DefaultStep(DateTime x) => x.AddDays(1);

        protected override Func<DateTime, DateTime> GetThenStep()
        {
            TimeSpan distance;
            unchecked
            {
                // ReSharper disable once PossibleInvalidOperationException
                distance = Then - From;
            }

            DateTime step(DateTime x)
            {
                // ReSharper disable once RedundantOverflowCheckingContext
                unchecked
                {
                    return x + distance;
                }
            }

            return step;
        }

        protected override DateTime Add(DateTime x, DateTime y) => throw new NotSupportedException();
        protected override DateTime Subtract(DateTime x, DateTime y) => throw new NotSupportedException();
        protected override bool EqualTo(DateTime x, DateTime y) => x == y;
        protected override bool LessThan(DateTime x, DateTime y) => x < y;
        protected override bool GreaterThan(DateTime x, DateTime y) => x > y;
    }
}