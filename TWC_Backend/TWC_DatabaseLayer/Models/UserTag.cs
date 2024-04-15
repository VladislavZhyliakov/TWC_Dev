using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWC_DatabaseLayer.Models
{
    public class UserTag
    {
        [Key]
        public int Id { get; set; }
        public int TagId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
