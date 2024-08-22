using System.ComponentModel.DataAnnotations;

namespace TWC_DatabaseLayer.Models
{
    public class Chat
    {
        [Key]
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int User1Id { get; set; }
        public int User2Id { get; set; }       
        public List<Message> Messages { get; set; }
    }
}
