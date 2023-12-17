namespace System.Collections.ObjectModel
{
    using ExtensionsSuite.Standard.Suite;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;

    public static class CollectionExtension
    {
        /// <summary>
        /// Executes the action for each item of the collection.
        /// </summary>
        /// <typeparam name="T">The generic type.</typeparam>
        /// <param name="collection">The collection</param>
        /// <param name="action">The action.</param>
        public static void ForEach<T>(this Collection<T> collection, Action<T> action)
        {
            if (collection == null || !collection.Any() || action == null)
            {
                return;
            }

            foreach (var item in collection)
            {
                action.Invoke(item);
            }
        }

        /// <summary>
        /// Replaces the first occurrence of an element matching a given predicate
        /// with a given item.
        /// </summary>
        /// <typeparam name="T">The content type.</typeparam>
        /// <param name="source">The source list.</param>
        /// <param name="selector">The item selecting predicate.</param>
        /// <param name="replacement">The replacing item.</param>
        public static void ReplaceFirst<T>(this List<T> source, Predicate<T> selector, T replacement)
        {
            if (source == null || source.Count == 0 || selector == null)
            {
                return;
            }

            int index = source?.FindIndex(selector) ?? -1;
            if (index == -1)
            {
                return;
            }

            if (source != null)
            {
                source[index] = replacement;
            }
        }

        /// <summary>
        /// Provides an AddRange method for IList<T>.
        /// </summary>
        /// <typeparam name="T">Generic type.</typeparam>
        /// <param name="list">The list.</param>
        /// <param name="data">The data to add.</param>
        public static void AddRange<T>(this IList<T> list, IEnumerable<T> data)
        {
            if (data != null && list != null)
            {
                foreach (T item in data)
                {
                    list.Add(item);
                }
            }
        }

        /// <summary>
        /// Provides an AddRange method for IList<T>.
        /// </summary>
        /// <typeparam name="T">Generic type.</typeparam>
        /// <param name="list">The list.</param>
        /// <param name="data">The data to add.</param>
        /// <param name="predicate">Logic: defines if an item should be added [predicate=true] (or ignored [predicate=false])</param name="predicate">
        public static void AddRange<T>(this IList<T> list, IEnumerable<T> data, Predicate<T> predicate)
        {
            if (data != null && list != null)
            {
                foreach (T item in data.Where(i => predicate.Invoke(i)))
                {
                    list.Add(item);
                }
            }
        }

        /// <summary>
        /// Adds a range of items to the source collection.
        /// </summary>
        /// <typeparam name="T">The item type.</typeparam>
        /// <param name="source">The source collection.</param>
        /// <param name="items">The items to add to the source collection.</param>
        public static void AddRange<T>(this ICollection<T> source, IEnumerable<T> items)
        {
            if (source == null || items == null)
            {
                return;
            }

            if (source is List<T> list)
            {
                list.AddRange(items);
            }
            else
            {
                foreach (T item in items)
                {
                    source?.Add(item);
                }
            }
        }

        /// <summary>
        /// Adds a range of items to the source ConcurrentBag.
        /// </summary>
        /// <typeparam name="T">The item type.</typeparam>
        /// <param name="source">The source collection.</param>
        /// <param name="items">The items to add to the source collection.</param>
        public static void AddRange<T>(this ConcurrentBag<T> source, IEnumerable<T> items)
        {
            if (source == null || items == null)
            {
                return;
            }

            foreach (T item in items)
            {
                source?.Add(item);
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
            if (source == null || source.Count == 0 || items == null)
            {
                return;
            }

            foreach (T item in items.ToList())
            {
                source?.Remove(item);
            }
        }

        /// <summary>
        /// Finds the index of a given element in a collection.
        /// </summary>
        /// <typeparam name="T">The item type.</typeparam>
        /// <param name="source">The source collection.</param>
        /// <param name="element">The element to search for.</param>
        /// <returns>The index of the given element. If the collection contains the element, -1 is returned instead.</returns>
        public static int IndexOf<T>(this IReadOnlyList<T> source, T element)
        {
            if (source == null)
            {
                return -1;
            }

            for (int i = 0; i < source.Count; i++)
            {
                if (EqualityComparer<T>.Default.Equals(element, source[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// Splits a list of data in many chunks.
        /// </summary>
        /// <typeparam name="T">The data type.</typeparam>
        /// <param name="source">The data source.</param>
        /// <param name="chunkSize">The chunk size.</param>
        /// <returns></returns>
        public static List<List<T>> ChunkBy<T>(this IEnumerable<T> source, int chunkSize)
        {
            if (source == null || !source.Any())
            {
                return new List<List<T>>();
            }

            return source
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / chunkSize)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }
    }
}