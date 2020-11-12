using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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

        public DateTime Date { get; set; }

        public string Language { get; set; }

        [StringLength(2048, ErrorMessage = "Привышен лимит максимально длинны пути, сократите путь к файлу")]
        public string ImgUrl { get; set; }
    }
}
