namespace ExtensionsSuite.Standard
{
    using ExtensionsSuite.Standard.Suite;

    public static class StringExtensions
    {
        /// <summary>
        /// Gets the first word out of a separated string value.
        /// </summary>
        /// <param name="source">The string value.</param>
        /// <param name="separator">The separater char: semicolon by default.</param>
        /// <returns>The first word.</returns>
        public static string FirstWord(this string source, char separator = ';')
        {
            ValueChecker.ThrowIfNull(source);
            return FirstWord(source, separator.ToString());
        }

        /// <summary>
        /// Gets the first word out of a separated string value.
        /// </summary>
        /// <param name="source">The string value.</param>
        /// <param name="separator">The separater string: semicolon by default.</param>
        /// <returns>The first word.</returns>
        public static string FirstWord(this string source, string separator = ";")
        {
            ValueChecker.ThrowIfNull(source);

            string result = string.Empty;
            if (source.Contains(separator) == true)
            {
                string[] words = source.Split(separator.ToCharArray());
                result = words[0].Trim();
            }
            else
            {
                result = source;
            }

            return result;
        }

        /// <summary>
        /// Gets the last word out of a separated string value.
        /// </summary>
        /// <param name="source">The string value.</param>
        /// <param name="separator">The separater char: semicolon by default.</param>
        /// <returns>The last word.</returns>
        public static string LastWord(this string source, char separator = ';')
        {
            ValueChecker.ThrowIfNull(source);
            return LastWord(source, separator.ToString());
        }

        /// <summary>
        /// Gets the last word out of a separated string value.
        /// </summary>
        /// <param name="source">The string value.</param>
        /// <param name="separator">The separater string: semicolon by default.</param>
        /// <returns>The last word.</returns>
        public static string LastWord(this string source, string separator = ";")
        {
            ValueChecker.ThrowIfNull(source);
            string result = string.Empty;
            if (source.Contains(separator) == true)
            {
                string[] words = source.Split(separator.ToCharArray());
                result = words[words.Length - 1].Trim();
            }
            else
            {
                result = source;
            }

            return result;
        }
    }
}
