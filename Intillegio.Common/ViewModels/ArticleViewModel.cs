using System;

namespace Intillegio.Common.ViewModels
{
    public class ArticleViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Content { get; set; }

        public string ArticleCategory { get; set; }

        public string ImageLink { get; set; }

        public DateTime Date { get; set; }
    }
}
