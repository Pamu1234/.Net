using System.ComponentModel.DataAnnotations.Schema;

namespace FluentApiPlayground.Core.Entities
{
    public class Student
    {
        public int ID { get; set; }
        [Column(TypeName = "varchar(25)")]
        public string LastName { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string FirstMidName { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
