using CourseEnrollmentDetailReporter.Model;
using CourseEnrollmentDetailReporter.Repository;
using CourseEnrollmentDetailReporter.Worker;
using System.Collections.Generic;
using System.Data;

namespace CourseEnrollmentDetailReporter
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                StudentEnrollmentDetailGetListCommand studentEnrollmentDetailGetListCommand = new StudentEnrollmentDetailGetListCommand();
                List<CourseEnrollmentDetailModel> enrollmentDetailModels = studentEnrollmentDetailGetListCommand.GetList();

                DataTable dataTable = FormatChanger.ConvertToDataTable(enrollmentDetailModels);

                ExcelDocumentExporter.Export(dataTable, @"C:\SoftwareDevelopment\EnrollmentDetailReport.xlsx");
            }
            catch (System.Exception exception)
            {
                System.Console.WriteLine(exception.Message);
            }
        }
    }
}
