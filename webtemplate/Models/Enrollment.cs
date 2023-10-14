namespace webtemplate.Models
{
    public class Enrollment /* bảng này được sinh ra do liên kết nhiều nhiều của course và learner*/
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int LearnerID { get; set; }
        public float Grade { get; set; }
        public Learner? Learner { get; set; }
        public Course? Course { get; set; }
    }
}
