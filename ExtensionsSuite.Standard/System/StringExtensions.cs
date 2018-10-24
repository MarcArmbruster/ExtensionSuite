using ExtensionsSuite.Standard.Suite;

namespace ExtensionsSuite.Standard
{
    public static class StringExtensions
    {
        public static string FirstWord(this string source, char separator = ';')
        {
            ValueChecker.ThrowIfNull(source);
            return FirstWord(source, separator.ToString());
        }

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

        public static string LastWord(this string source, char separator = ';')
        {
            ValueChecker.ThrowIfNull(source);
            return LastWord(source, separator.ToString());
        }

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
