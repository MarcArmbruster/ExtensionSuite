namespace System.Collections.Generic
{
    using ExtensionsSuite.Standard.Suite;
    using System;
    using System.Data;
    using System.Linq;
    
    /// <summary>
    /// Extensions for the IEnumerable generic.
    /// </summary>
    public static class EnumerableExtension
    {
        public static DataTable ToDataTable<T>(this IEnumerable<T> items) where T : class
        {
            if (items == null)
            {
                throw new ArgumentNullException("items");
            }

            DataTable dt = new DataTable();

            var propertyInfos = typeof(T).GetProperties(
                                              Reflection.BindingFlags.Instance
                                            | Reflection.BindingFlags.Public)
                                         .Where(pi => pi.CanWrite);

            // Create columns
            foreach (var pi in propertyInfos)
            {
                if (pi.CanRead)
                {
                    var col = new DataColumn(pi.Name, pi.PropertyType);
                    dt.Columns.Add(col);
                }
            }

            var itemType = typeof(T);
            foreach (T item in items)
            {
                DataRow newRow = dt.NewRow();
                foreach (var pi in propertyInfos)
                {
                    newRow[pi.Name] = pi.GetValue(item);
                }

                dt.Rows.Add(newRow);
            }
                
            return dt;
        }

        /// <summary>
        /// Returns elements from a sequence that are distinct when compared via a single
        /// specified projection.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <typeparam name="TProj">The projection result type.</typeparam>
        /// <param name="source">The source sequence.</param>
        /// <param name="keySelector">The projection.</param>
        /// <returns>The filtered sequence.</returns>
        public static IEnumerable<T> Distinct<T, TProj>(this IEnumerable<T> source, Func<T, TProj> keySelector)
        {
            var keys = new HashSet<TProj>();

            foreach (var item in source)
            {
                var currentKey = keySelector(item);
                
                // Only items that can be added (that is, no duplicate keys) should be returned
                if (keys.Add(currentKey))
                {
                    yield return item;
                }
            }
        }

        /// <summary>
        /// Concatenates a sequence with a number of additional elements.
        /// </summary>
        /// <typeparam name="T">The element type.</typeparam>
        /// <param name="source">The source sequence.</param>
        /// <param name="additionalElements">The elements to be concatenated with the sequence.</param>
        /// <returns>A sequence consisting of the source elements and the additional elements.</returns>
        public static IEnumerable<T> Concat<T>(this IEnumerable<T> source, params T[] additionalElements) 
            => source.Concat(additionalElements.AsEnumerable());

        /// <summary>
        /// Creates a truly read-only collection from an enumeration of items.
        /// </summary>
        /// <typeparam name="T">The item type.</typeparam>
        /// <param name="source">The source enumeration.</param>
        /// <returns>A read-only collection containing the source items.</returns>
        public static IReadOnlyCollection<T> ToReadOnly<T>(this IEnumerable<T> source) 
            => source.ToList().AsReadOnly();

        /// <summary>
        /// Determines the minimum of a sequence handling null like -infinity.
        /// </summary>
        /// <typeparam name="TSource">The type of the sequence items.</typeparam>
        /// <param name="source">The sequence to be analyzed.</param>
        /// <param name="getValue">The function to be used for getting the item value for comparison.</param>
        /// <returns>Minimum value or null if any item value is null.</returns>
        public static TResult MinAllowingForNull<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> getValue)
            where TSource : class where TResult : class
        {
            Contracts.ThrowIfNull(getValue);

            var sequence = source.ToList();

            if (!sequence.Any())
            {   // minimum of nothing is undefined
                throw new ArgumentOutOfRangeException(nameof(source));
            }

            var firstElement = true;
            var min = default(TResult);
            var comparer = Comparer<TResult>.Default;
            foreach (var element in sequence)
            {
                var value = getValue(element);
                if (firstElement)
                {
                    min = value;
                    firstElement = false;
                }
                else if (element == null)
                {
                    min = default;
                }
                else if (min != null && comparer.Compare(value, min) < 0)
                {
                    min = value;
                }
            }

            return min;
        }

        /// <summary>
        /// Determines the minimum of a sequence handling null like -infinity.
        /// </summary>
        /// <typeparam name="TSource">The type of the sequence items.</typeparam>
        /// <param name="source">The sequence to be analyzed.</param>
        /// <returns>Minimum value or null if any item value is null.</returns>
        public static TSource MinAllowingForNull<TSource>(this IEnumerable<TSource> source) 
            where TSource : class
        {
            return MinAllowingForNull(source, i => i);
        }
    }
}