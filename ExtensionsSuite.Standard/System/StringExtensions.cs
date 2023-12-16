namespace System
{
    using ExtensionsSuite.Standard.Suite;
    using ExtensionsSuite.Standard.System;
    using System.Globalization;
    using System.Text.RegularExpressions;

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

            string result;
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
            string result;
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
        public static int ToInt32(this string @this, NumericConversionBehavior numericConversionBehavior = NumericConversionBehavior.Default)
        {
            Contracts.ThrowIfNull(@this);

            int result;
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
                if (int.TryParse(@this, out int outNumber) == true)
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
        /// Converts the given string value into an Int64 value.
        /// If converting is not possible 0 will be returned.
        /// To check format use <see cref="IsLong(string)"/> method, please.
        /// </summary>
        /// <param name="this">The string value.</param>
        /// <returns>The integer value.</returns>
        public static long ToInt64(this string @this, NumericConversionBehavior numericConversionBehavior = NumericConversionBehavior.Default)
        {
            Contracts.ThrowIfNull(@this);

            long result;
            if (string.IsNullOrEmpty(@this) == true)
            {
                if (numericConversionBehavior == NumericConversionBehavior.ReturnDefaultValueInsteadOfException)
                {
                    return 0L;
                }

                throw new FormatException("Cannot convert from empty/null string to Int64!");
            }
            else
            {
                if (long.TryParse(@this, out long outNumber) == true)
                {
                    result = outNumber;
                }
                else
                {
                    if (numericConversionBehavior == NumericConversionBehavior.ReturnDefaultValueInsteadOfException)
                    {
                        return 0L;
                    }

                    throw new FormatException($"Cannot convert value {@this} to an Int64 value!");
                }
            }

            return result;
        }

        /// <summary>
        /// Converts the given string value into a double value.
        /// If converting is not possible 0 will be returned.
        /// To check format use <see cref="IsDouble(string)"/> method, please.
        /// </summary>
        /// <param name="this">The string value.</param>
        /// <param name="culture">The culture string (e.q. de-DE). Empty string by default. If not given the current culture will be used.</param>
        /// <returns>The double value.</returns>
        public static double ToDouble(this string @this, string culture = "", NumericConversionBehavior numericConversionBehavior = NumericConversionBehavior.Default)
        {
            Contracts.ThrowIfNull(@this);

            CultureInfo cultureInfo;
            if (string.IsNullOrEmpty(culture) == false)
            {
                cultureInfo = new CultureInfo(culture);
            }
            else
            {
                cultureInfo = CultureInfo.CurrentCulture;
            }

            double result;
            if (string.IsNullOrEmpty(@this) == true)
            {
                if (numericConversionBehavior == NumericConversionBehavior.ReturnDefaultValueInsteadOfException)
                {
                    return 0d;
                }

                throw new FormatException("Cannot convert from empty/null string to double!");
            }
            else
            {
                if (double.TryParse(@this, NumberStyles.Any, cultureInfo, out double outNumber) == true)
                {
                    result = outNumber;
                }
                else
                {
                    if (numericConversionBehavior == NumericConversionBehavior.ReturnDefaultValueInsteadOfException)
                    {
                        return 0d;
                    }

                    throw new FormatException($"Cannot convert value {@this} to a double value!");
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
        /// <returns>The double value.</returns>
        public static decimal ToDecimal(this string @this, string culture = "", NumericConversionBehavior numericConversionBehavior = NumericConversionBehavior.Default)
        {
            Contracts.ThrowIfNull(@this);

            CultureInfo cultureInfo;
            if (string.IsNullOrEmpty(culture) == false)
            {
                cultureInfo = new CultureInfo(culture);
            }
            else
            {
                cultureInfo = CultureInfo.CurrentCulture;
            }

            decimal result;
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
                if (decimal.TryParse(@this, NumberStyles.Any, cultureInfo, out decimal outNumber) == true)
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
        /// Determines whether the specified value has only numbers [0..9].
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        ///   <c>true</c> if the specified value has only numbers; otherwise, <c>false</c>.
        /// </returns>
        public static bool HasOnlyNumbers(this string value)
        {
            var retVal = false;

            if (value == null ||
                value.Contains(" ") ||
                value.Contains("-") ||
                value.Contains("+") ||
                value.Contains("/") ||
                value.Contains("*") ||
                value.Contains(".") ||
                value.Contains(","))
            {
                return false;
            }

            if (value.IsDouble() && Math.Abs(Convert.ToDouble(value) % 1) < 0.00001)
            {
                retVal = true;
            }

            return retVal;

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
            return int.TryParse(@this, out _);
        }

        /// <summary>
        /// Verifies if the string can be interpreted as an Int16 value.
        /// </summary>
        /// <param name="this">The source.</param>
        /// <returns>True if string represents a short (Int16) value.</returns>
        public static bool IsShort(this string @this)
        {
            Contracts.ThrowIfNull(@this);
            return short.TryParse(@this, out _);
        }

        /// <summary>
        /// Verifies if the string can be interpreted as an Int64 value.
        /// </summary>
        /// <param name="this">The source.</param>
        /// <returns>True if string represents a long (Int64) value.</returns>
        public static bool IsLong(this string @this)
        {
            Contracts.ThrowIfNull(@this);
            return long.TryParse(@this, out _);
        }

        /// <summary>
        /// Verifies if the string can be interpreted as a decimal value.
        /// </summary>
        /// <param name="this">The source.</param>
        /// <returns>True if string represents a decimal value.</returns>
        public static bool IsDecimal(this string @this)
        {
            Contracts.ThrowIfNull(@this);
            return decimal.TryParse(@this, out _);
        }

        /// <summary>
        /// Verifies if the string can be interpreted as a double value.
        /// </summary>
        /// <param name="this">The source.</param>
        /// <returns>True if string represents a double value.</returns>
        public static bool IsDouble(this string @this)
        {
            Contracts.ThrowIfNull(@this);
            return double.TryParse(@this, out _);
        }

        /// <summary>
        /// Determines whether the specified value is float.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        ///   <c>true</c> if the specified value is float; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsFloat(this string value)
        {
            return float.TryParse(value, out _);
        }

        /// <summary>
        /// Determines whether [is date time] [the specified value].
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="formatProvider">The format provider.</param>
        /// <param name="styles">The styles.</param>
        /// <returns>
        ///   <c>true</c> if [is date time] [the specified value]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsDateTime(this string value, IFormatProvider formatProvider, DateTimeStyles styles)
        {
            return DateTime.TryParse(value, formatProvider, styles, out _);
        }

        /// <summary>
        /// Converts value to a nullable Int32.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The converted value.</returns>
        public static short? ToNullableShort(this string value)
        {
            return string.IsNullOrEmpty(value) || !value.IsShort() ? (short?)null : short.Parse(value, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Converts value to a nullable Int32.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The converted value.</returns>
        public static int? ToNullableInt(this string value)
        {
            return string.IsNullOrEmpty(value) || !value.IsInt() ? (int?)null : int.Parse(value, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Converts value to a nullable Int32.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The converted value.</returns>
        public static long? ToNullableLong(this string value)
        {
            return string.IsNullOrEmpty(value) || !value.IsLong() ? (long?)null : long.Parse(value, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Limits the string to a max. length. If the string is longer it will be truncated and symbolized with ... at the end.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="maxLength">Length of the max.</param>
        /// <returns>The prepared string.</returns>
        public static string LimitToLength(this string value, int maxLength)
        {
            return LimitToLength(value, maxLength, 2, false);
        }

        /// <summary>
        /// Limits the string to a max. length. If the string is longer it will be truncated and symbolized with ... at the end.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="maxLength">Length of the max.</param>
        /// <param name="numberOfEndDots">The number of end dots.</param>
        /// <param name="isWithWhiteSpace">Length of the max.</param>
        /// <returns>The prepared string.</returns>
        public static string LimitToLength(this string value, int maxLength, int numberOfEndDots, bool isWithWhiteSpace)
        {
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }

            if (value.Length > maxLength)
            {
                if (isWithWhiteSpace)
                {
                    return value.Substring(0, maxLength) + " ...";
                }
                else
                {
                    if (maxLength >= 2)
                    {
                        return value.Substring(0, maxLength - numberOfEndDots) + string.Empty.PadLeft(numberOfEndDots, '.');
                    }
                }
                return ".";
            }

            return value;
        }

        /// <summary>
        /// Duplicates single quote symbols to enable direct sql queries.
        /// </summary>
        /// <param name="value">The string value to handle.</param>
        /// <returns>The prepared string.</returns>
        public static string DuplicateQuote(this string value)
        {
            return value.Replace("'", "''");
        }
    }
}