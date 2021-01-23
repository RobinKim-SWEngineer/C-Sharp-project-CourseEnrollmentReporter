namespace CourseEnrollmentDetailReporter.Model
{
    class CourseEnrollmentDetailModel
    {
        public int EnrollmentId { get; set; }
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CourseId { get; set; }
        public string CourseCode { get; set; }
    }
}
