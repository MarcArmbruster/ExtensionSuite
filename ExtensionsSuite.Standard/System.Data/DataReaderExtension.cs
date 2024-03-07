namespace System.Data
{
    /// <summary>
    /// Extension class for data readers.
    /// </summary>
    public static class DataReaderExtension
    {
        /// <summary>
        /// Gets the name of the value for column.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="columnName">Name of the column.</param>
        /// <returns>The extracted value.</returns>
        /// <exception cref="InvalidOperationException"></exception>
        private static object GetValueForColumnName(IDataReader reader, string columnName)
        {
            try
            {
                object value = reader[columnName];
                return value;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Field <{columnName}> could not be found in reader.", ex);
            }
        }

        /// <summary>
        /// Converts the value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <returns>The converted value.</returns>
        /// <exception cref="InvalidOperationException"></exception>
        private static T ConvertValue<T>(object value)
        {
            try
            {
                if (value == null || value == DBNull.Value)
                {
                    return default;
                }

                return (T)value;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Conversion from <{value?.GetType()}> to <{typeof(T)}> failed", ex);
            }
        }

        /// <summary>
        /// Casts the value of a given column name to the nullable type T.
        /// </summary>
        /// <typeparam name="T">The generic type T.</typeparam>
        /// <param name="reader">The data reader.</param>
        /// <param name="columnName">The column name.</param>
        /// <returns>The converted nullable value.</returns>
        public static T? GetNullable<T>(this IDataReader reader, string columnName) where T : struct
        {
            var value = GetValueForColumnName(reader, columnName);
            if (value == null || value == DBNull.Value)
            {
                return null;
            }

            return ConvertValue<T>(value);
        }

        /// <summary>
        /// Casts the value of a given column name to the type T.
        /// </summary>
        /// <typeparam name="T">The generic type T.</typeparam>
        /// <param name="reader">The data reader.</param>
        /// <param name="columnName">The column name.</param>
        /// <returns>The converted value or default value of the given type.</returns>
        public static T GetValue<T>(this IDataReader reader, string columnName)
        {
            var value = GetValueForColumnName(reader, columnName);
            return ConvertValue<T>(value);
        }
    }
}