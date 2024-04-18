using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TWC_DatabaseLayer.Models
{
    public class PasswordSalt
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public byte[] Salt { get; set; }
    }
}
