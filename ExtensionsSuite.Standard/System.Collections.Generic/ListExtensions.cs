using ExtensionsSuite.Standard.Suite;

namespace System.Collections.Generic
{
    public static class ListExtension
    {
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
            ValueChecker.ThrowIfNull(source);

            int index = source.FindIndex(selector);
            if (index == -1)
            {
                return;
            }

            source[index] = replacement;
        }
    }
}