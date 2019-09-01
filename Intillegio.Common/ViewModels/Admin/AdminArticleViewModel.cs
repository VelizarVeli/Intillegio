using System;
using System.ComponentModel.DataAnnotations;

namespace Intillegio.Common.ViewModels.Admin
{
    public class AdminArticleViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }

        public DateTime Date { get; set; }

        [Display(Name = "Number of Categories")]
        public int NumberOfCategories { get; set; }
    }
}
