using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWC_DatabaseLayer.Models;

namespace TWC_DatabaseLayer.DTOs
{
    public class ProjectEditDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int MaxMembers { get; set; }
        [Required]
        public string? PictureURL { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
    }
}
