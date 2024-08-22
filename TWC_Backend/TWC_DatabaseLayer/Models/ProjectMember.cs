﻿using System.ComponentModel.DataAnnotations;

namespace TWC_DatabaseLayer.Models
{
    public class ProjectMember
    {
        [Key]
        public int Id { get; set; }
        public int ProjectId { get; set; }
        //public Project Project { get; set; }
        public int UserId { get; set; }
        //public User User { get; set; }
        public bool IsOwner { get; set; } = false;
    }
}
