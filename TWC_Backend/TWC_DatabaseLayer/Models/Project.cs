using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWC_DatabaseLayer.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public string PictureURL { get; set; }
        public int MaxMembers { get; set; }
        public List<ProjectMember> Members { get; set; }
        public List<ProjectTag> Tags { get; set; }
    }
}
