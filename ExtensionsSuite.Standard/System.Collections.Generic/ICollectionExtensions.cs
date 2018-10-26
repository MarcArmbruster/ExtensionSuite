using System.Linq;
using ExtensionsSuite.Standard.Suite;

namespace System.Collections.Generic
{
    public static class CollectionExtension
    {
        /// <summary>
        /// Adds a range of items to the source collection.
        /// </summary>
        /// <typeparam name="T">The item type.</typeparam>
        /// <param name="source">The source collection.</param>
        /// <param name="items">The items to add to the source collection.</param>
        public static void AddRange<T>(this ICollection<T> source, IEnumerable<T> items)
        {
            ValueChecker.ThrowIfNull(source);

            if (source is List<T> list)
            {
                list.AddRange(items);
            }
            else
            {
                foreach (T item in items)
                {
                    source.Add(item);
                }
            }
        }

        /// <summary>
        /// Removes a range of items from the source collection.
        /// </summary>
        /// <typeparam name="T">The item type.</typeparam>
        /// <param name="source">The source collection.</param>
        /// <param name="items">The items to remove from the source collection.</param>
        public static void RemoveRange<T>(this ICollection<T> source, IEnumerable<T> items)
        {
            ValueChecker.ThrowIfNull(source);

            foreach (T item in items.ToList())
            {
                source.Remove(item);
            }
        }
    }
}
