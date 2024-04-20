namespace Labb2_Linq.Models
{
    public class StudentTeacherViewModel
    {
        public Student Student { get; set; }
        public virtual IEnumerable<Teacher> Teachers { get; set; }
    }
}
