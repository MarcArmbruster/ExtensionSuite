using ExtensionsSuite.Standard.Suite;
using ExtensionsSuite.Standard.System;
using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ExtensionsSuite.Standard
{   
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

        /// <summary>
        /// Converts the given string value into an Int32 value.
        /// If converting is not possible 0 will be returned.
        /// To check format use <see cref="IsInt(string)"/> method, please.
        /// </summary>
        /// <param name="source">The string value.</param>
        /// <returns>The integer value.</returns>
        public static int ToInt(this string source, NumericConversionBehavior numericConversionBehavior = NumericConversionBehavior.Default)
        {
            ValueChecker.ThrowIfNull(source);

            int result = default(int);
            if (string.IsNullOrEmpty(source) == true)
            {
                if (numericConversionBehavior == NumericConversionBehavior.ReturnDefaultValueInsteadOfException)
                {
                    return 0;
                }

                throw new FormatException("Cannot convert from empty/null string to Int32!");
            }
            else
            {
                int outNumber;
                if (int.TryParse(source, out outNumber) == true)
                {
                    result = outNumber;
                }
                else
                {
                    if (numericConversionBehavior == NumericConversionBehavior.ReturnDefaultValueInsteadOfException)
                    {
                        return 0;
                    }

                    throw new FormatException($"Cannot convert value {source} to an Int32 value!");
                }
            }

            return result;
        }

        /// <summary>
        /// Converts the given string value into a decimal value.
        /// If converting is not possible 0 will be returned.
        /// To check format use <see cref="IsDecimal(string)"/> method, please.
        /// </summary>
        /// <param name="source">The string value.</param>
        /// <param name="culture">The culture string (e.q. de-DE). Empty string by default. If not given the current culture will be used.</param>
        /// <returns>The decimal value.</returns>
        public static decimal ToDecimal(this string source, string culture = "", NumericConversionBehavior numericConversionBehavior = NumericConversionBehavior.Default)
        {
            ValueChecker.ThrowIfNull(source);

            CultureInfo cultureInfo = null;

            if (string.IsNullOrEmpty(culture) == false)
            {
                cultureInfo = new CultureInfo(culture);
            }
            else
            {
                cultureInfo = CultureInfo.CurrentCulture;
            }

            decimal result = 0m;
            if (string.IsNullOrEmpty(source) == true)
            {
                if (numericConversionBehavior == NumericConversionBehavior.ReturnDefaultValueInsteadOfException)
                {
                    return 0m;
                }

                throw new FormatException("Cannot convert from empty/null string to decimal!");
            }
            else
            {
                decimal outNumber;
                if (decimal.TryParse(source, NumberStyles.Any, cultureInfo, out outNumber) == true)
                {
                    result = outNumber;
                }
                else
                {
                    if (numericConversionBehavior == NumericConversionBehavior.ReturnDefaultValueInsteadOfException)
                    {
                        return 0m;
                    }

                    throw new FormatException($"Cannot convert value {source} to a decimal value!");
                }
            }

            return result;
        }

        /// <summary>
        /// Verifies if the string can be interpreted as a numeric value.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>True if string represents an integer (Int32) value.</returns>
        public static bool IsNumeric(this string source)
        {
            ValueChecker.ThrowIfNull(source);
            if (string.IsNullOrEmpty(source))
            {
                return false;
            }

            if (source.StartsWith("+"))
            {
                source = source.Substring(1);
            }

            return Regex.IsMatch(source, @"^-*[0-9,\.]+$");
        }

        /// <summary>
        /// Verifies if the string can be interpreted as an Int32 value.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>True if string represents an integer (Int32) value.</returns>
        public static bool IsInt(this string source)
        {
            ValueChecker.ThrowIfNull(source);
            int dummyInt;
            return int.TryParse(source, out dummyInt);
        }

        /// <summary>
        /// Verifies if the string can be interpreted as an Int16 value.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>True if string represents a short (Int16) value.</returns>
        public static bool IsShort(this string source)
        {
            ValueChecker.ThrowIfNull(source);
            short dummyShort;
            return short.TryParse(source, out dummyShort);
        }

        /// <summary>
        /// Verifies if the string can be interpreted as an Int64 value.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>True if string represents a long (Int64) value.</returns>
        public static bool IsLong(this string source)
        {
            ValueChecker.ThrowIfNull(source);
            long dummyLong;
            return long.TryParse(source, out dummyLong);
        }

        /// <summary>
        /// Verifies if the string can be interpreted as a decimal value.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>True if string represents a decimal value.</returns>
        public static bool IsDecimal(this string source)
        {
            ValueChecker.ThrowIfNull(source);
            decimal dummyDecimal;
            return decimal.TryParse(source, out dummyDecimal);
        }
    }
}
