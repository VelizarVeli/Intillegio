namespace Intillegio.Models
{
  public  class EventImage
    {
        public int Id { get; set; }

        public int EventId { get; set; }
        public virtual Event Event { get; set; }
    }
}
