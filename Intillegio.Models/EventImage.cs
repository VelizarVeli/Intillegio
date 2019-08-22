namespace Intillegio.Models
{
    public class EventImage : BaseId
    {
        public int EventId { get; set; }
        public virtual Event Event { get; set; }

        public string Image350X235 { get; set; }
    }
}
