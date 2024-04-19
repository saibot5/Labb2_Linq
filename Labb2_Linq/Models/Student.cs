using System.ComponentModel.DataAnnotations.Schema;

namespace Labb2_Linq.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [ForeignKey("Klass")]
        public int KlassId { get; set; }
       public Klass? Klass { get; set; }
    }
}
