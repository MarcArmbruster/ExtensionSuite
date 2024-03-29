﻿namespace System
{
    public static class DoubleExtensions
    {
        /// <summary>
        /// Determines whether the specified value is null or zero.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        ///  <c>true</c> if value is null or zero; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNullOrZero(this double? value)
        {
            return value == null || value == 0;
        }

        /// <summary>
        /// Determines whether value is not null and not zero.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>True if value is not null and not zero.</returns>
        public static bool IsNotNullAndNotZero(this double? value)
        {
            return value != null && value != 0;
        }

        /// <summary>
        /// Determines whether the specified value is between (incl. boundary values).
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="lowerBound">The lower boundary.</param>
        /// <param name="upperBound">The upper boundary.</param>
        /// <returns>
        ///   <c>true</c> if the specified value is between; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsBetween(this double? value, double? lowerBound, double? upperBound)
            => value >= lowerBound && value <= upperBound;
    }
}