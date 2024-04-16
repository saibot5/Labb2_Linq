namespace Labb2_Linq.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Class> Classes { get; set; } = new List<Class>();
        public ICollection<Teacher> Teachers { get; set; }
    }
}
