namespace Labb2_Linq.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Klass>? Classes { get; set; } = new List<Klass>();
        public virtual ICollection<Teacher>? Teachers { get; set; } =new List<Teacher>();
    }
}
