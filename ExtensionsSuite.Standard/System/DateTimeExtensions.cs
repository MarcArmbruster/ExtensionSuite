namespace System
{
    using System.Data;
    using System.Globalization;
    using System.Text.RegularExpressions;

    public static class DateTimeExtensions
    {
        /// <summary>
        /// The current culture info.
        /// </summary>
        private static readonly CultureInfo Culture = System.Globalization.CultureInfo.CurrentCulture;

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
            => value >= startOfPeriod && value <= endOfPeriod;        

        /// <summary>
        /// Determines whether the specified value is between (incl. period border values).
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="startOfPeriod">The start of period.</param>
        /// <param name="endOfPeriod">The end of period.</param>
        /// <returns>
        ///   <c>true</c> if the specified value is between; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsBetween(this DateTime value, DateTime startOfPeriod, DateTime endOfPeriod)
            => value >= startOfPeriod && value <= endOfPeriod;

        /// <summary>
        /// Adds a number of weeks (7 days) to a given date.
        /// </summary>
        /// <param name="date">The date to add weeks to.</param>
        /// <param name="count">The number of weeks to add.</param>
        /// <returns>The translated date.</returns>
        public static DateTime AddWeeks(this DateTime date, int count) => date.AddDays(7 * count);

        /// <summary>
        /// Adds a number of weeks (7 days) to a given date.
        /// </summary>
        /// <param name="date">The date to add weeks to.</param>
        /// <param name="count">The number of weeks to add.</param>
        /// <returns>The translated date.</returns>
        public static DateTime? AddWeeks(this DateTime? date, int count)
            => date.HasValue ? (DateTime?)date.Value.AddDays(7 * count) : null;

        public static bool IsFuture(this DateTime value) => value > DateTime.Now;
        public static bool IsFuture(this DateTime? value) => value.HasValue ? value > DateTime.Now : false;
        public static bool IsPast(this DateTime value) => value < DateTime.Now;
        public static bool IsPast(this DateTime? value) => value.HasValue ? value < DateTime.Now : false;

        /// <summary>
        /// Compares two dates for equality.
        /// </summary>
        /// <param name="dt1">Date1.</param>
        /// <param name="dt2">Date2.</param>
        /// <returns>True if the dates are equal.</returns>
        public static bool EqualsToSeconds(this DateTime? dt1, DateTime? dt2)
        {
            if (dt1 == null && dt2 == null)
            {
                return true;
            }

            if (dt1.HasValue && dt2.HasValue)
            {
                return dt1.Value.Year == dt2.Value.Year && dt1.Value.Month == dt2.Value.Month && dt1.Value.Day == dt2.Value.Day &&
                       dt1.Value.Hour == dt2.Value.Hour && dt1.Value.Minute == dt2.Value.Minute && Math.Abs(dt1.Value.Second - dt2.Value.Second) <= 1;
            }

            return false;
        }

        /// <summary>
        /// Compares two dates for equality.
        /// </summary>
        /// <param name="dt1">Date1.</param>
        /// <param name="dt2">Date2.</param>
        /// <returns>True if the dates are equal.</returns>
        public static bool EqualsToSeconds(this DateTime dt1, DateTime dt2)
        {
            return dt1.Year == dt2.Year && dt1.Month == dt2.Month && dt1.Day == dt2.Day &&
                   dt1.Hour == dt2.Hour && dt1.Minute == dt2.Minute && Math.Abs(dt1.Second - dt2.Second) <= 1;
        }

        /// <summary>
        /// Compares two dates if they are equal or one is greater or smaller than the other.
        /// </summary>
        /// <param name="dt1">Date1.</param>
        /// <param name="dt2">Date2.</param>
        /// <returns>0 if the dates are equal, 1 if Date1 is greater, -1 if Date 2 is greater.</returns>
        public static int CompareToSeconds(this DateTime? dt1, DateTime? dt2)
        {
            if (dt1 == null && dt2 == null)
            {
                return 0;
            }

            if (dt1.EqualsToSeconds(dt2))
            {
                return 0;
            }

            if (dt1 != null && dt2 == null)
            {
                return 1;
            }

            if (dt1 == null)
            {
                return -1;
            }

            if (dt1 > dt2)
            {
                return 1;
            }

            return -1;
        }

        /// <summary>
        /// Gets the year month string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>Year and Month: Format YYYYMM.</returns>
        public static string ToYearMonthString(this DateTime value)
        {
            return value.Year.ToString(Culture).PadLeft(4, '0') +
                   value.Month.ToString(Culture).PadLeft(2, '0');
        }

        /// <summary>
        /// Gets the year month day string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>Date as string: Format YYYYMMDD.</returns>
        public static string ToYearMonthDayString(this DateTime value)
        {
            return value.Year.ToString(Culture) +
                   value.Month.ToString(Culture).PadLeft(2, '0') +
                   value.Day.ToString(Culture).PadLeft(2, '0');
        }

        /// <summary>
        /// Gets the hour and minutes string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>Time as string: Format HHMM.</returns>
        public static string ToHourMinuteString(this DateTime value)
        {
            return value.Hour.ToString(Culture).PadLeft(2, '0') +
                   value.Minute.ToString(Culture).PadLeft(2, '0');
        }

        /// <summary>
        /// Firsts the day of week.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The first day of the week for the target day.</returns>
        public static DateTime FirstDayOfWeek(this DateTime value) => FirstDayOfWeek(value, DayOfWeek.Monday);

        /// <summary>
        /// Firsts the day of week.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="firstDay">The first day of the WW.</param>
        /// <returns>The first day of the week for the target day.</returns>
        public static DateTime FirstDayOfWeek(this DateTime value, DayOfWeek firstDay)
        {
            DateTime firstDayInWeek = value.Date;
            while (firstDayInWeek.DayOfWeek != firstDay)
            {
                firstDayInWeek = firstDayInWeek.AddDays(-1);
            }

            return firstDayInWeek;
        }
    }
}