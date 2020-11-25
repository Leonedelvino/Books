using System;
using System.ComponentModel.DataAnnotations;

namespace GeneralSemantics.Models
{
    public class ArticleModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Заголовок")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Описание")]
        public string Description { get; set; }


        [Required]
        [Display(Name = "Время публикации")]
        public DateTime DatePosted { get; set; }
        [Display(Name = "Время последних изменений")]
        public DateTime DateLastModified { get; set; }

        [Required]
        [Display(Name = "Автор")]
        public string Author { get; set; }
        [Display(Name = "Редактор")]
        public string Readactor { get; set; }

        [Required]
        [Display(Name = "Язык")]
        public string Language { get; set; }

        [Required]
        [Display(Name = "Обложка")]
        public byte[] Cover { get; set; }
        public string CoversMimeType { get; set; }

        [Required]
        public string ArticleSection { get; set; }

    }
}
