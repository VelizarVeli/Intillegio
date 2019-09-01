using System;
using System.ComponentModel.DataAnnotations;

namespace Intillegio.Common.ViewModels
{
    public class ArticleViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Content { get; set; }

        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }

        [Display(Name = "Image 65 x 65")]
        public string Image65X65 { get; set; }

        [Display(Name = "Image 390 x2 45")]
        public string Image390X245 { get; set; }
      
        [Display(Name = "Image 350 x 220")]
        public string Image350X220 { get; set; }

        [Display(Name = "Video Image 400 x 250")]
        public string VideoImage400X250 { get; set; }

        [Display(Name = "Image 825 x 530")]
        public string Image825X530 { get; set; }

        public DateTime Date { get; set; }
    }
}
