namespace Intillegio.Models
{
    public class Image
    {
        public int Id { get; set; }

        public int EventId { get; set; }
        public virtual Event Event { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public string LinkToImage { get; set; }
    }
}