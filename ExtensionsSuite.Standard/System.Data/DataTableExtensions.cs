namespace System.Data
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    public static class DataTableExtensions
    {
        public static bool HasColumn(this DataTable dataTable, string columnName)
            => dataTable == null ? false : dataTable.Columns.Contains(columnName);

        public static T GetValue<T>(this DataTable dataTable, int rowId, int columnId)
        {
            if (dataTable == null)
            {
                return default;
            }

            object value = dataTable.GetValue(rowId, columnId);
            if (value is T typedValue)
            {
                return typedValue;
            }

            return default;
        }

        public static object GetValue(this DataTable dataTable, int rowId, int columnId)
        {
            if (dataTable == null)
            {
                return default;
            }

            int rowCount = dataTable.Rows.Count;
            int colCount = dataTable.Columns.Count;

            if (colCount > columnId + 1) 
            {
                throw new IndexOutOfRangeException("Column ID exceeds table size!");
            }

            if (rowCount > rowId + 1)
            {
                throw new IndexOutOfRangeException("Row ID exceeds table size!");
            }

            return dataTable.Rows[rowId].ItemArray[columnId];
        }

        /// <summary>
        /// Copies the data into a List of entities (types and values have to match)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        public static List<T> ToList<T>(this DataTable dataTable) where T : new()
        {
            if (dataTable == null)
            {
                return default;
            }

            List<T> data = new List<T>();
            if (dataTable.Rows.Count == 0)
            {
                return data;
            }

            List<PropertyInfo> propertyInfos = new List<PropertyInfo>();
            for (int colId = 0; colId < dataTable.Rows[0].ItemArray.Length; colId++)
            {
                var property = typeof(T).GetProperty(dataTable.Columns[colId].ColumnName);
                propertyInfos.Add(property);
            }
    
            foreach (var row in dataTable.Rows)
            {
                var item = Activator.CreateInstance(typeof(T));
                var dataRow = (DataRow)row;
                for (int colId = 0; colId < dataRow.ItemArray.Length; colId++) 
                {
                    var property = propertyInfos[colId];
                    if (property != null)
                    {
                        var value = dataRow.ItemArray[colId];
                        property.SetValue(item, value, null);
                    }
                }

                data.Add((T)item);
            }

            return data;
        }
    }
}