using System;

namespace Endless
{
    internal class DecimalFromStepToEnumerator : BaseFromStepToEnumerator<decimal>
    {
        public DecimalFromStepToEnumerator(decimal from, Func<decimal, decimal> step = null, decimal then = default(decimal), decimal to = default(decimal), bool hasThenRestriction = false, bool hasToRestriction = false)
            : base(from, step, then, to, hasThenRestriction, hasToRestriction)
        {
        }

        protected override IFromStepToEnumerator<decimal> Construct(decimal from, Func<decimal, decimal> step, decimal then, decimal to, bool hasThenRestriction, bool hasToRestriction)
            => new DecimalFromStepToEnumerator(from, step, then, to, hasThenRestriction, hasToRestriction);

        protected override decimal Add(decimal x, decimal y) => x + y;
        protected override decimal Subtract(decimal x, decimal y) => x - y;
        protected override bool EqualTo(decimal x, decimal y) => x == y;
        protected override bool LessThan(decimal x, decimal y) => x < y;
        protected override bool GreaterThan(decimal x, decimal y) => x > y;
    }
}