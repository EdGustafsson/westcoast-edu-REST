using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("User", Schema = "Users")] 
    public class User
    {
        public int Id { get; set; }
        [Column(TypeName = "VARCHAR(50)")]
        public string FirstName { get; set; }
        [Column(TypeName = "VARCHAR(50)")]
        public string LastName { get; set; }
        [Column(TypeName = "VARCHAR(50)")]
        public string Email { get; set; }
        [Column(TypeName = "VARCHAR(50)")]
        public string PhoneNumber { get; set; }
        [Column(TypeName = "VARCHAR(50)")]
        public string Address { get; set; } 
              
    }
}