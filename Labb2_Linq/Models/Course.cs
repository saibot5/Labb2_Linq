namespace Labb2_Linq.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Klass>? Classes { get; set; } = new List<Klass>();
        public ICollection<Teacher>? Teachers { get; set; } =new List<Teacher>();
    }
}
