using System;
using System.ComponentModel.DataAnnotations;
using Books.Enums;

namespace Books.Models
{
    public class BookModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Укажите название книги")]
        [StringLength(200, ErrorMessage = "Слишком длинное название книги, введите название меньше 200 символов")]
        public string Name { get; set; }

        [StringLength(150, ErrorMessage = "Слишком длинное имя автора книги, введите имя меньше 150 символов")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Укажите описание книги")]
        [StringLength(1000, ErrorMessage = "Слишком длинное описание книги, введите описание меньше 1000 символов")]
        public string Description { get; set; }

        public DateTime Date { get; set; }

        public BookLanguage Language { get; set; }

        [Display(Name = "Обложка")]
        public byte[] Cover { get; set; }

        public BookType Type { get;set; }

        public ArticleModel Article { get; set; }
    }
}
