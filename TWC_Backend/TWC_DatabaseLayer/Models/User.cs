using System.ComponentModel.DataAnnotations;

namespace TWC_DatabaseLayer.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        public string Name { get; set; } = "";
        public string Surname { get; set; } = "";
        public string? ProfilePictureURL{ get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public int? Sex { get; set; }
        public string PhoneNumber { get; set; } = "";
        public List<ProjectMember>? JoinedProjects { get; set; }
        public List<UserTag>? Tags { get; set; }
        public PasswordSalt PasswordSalt { get; set; }
    }
}
