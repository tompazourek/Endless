using System;
using System.Numerics;

namespace Endless
{
    internal class BigIntegerFromStepToEnumerator : BaseFromStepToEnumerator<BigInteger>
    {
        public BigIntegerFromStepToEnumerator(BigInteger from, Func<BigInteger, BigInteger> step = null, BigInteger then = default(BigInteger), BigInteger to = default(BigInteger), bool hasThenRestriction = false, bool hasToRestriction = false)
            : base(from, step, then, to, hasThenRestriction, hasToRestriction)
        {
        }

        protected override IFromStepToEnumerator<BigInteger> Construct(BigInteger from, Func<BigInteger, BigInteger> step, BigInteger then, BigInteger to, bool hasThenRestriction, bool hasToRestriction)
            => new BigIntegerFromStepToEnumerator(from, step, then, to, hasThenRestriction, hasToRestriction);

        protected override BigInteger Add(BigInteger x, BigInteger y) => x + y;
        protected override BigInteger Subtract(BigInteger x, BigInteger y) => x - y;
        protected override bool EqualTo(BigInteger x, BigInteger y) => x == y;
        protected override bool LessThan(BigInteger x, BigInteger y) => x < y;
        protected override bool GreaterThan(BigInteger x, BigInteger y) => x > y;
    }
}