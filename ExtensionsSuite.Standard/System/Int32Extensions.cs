using System.Diagnostics;

namespace System
{
    public static class Int32Extensions
    {
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
                Debug.WriteLine("Integer overflow suppressed by Add() extensions-Method");
                return existing;
            }

            if (existing <= int.MinValue && addValue < 0)
            {
                Debug.WriteLine("Integer overflow suppressed by Add() extensions-Method");
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
        /// Determines whether value is not null and not zero.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>True if value is not null and not zero.</returns>
        public static bool IsNotNullAndNotZero(this int? value)
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
