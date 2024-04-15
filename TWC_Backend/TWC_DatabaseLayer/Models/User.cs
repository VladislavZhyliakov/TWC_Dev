using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWC_DatabaseLayer.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ProfilePictureURL{ get; set; }
        public string Email { get; set; }
        public byte[] Password { get; set; }
        public int Age { get; set; }
        public int Sex { get; set; }
        public string PhoneNumber { get; set; }
        public List<ProjectMember> JoinedProjects { get; set; }
        public List<UserTag> Tags { get; set; }
    }
}
