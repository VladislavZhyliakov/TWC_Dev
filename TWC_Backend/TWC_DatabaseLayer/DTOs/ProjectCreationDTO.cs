using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWC_DatabaseLayer.DTOs
{
    public class ProjectCreationDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int MaxMembers { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public List<ProjectTagsDTO> Tags { get; set; }


        [Required]
        public int CreatorId { get; set; }
    }
}
