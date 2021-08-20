using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("UserCourse", Schema = "UserCourses")]
    public class UserCourse
    {
        public int Id { get; set; }
        [Column(TypeName = "VARCHAR(80)")]
        public int UserId { get; set; }
        public int CourseId { get; set; }
    
    }
}