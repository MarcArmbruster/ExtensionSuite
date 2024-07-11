namespace System.Collections.Concurrent
{
    using ExtensionsSuite.Standard.Suite;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

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

        public static void AddRange<T>(this ConcurrentBag<T> source, IEnumerable<T> data)
        {
            if (source == null || data == null || !data.Any())
            {
                return;
            }

            foreach (var item in data)
            {
                source.Add(item);
            }
        }
    }
}