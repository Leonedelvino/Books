using System.Collections.Generic;

namespace Books.Models
{
    public class BookViewModel
    {
        public List<BookModel> Books { get; set; }
        public bool Switcher { get; set; }
    }
}
