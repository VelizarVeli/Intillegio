namespace Intillegio.Models
{
    public class EventImage : BaseId
    {
        public int EventId { get; set; }
        public virtual Event Event { get; set; }

        public string Image320X405 { get; set; }
    }
}
