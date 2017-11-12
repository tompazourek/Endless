namespace Endless
{
    /// <summary>
    /// Natural numbers
    /// </summary>
    public static class Natural
    {
        /// <summary>
        /// Sequence of natural numbers with zero (0, 1, 2, 3, ...)
        /// </summary>
        public static IFromEnumerable<int> NumbersWithZero => Enumerate.From(0);

        /// <summary>
        /// Sequence of natural numbers (1, 2, 3, ...)
        /// </summary>
        public static IFromEnumerable<int> Numbers => Enumerate.From(1);
    }
}