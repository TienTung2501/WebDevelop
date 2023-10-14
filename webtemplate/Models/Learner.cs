namespace webtemplate.Models
{
    public class Learner /* Người học*/
    {
        public Learner() { 
        Enrollments =new HashSet<Enrollment>();
        }
        public int LearnerID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public  DateTime EnrollmentDate { get; set; }
        public int MajorID { get; set; }
        public virtual Major? Major { get; set; }// lúc ta tạo mới learner ta không cần thêm trường này. từ người học có thể tham chiếu đến người học đó đăng kí cái gì?
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
