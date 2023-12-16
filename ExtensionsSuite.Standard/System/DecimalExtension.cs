namespace TestDataGenerator.Extensions
{
    /// <summary>
    /// Extensions for the Decimal and Decimal? type.
    /// </summary>    
    public static class DecimalExtension
    {
        /// <summary>
        /// Determines whether the specified value is null or zero.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        ///  <c>true</c> if value is null or zero; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNullOrZero(this decimal? value)
        {
            return value == null || value == 0;
        }

        /// <summary>
        /// Determines whether value is not null and not zero.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>True if value is not null and not zero.</returns>
        public static bool IsNotNullAndNotZero(this decimal? value)
        {
            return value != null && value != 0;
        }
    }
}