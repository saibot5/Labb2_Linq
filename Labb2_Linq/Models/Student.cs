namespace Labb2_Linq.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ClassId { get; set; }
       public Class Class { get; set; }
    }
}
