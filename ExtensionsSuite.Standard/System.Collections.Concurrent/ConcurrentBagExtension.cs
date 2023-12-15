namespace System.Collections.Concurrent
{
    using ExtensionsSuite.Standard.Suite;

    public static class ConcurrentBagExtension
    {
        /// <summary>
        /// Clears the specified source.
        /// </summary>
        /// <typeparam name="T">The type of the elements.</typeparam>
        /// <param name="source">The source concurrent bag.</param>
        public static void Clear<T>(this ConcurrentBag<T> source)
        {
            ValueChecker.ThrowIfNull(source);

            while (!source.IsEmpty)
            {
                source.TryTake(out _);
            }
        }
    }
}