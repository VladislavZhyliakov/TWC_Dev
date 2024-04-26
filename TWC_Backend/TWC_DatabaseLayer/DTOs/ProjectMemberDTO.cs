using System.ComponentModel.DataAnnotations;

namespace TWC_DatabaseLayer.DTOs
{
    public class ProjectMemberDTO
    {
        [Required]
        public int ProjectId { get; set; }
        [Required]
        public int UserId {  get; set; }
    }
}
