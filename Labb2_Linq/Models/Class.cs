namespace Labb2_Linq.Models
{
    public class Class
    {
        public int ClassId { get; set; }
        public string Name { get; set; }
        public ICollection<Student> Students { get; set; } = new List<Student>();
        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
