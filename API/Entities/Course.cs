using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("Course", Schema = "Courses")]
    public class Course
    {
        public int Id {get; set;}
        [Column(TypeName = "VARCHAR(80)")]
        public string CourseName { get; set; }
        [Column(TypeName = "VARCHAR(80)")]
        public int CourseNumber { get; set; }
        public bool Retired { get; set; }

    }
}