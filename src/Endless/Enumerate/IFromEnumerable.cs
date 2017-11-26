namespace Endless
{
    public interface IFromEnumerable<T> : IFromStepEnumerable<T>
    {
        /// <summary>
        /// Endless collection of numbers starting with the n0 and n1, incremented by their distance.
        /// </summary>
        /// <returns>(n0, n1, n1 + distance, n1 + distance + distance, ...) where distance = n1 - n0</returns>
        IFromStepEnumerable<T> Then(T thenNumber);
    }
}