
namespace MXM.Entities.Models
{
    public class SendEmailLog
    {
        public Guid LogId { get; set; }
        public string IpAdressClientRequest { get; set; } = null!;
        public DateTime DateCreated { get; set; }
        public string Content { get; set; } = null!;
    }
}
