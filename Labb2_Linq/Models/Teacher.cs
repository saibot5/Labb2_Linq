namespace Labb2_Linq.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Course>? Courses { get; set; } = new List<Course>();
    }
}
