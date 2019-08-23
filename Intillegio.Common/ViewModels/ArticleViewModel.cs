using System;

namespace Intillegio.Common.ViewModels
{
    public class ArticleViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Content { get; set; }

        public string CategoryName { get; set; }

        public string Image65X65 { get; set; }

        public string Image390X245 { get; set; }
      
        public string Image350X220 { get; set; }

        public string VideoImage400X250 { get; set; }

        public string Image825X530 { get; set; }

        public DateTime Date { get; set; }
    }
}
