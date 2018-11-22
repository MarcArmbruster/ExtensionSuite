namespace System
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Determines whether the specified value is between (incl. period border values).
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="startOfPeriod">The start of period.</param>
        /// <param name="endOfPeriod">The end of period.</param>
        /// <returns>
        ///   <c>true</c> if the specified value is between; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsBetween(this DateTime? value, DateTime? startOfPeriod, DateTime? endOfPeriod)
        {
            return value >= startOfPeriod && value <= endOfPeriod;
        }

        /// <summary>
        /// Adds a number of weeks (7 days) to a given date.
        /// </summary>
        /// <param name="date">The date to add weeks to.</param>
        /// <param name="count">The number of weeks to add.</param>
        /// <returns>The translated date.</returns>
        public static DateTime AddWeeks(this DateTime date, int count) => date.AddDays(7 * count);
    }
}