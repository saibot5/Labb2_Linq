namespace Labb2_Linq.Models
{
    public class Klass
    {
        public int KlassId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Student> Students { get; set; } = new List<Student>();
        public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
