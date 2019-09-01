using System.ComponentModel.DataAnnotations;

namespace Intillegio.Common.ViewModels.Admin
{
   public class AdminProductViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        [Display(Name = "Stock Keeping Unit")]
        public string StockKeepingUnit { get; set; }
    }
}
