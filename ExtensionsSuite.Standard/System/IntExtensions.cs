namespace System
{
    using System.Diagnostics;

    public static class IntExtensions
    {
        /// <summary>
        /// Verfies wether the value is between the given boundaries (inclusive).
        /// </summary>
        /// <param name="value">The value</param>
        /// <param name="min">Lower boundary.</param>
        /// <param name="max">Upper boundary.</param>
        public static bool IsBetween(this byte value, byte min, byte max)
        {
            return value >= min && value <= max;
        }

        /// <summary>
        /// Verfies wether the value is between the given boundaries (inclusive).
        /// </summary>
        /// <param name="value">The value</param>
        /// <param name="min">Lower boundary.</param>
        /// <param name="max">Upper boundary.</param>
        public static bool IsBetween(this byte? value, byte? min, byte? max)
        {
            return value >= min && value <= max;
        }

        /// <summary>
        /// Verfies wether the value is between the given boundaries (inclusive).
        /// </summary>
        /// <param name="value">The value</param>
        /// <param name="min">Lower boundary.</param>
        /// <param name="max">Upper boundary.</param>
        public static bool IsBetween(this int value, int min, int max)
        {
            return value >= min && value <= max;
        }

        /// <summary>
        /// Verfies wether the value is between the given boundaries (inclusive).
        /// </summary>
        /// <param name="value">The value</param>
        /// <param name="min">Lower boundary.</param>
        /// <param name="max">Upper boundary.</param>
        public static bool IsBetween(this int? value, int? min, int? max)
        {
            return value >= min && value <= max;
        }

        /// <summary>
        /// Verfies wether the value is between the given boundaries (inclusive).
        /// </summary>
        /// <param name="value">The value</param>
        /// <param name="min">Lower boundary.</param>
        /// <param name="max">Upper boundary.</param>
        public static bool IsBetween(this short value, short min, short max)
        {
            return value >= min && value <= max;
        }

        /// <summary>
        /// Verfies wether the value is between the given boundaries (inclusive).
        /// </summary>
        /// <param name="value">The value</param>
        /// <param name="min">Lower boundary.</param>
        /// <param name="max">Upper boundary.</param>
        public static bool IsBetween(this short? value, short? min, short? max)
        {
            return value >= min && value <= max;
        }

        /// <summary>
        /// Verfies wether the value is between the given boundaries (inclusive).
        /// </summary>
        /// <param name="value">The value</param>
        /// <param name="min">Lower boundary.</param>
        /// <param name="max">Upper boundary.</param>
        public static bool IsBetween(this long value, long min, long max)
        {
            return value >= min && value <= max;
        }

        /// <summary>
        /// Verfies wether the value is between the given boundaries (inclusive).
        /// </summary>
        /// <param name="value">The value</param>
        /// <param name="min">Lower boundary.</param>
        /// <param name="max">Upper boundary.</param>
        public static bool IsBetween(this long? value, long? min, long? max)
        {
            return value >= min && value <= max;
        }

        /// <summary>
        /// Returns the ovewrflow-safe calculated new int value - means: watching for overflows on upper and lower boundaries.
        /// If new value overflows the boundary, the boundary value is returned as new value.
        /// </summary>
        /// <param name="existing">The existing value.</param>
        /// <param name="addValue">The add value.</param>
        /// <returns>The overflow checked value.</returns>
        public static int Add(this int existing, int addValue)
        {
            if (existing >= int.MaxValue && addValue > 0)
            {
                Debug.WriteLine("Integer overflow suppressed by extensions method");
                return existing;
            }

            if (existing <= int.MinValue && addValue < 0)
            {
                Debug.WriteLine("Integer overflow suppressed by extensions method");
                return existing;
            }

            long sum = (long)existing + (long)addValue;
            if (sum > (long)int.MaxValue)
            {
                return int.MaxValue;
            }

            if (sum < (long)int.MinValue)
            {
                return int.MinValue;
            }

            return existing + addValue;
        }

        /// <summary>
        /// Returns the ovewrflow-safe calculated new int? value - means: watching for overflows on upper and lower boundaries.
        /// If new value overflows the boundary, the boundary value is returned as new value.
        /// </summary>
        /// <param name="existing">The existing vlaue.</param>
        /// <param name="addValue">The add value.</param>
        /// <returns>The overflow checked value.</returns>
        public static int? Add(this int? existing, int? addValue)
        {
            if (existing == null || addValue == null)
            {
                return null;
            }

            return existing.Value.Add(addValue.Value);
        }

        /// <summary>
        /// Returns the ovewrflow-safe calculated new int? value - means: watching for overflows on upper and lower boundaries.
        /// If new value overflows the boundary, the boundary value is returned as new value.
        /// </summary>
        /// <param name="existing">The existing vlaue.</param>
        /// <param name="subtractValue">The subtract value.</param>
        /// <returns>The overflow checked value.</returns>
        public static int Subtract(this int existing, int subtractValue)
        {
            return existing.Add(-1 * subtractValue);
        }

        /// <summary>
        /// Returns the ovewrflow-safe calculated new int? value - means: watching for overflows on upper and lower boundaries.
        /// If new value overflows the boundary, the boundary value is returned as new value.
        /// </summary>
        /// <param name="existing">The existing vlaue.</param>
        /// <param name="subtractValue">The subtract value.</param>
        /// <returns>The overflow checked value.</returns>
        public static int? Subtract(this int? existing, int? subtractValue)
        {
            return existing.Add(-1* subtractValue);
        }

        /// <summary>
        /// Determines whether the specified value is null or zero.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        ///  <c>true</c> if value is null or zero; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNullOrZero(this int? value)
        {
            return value == null || value == 0;
        }

        /// <summary>
        /// Determines whether the specified value is null or zero.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        ///  <c>true</c> if value is null or zero; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNullOrZero(this short? value)
        {
            return value == null || value == 0;
        }

        /// <summary>
        /// Determines whether the specified value is null or zero.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        ///  <c>true</c> if value is null or zero; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNullOrZero(this byte? value)
        {
            return value == null || value == 0;
        }

        /// <summary>
        /// Determines whether the specified value is null or zero.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        ///  <c>true</c> if value is null or zero; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNullOrZero(this long? value)
        {
            return value == null || value == 0;
        }

        /// <summary>
        /// Determines whether value is not null and not zero.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>True if value is not null and not zero.</returns>
        public static bool IsNotNullAndNotZero(this int? value)
        {
            return value != null && value != 0;
        }

        /// <summary>
        /// Determines whether value is not null and not zero.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>True if value is not null and not zero.</returns>
        public static bool IsNotNullAndNotZero(this short? value)
        {
            return value != null && value != 0;
        }

        /// <summary>
        /// Determines whether value is not null and not zero.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>True if value is not null and not zero.</returns>
        public static bool IsNotNullAndNotZero(this byte? value)
        {
            return value != null && value != 0;
        }

        /// <summary>
        /// Determines whether value is not null and not zero.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>True if value is not null and not zero.</returns>
        public static bool IsNotNullAndNotZero(this long? value)
        {
            return value != null && value != 0;
        }

        /// <summary>
        /// Calculate the Gaussian sum of the given value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The Gaussian Sum.</returns>
        public static int GaussianSum(this int value)
        {
            // https://de.wikipedia.org/wiki/Gau%C3%9Fsche_Summenformel
            return (value * (value + 1)) / 2;
        }
    }
}