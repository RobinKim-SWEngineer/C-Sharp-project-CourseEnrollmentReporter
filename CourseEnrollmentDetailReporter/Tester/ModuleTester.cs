using System;
using System.Data;

namespace CourseEnrollmentDetailReporter.Tester
{
    static class ModuleTester
    {
        //      Test : FormatChange.ConvertToDataTable<T>(List<T> listOfObjects)
        //
        //      Paste below code into Prgram.cs to test ListToDataConverter class
        //
        //      ----- BELOW -----
        //
        //      List<CourseEnrollmentDetailModel> courseEnrollmentDetailModels = new List<CourseEnrollmentDetailModel>();
        //
        //      var courseEnrollmentDetailModel1 = new CourseEnrollmentDetailModel()
        //      { EnrollmentId = 1, CourseId = 125, CourseCode = "Math", StudentId = 1547, FirstName = "Bob", LastName = "Stratil" };
        //
        //      var courseEnrollmentDetailModel2 = new CourseEnrollmentDetailModel()
        //      { EnrollmentId = 2, CourseId = 115, CourseCode = "English", StudentId = 1047, FirstName = "Leni", LastName = "Rasukova" };
        //
        //      var courseEnrollmentDetailModel3 = new CourseEnrollmentDetailModel()
        //      { EnrollmentId = 3, CourseId = 105, CourseCode = "History", StudentId = 847, FirstName = "Steve", LastName = "Jackson" };
        //
        //      courseEnrollmentDetailModels.Add(courseEnrollmentDetailModel1);
        //
        //          courseEnrollmentDetailModels.Add(courseEnrollmentDetailModel2);
        //
        //          courseEnrollmentDetailModels.Add(courseEnrollmentDetailModel3);
        //
        //          DataTable dataTable = FormatChange.ConvertToDataTable(courseEnrollmentDetailModels);
        //
        //      ModuleTester.PrintDataTable(dataTable);
        //
        //      ----- END -----

        public static void PrintDataTable(DataTable dataTable)
        {
            PrintTitleRow(dataTable);
            
            PrintDataRows(dataTable);
        }

        private static void PrintTitleRow(DataTable dataTable)
        {
            Console.WriteLine("\n\n** Column names :\n");
            foreach (DataColumn column in dataTable.Columns)
            {
                Console.WriteLine($"   {column.ColumnName}");
            }
        }

        private static void PrintDataRows(DataTable dataTable)
        {
            Console.WriteLine("\n** Row values :\n");
            foreach (DataRow row in dataTable.Rows)
            {
                foreach (DataColumn column in dataTable.Columns)
                {
                    Console.WriteLine($"   {row[column.ColumnName]}");
                }
                Console.WriteLine("\n   -----------\n");
            }
        }
    }
}
