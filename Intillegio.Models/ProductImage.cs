namespace Intillegio.Models
{
    public class ProductImage : BaseId
    {
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public string Image135X135 { get; set; }
    }
}
