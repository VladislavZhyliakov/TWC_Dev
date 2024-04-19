using System.ComponentModel.DataAnnotations;

namespace TWC_DatabaseLayer.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        public int SenderId { get; set; }
        public int ChatId { get; set; }
        public string MessageText { get; set; }
        public DateTime Sent {  get; set; } = DateTime.Now;
        public Chat Chat { get; set; }

    }
}
