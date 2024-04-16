using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TWC_DatabaseLayer.Models
{
    public class Chat
    {
        [Key]
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int UserId1 { get; set; }
        public int UserId2 { get; set; }       
        public List<Message> Messages { get; set; }
    }
}
