using System.ComponentModel.DataAnnotations;

namespace TWC_DatabaseLayer.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public string? PictureURL { get; set; }
        public int MaxMembers { get; set; }
        public List<ProjectMember> Members { get; set; }
        public List<ProjectTag> Tags { get; set; }
    }
}
