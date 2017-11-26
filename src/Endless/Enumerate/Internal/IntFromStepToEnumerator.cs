using System;

namespace Endless
{
    internal class IntFromStepToEnumerator : BaseFromStepToEnumerator<int>
    {
        public IntFromStepToEnumerator(int from, Func<int, int> step = null, int then = default(int), int to = default(int), bool hasThenRestriction = false, bool hasToRestriction = false)
            : base(from, step, then, to, hasThenRestriction, hasToRestriction)
        {
        }

        protected override IFromStepToEnumerator<int> Construct(int from, Func<int, int> step, int then, int to, bool hasThenRestriction, bool hasToRestriction)
            => new IntFromStepToEnumerator(from, step, then, to, hasThenRestriction, hasToRestriction);

        protected override int Add(int x, int y) => x + y;
        protected override int Subtract(int x, int y) => x - y;
        protected override bool EqualTo(int x, int y) => x == y;
        protected override bool LessThan(int x, int y) => x < y;
        protected override bool GreaterThan(int x, int y) => x > y;
    }
}