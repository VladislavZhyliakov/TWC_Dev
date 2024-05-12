using System.ComponentModel.DataAnnotations;

namespace TWC_DatabaseLayer.Models
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
