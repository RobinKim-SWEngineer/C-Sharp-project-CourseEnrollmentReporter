using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace CourseEnrollmentDetailReporter.Worker
{
    static class FormatChanger
    {
        public static DataTable ConvertToDataTable<T>(List<T> listOfObjects)
        {
            DataTable dataTable = new DataTable();

            PutColumnNames(dataTable, typeof(T));

            PutData<T>(dataTable, listOfObjects);

            return dataTable;
        }

        private static void PutColumnNames(DataTable dataTable, Type objectType)
        {
            foreach (PropertyInfo property in objectType.GetProperties())
            {
                dataTable.Columns.Add(property.Name, property.PropertyType);
            }
        }

        private static void PutData<T>(DataTable dataTable, List<T> listOfObjects)
        {
            foreach (T obj in listOfObjects)
            {
                DataRow dataRow = dataTable.NewRow();
                foreach (PropertyInfo property in typeof(T).GetProperties())
                {
                    dataRow[property.Name] = property.GetValue(obj); 
                }
                dataTable.Rows.Add(dataRow);
            }
        }
    }
}
