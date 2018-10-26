using ExtensionsSuite.Standard.Suite;

namespace System.Collections.Generic
{
    public static class IReadOnlyListExtensions
    {
        /// <summary>
        /// Finds the index of a given element in a collection.
        /// </summary>
        /// <typeparam name="T">The item type.</typeparam>
        /// <param name="source">The source collection.</param>
        /// <param name="element">The element to search for.</param>
        /// <returns>The index of the given element. If the collection contains the element, -1 is returned instead.</returns>
        public static int IndexOf<T>(this IReadOnlyList<T> source, T element)
        {
            ValueChecker.ThrowIfNull(source);

            for (int i = 0; i < source.Count; i++)
            {
                if (EqualityComparer<T>.Default.Equals(element, source[i]))
                {
                    return i;
                }
            }

            return -1;
        }
    }
}