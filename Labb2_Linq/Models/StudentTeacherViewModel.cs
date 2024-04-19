namespace Labb2_Linq.Models
{
    public class StudentTeacherViewModel
    {
        public Student Student { get; set; }
        public IEnumerable<Teacher> Teachers { get; set; }
    }
}
