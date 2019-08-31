using System;

namespace Intillegio.Common.ViewModels.Admin
{
    public class AdminArticleViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string CategoryName { get; set; }

        public DateTime Date { get; set; }

        public int NumberOfCategories { get; set; }
    }
}
