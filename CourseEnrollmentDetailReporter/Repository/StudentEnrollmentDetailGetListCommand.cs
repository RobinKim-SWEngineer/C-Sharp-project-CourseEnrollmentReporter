using CourseEnrollmentDetailReporter.Model;
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;

namespace CourseEnrollmentDetailReporter.Repository
{
    class StudentEnrollmentDetailGetListCommand
    {
        private string _stringConnection = @"Data Source=DESKTOP-4M1TTU8\SQLEXPRESS;Initial Catalog=StudentEnrollment;Integrated Security=True";
        private string _storedProName = "ViewEnrollmentDetail";

        public List<CourseEnrollmentDetailModel> GetList()
        {
            using (SqlConnection connection = new SqlConnection(_stringConnection))
            {
                return connection.Query<CourseEnrollmentDetailModel>(_storedProName, commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}
