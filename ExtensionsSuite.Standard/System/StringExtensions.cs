﻿using ExtensionsSuite.Standard.Suite;
using ExtensionsSuite.Standard.System;
using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ExtensionsSuite.Standard
{   
    public static class StringExtensions
    {
        public static string Replace(this string @this, string oldValue, string newValue, StringComparison comparisonType = StringComparison.CurrentCultureIgnoreCase)
        {
            Contracts.ThrowIfNull(@this);
            Contracts.ThrowIfNullOrEmpty(oldValue);
            Contracts.ThrowIfNull(newValue);

            int startIndex = 0;
            while (true)
            {
                startIndex = @this.IndexOf(oldValue, startIndex, comparisonType);
                if (startIndex == -1)
                {
                    break;
                }

                @this = @this.Substring(0, startIndex) + newValue + @this.Substring(startIndex + oldValue.Length);

                startIndex += newValue.Length;
            }

            return @this;
        }

        /// <summary>
        /// Gets the first word out of a separated string value.
        /// </summary>
        /// <param name="this">The string value.</param>
        /// <param name="separator">The separater char: semicolon by default.</param>
        /// <returns>The first word.</returns>
        public static string FirstWord(this string @this, char separator = ';')
        {
            Contracts.ThrowIfNull(@this);
            return FirstWord(@this, separator.ToString());
        }

        /// <summary>
        /// Gets the first word out of a separated string value.
        /// </summary>
        /// <param name="this">The string value.</param>
        /// <param name="separator">The separater string: semicolon by default.</param>
        /// <returns>The first word.</returns>
        public static string FirstWord(this string @this, string separator = ";")
        {
            Contracts.ThrowIfNull(@this);

            string result = string.Empty;
            if (@this.Contains(separator) == true)
            {
                string[] words = @this.Split(separator.ToCharArray());
                result = words[0].Trim();
            }
            else
            {
                result = @this;
            }

            return result;
        }

        /// <summary>
        /// Gets the last word out of a separated string value.
        /// </summary>
        /// <param name="this">The string value.</param>
        /// <param name="separator">The separater char: semicolon by default.</param>
        /// <returns>The last word.</returns>
        public static string LastWord(this string @this, char separator = ';')
        {
            Contracts.ThrowIfNull(@this);
            return LastWord(@this, separator.ToString());
        }

        /// <summary>
        /// Gets the last word out of a separated string value.
        /// </summary>
        /// <param name="this">The string value.</param>
        /// <param name="separator">The separater string: semicolon by default.</param>
        /// <returns>The last word.</returns>
        public static string LastWord(this string @this, string separator = ";")
        {
            Contracts.ThrowIfNull(@this);
            string result = string.Empty;
            if (@this.Contains(separator) == true)
            {
                string[] words = @this.Split(separator.ToCharArray());
                result = words[words.Length - 1].Trim();
            }
            else
            {
                result = @this;
            }

            return result;
        }

        /// <summary>
        /// Checks whether a substring exists in a text. With an option upper and lower case can be ignored.
        /// </summary>
        /// <param name="this">The string value.</param>
        /// <param name="toCheck">Part of string</param>
        /// <param name="comparisonType">Enum StringComparison</param>
        /// <returns></returns>
        public static bool Contains(this string @this, string toCheck, StringComparison comparisonType = StringComparison.CurrentCultureIgnoreCase)
        {
            Contracts.ThrowIfNull(@this);
            Contracts.ThrowIfNull(toCheck);

            if (@this == null || toCheck == null)
            {
                return false;
            }
            else
            {
                return @this.IndexOf(toCheck, comparisonType) >= 0;
            }
        }

        /// <summary>
        /// Converts the given string value into an Int32 value.
        /// If converting is not possible 0 will be returned.
        /// To check format use <see cref="IsInt(string)"/> method, please.
        /// </summary>
        /// <param name="this">The string value.</param>
        /// <returns>The integer value.</returns>
        public static int ToInt(this string @this, NumericConversionBehavior numericConversionBehavior = NumericConversionBehavior.Default)
        {
            Contracts.ThrowIfNull(@this);

            int result = default(int);
            if (string.IsNullOrEmpty(@this) == true)
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
                if (int.TryParse(@this, out outNumber) == true)
                {
                    result = outNumber;
                }
                else
                {
                    if (numericConversionBehavior == NumericConversionBehavior.ReturnDefaultValueInsteadOfException)
                    {
                        return 0;
                    }

                    throw new FormatException($"Cannot convert value {@this} to an Int32 value!");
                }
            }

            return result;
        }

        /// <summary>
        /// Converts the given string value into a decimal value.
        /// If converting is not possible 0 will be returned.
        /// To check format use <see cref="IsDecimal(string)"/> method, please.
        /// </summary>
        /// <param name="this">The string value.</param>
        /// <param name="culture">The culture string (e.q. de-DE). Empty string by default. If not given the current culture will be used.</param>
        /// <returns>The decimal value.</returns>
        public static decimal ToDecimal(this string @this, string culture = "", NumericConversionBehavior numericConversionBehavior = NumericConversionBehavior.Default)
        {
            Contracts.ThrowIfNull(@this);

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
            if (string.IsNullOrEmpty(@this) == true)
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
                if (decimal.TryParse(@this, NumberStyles.Any, cultureInfo, out outNumber) == true)
                {
                    result = outNumber;
                }
                else
                {
                    if (numericConversionBehavior == NumericConversionBehavior.ReturnDefaultValueInsteadOfException)
                    {
                        return 0m;
                    }

                    throw new FormatException($"Cannot convert value {@this} to a decimal value!");
                }
            }

            return result;
        }

        /// <summary>
        /// Verifies if the string can be interpreted as a numeric value.
        /// </summary>
        /// <param name="this">The source.</param>
        /// <returns>True if string represents an integer (Int32) value.</returns>
        public static bool IsNumeric(this string @this)
        {
            Contracts.ThrowIfNull(@this);
            if (string.IsNullOrEmpty(@this))
            {
                return false;
            }

            if (@this.StartsWith("+"))
            {
                @this = @this.Substring(1);
            }

            return Regex.IsMatch(@this, @"^-*[0-9,\.]+$");
        }

        /// <summary>
        /// Verifies if the string can be interpreted as an Int32 value.
        /// </summary>
        /// <param name="this">The source.</param>
        /// <returns>True if string represents an integer (Int32) value.</returns>
        public static bool IsInt(this string @this)
        {
            Contracts.ThrowIfNull(@this);
            int dummyInt;
            return int.TryParse(@this, out dummyInt);
        }

        /// <summary>
        /// Verifies if the string can be interpreted as an Int16 value.
        /// </summary>
        /// <param name="this">The source.</param>
        /// <returns>True if string represents a short (Int16) value.</returns>
        public static bool IsShort(this string @this)
        {
            Contracts.ThrowIfNull(@this);
            short dummyShort;
            return short.TryParse(@this, out dummyShort);
        }

        /// <summary>
        /// Verifies if the string can be interpreted as an Int64 value.
        /// </summary>
        /// <param name="this">The source.</param>
        /// <returns>True if string represents a long (Int64) value.</returns>
        public static bool IsLong(this string @this)
        {
            Contracts.ThrowIfNull(@this);
            long dummyLong;
            return long.TryParse(@this, out dummyLong);
        }

        /// <summary>
        /// Verifies if the string can be interpreted as a decimal value.
        /// </summary>
        /// <param name="this">The source.</param>
        /// <returns>True if string represents a decimal value.</returns>
        public static bool IsDecimal(this string @this)
        {
            Contracts.ThrowIfNull(@this);
            decimal dummyDecimal;
            return decimal.TryParse(@this, out dummyDecimal);
        }
    }
}
