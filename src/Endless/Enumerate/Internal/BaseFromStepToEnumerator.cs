using System;
using System.Collections;
using System.Collections.Generic;

namespace Endless
{
    internal abstract class BaseFromStepToEnumerator<T> : IFromStepToEnumerator<T>
    {
        #region Constructor

        protected BaseFromStepToEnumerator(T from, Func<T, T> step = null, T then = default(T), T to = default(T), bool hasThenRestriction = false, bool hasToRestriction = false)
        {
            From = from;
            Step = step;
            Then = then;
            To = to;

            HasThenRestriction = hasThenRestriction;
            HasToRestriction = hasToRestriction;

            _lazyInnerIterateEnumerator = new Lazy<IEnumerator<T>>(InnerEnumeratorFactory);
        }

        protected abstract IFromStepToEnumerator<T> Construct(T from, Func<T, T> step, T then, T to, bool hasThenRestriction, bool hasToRestriction);

        #endregion

        #region Internals

        protected T From { get; }
        protected T Then { get; }
        protected bool HasThenRestriction { get; }
        protected Func<T, T> Step { get; }
        protected T To { get; }
        protected bool HasToRestriction { get; }

        private readonly Lazy<IEnumerator<T>> _lazyInnerIterateEnumerator;
        private IEnumerator<T> InnerIterateEnumerator => _lazyInnerIterateEnumerator.Value;
        private IEnumerator<T> InnerEnumeratorFactory() => InnerEnumerableFactory().GetEnumerator();

        private IEnumerable<T> InnerEnumerableFactory()
        {
            Func<T, T> step;
            if (Step != null)
            {
                step = Step;
            }
            else if (HasThenRestriction)
            {
                step = GetThenStep();
            }
            else
            {
                step = DefaultStep;
            }

            var sequence = From.Iterate(step);
            var counter = 0;
            var previousItem = default(T);

            foreach (var item in sequence)
            {
                if (counter++ <= 0)
                {
                }
                else
                {
                    if (EqualTo(item, previousItem))
                    {
                        // no change since previous item
                        yield return previousItem;
                        yield break;
                    }

                    if (HasToRestriction)
                    {
                        // ReSharper disable once PossibleInvalidOperationException
                        if (GreaterThan(item, previousItem) && GreaterThan(item, To))
                        {
                            // increasing, and greater than To
                            if (counter > 2)
                            {
                                yield return previousItem;
                            }
                            yield break;
                        }

                        // ReSharper disable once PossibleInvalidOperationException
                        if (LessThan(item, previousItem) && LessThan(item, To))
                        {
                            // decreesing, and less than To
                            if (counter > 2)
                            {
                                yield return previousItem;
                            }
                            yield break;
                        }
                    }

                    yield return previousItem;
                }

                previousItem = item;
            }

            yield return previousItem;
        }

        #endregion

        #region Enumerator

        public bool MoveNext() => InnerIterateEnumerator.MoveNext();
        public void Reset() => InnerIterateEnumerator.Reset();
        public T Current => InnerIterateEnumerator.Current;
        object IEnumerator.Current => Current;
        public void Dispose() => InnerIterateEnumerator.Dispose();

        #endregion

        #region Cloning

        public IFromStepToEnumerator<T> Clone() => Construct(From, Step, Then, To, HasThenRestriction, HasToRestriction);
        public IFromStepToEnumerator<T> CloneWithThenRestriction(T then) => Construct(From, Step, then, To, true, HasToRestriction);
        public IFromStepToEnumerator<T> CloneWithStepRestriction(Func<T, T> step) => Construct(From, step, Then, To, HasThenRestriction, HasToRestriction);
        public IFromStepToEnumerator<T> CloneWithToRestriction(T to) => Construct(From, Step, Then, to, HasThenRestriction, true);

        #endregion

        #region Dynamic helpers

        protected virtual Func<T, T> GetThenStep()
        {
            T distance;
            unchecked
            {
                // ReSharper disable once PossibleInvalidOperationException
                distance = Subtract(Then, From);
            }

            T step(T x)
            {
                // ReSharper disable once RedundantOverflowCheckingContext
                unchecked
                {
                    return Add(x, distance);
                }
            }

            return step;
        }

        protected virtual T DefaultStep(T x)
        {
            dynamic zero = default(T);
            var one = ++zero;

            return Add(x, one);
        }

        protected abstract T Add(T x, T y);
        protected abstract T Subtract(T x, T y);
        protected abstract bool EqualTo(T x, T y);
        protected abstract bool LessThan(T x, T y);
        protected abstract bool GreaterThan(T x, T y);

        #endregion
    }
}