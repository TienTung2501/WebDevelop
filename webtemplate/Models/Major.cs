namespace webtemplate.Models
{
    public class Major /* chuyên ngành 1 chuyên ngành có nhiều người học nên sẽ phải có icollection Learners*/
    {
        public Major() { 
        Learners=new HashSet<Learner>();
        }
        public int MajorID { get; set; }
        public string MajorName { get; set;}
        public virtual ICollection<Learner> Learners { get; set; }
    }
}
