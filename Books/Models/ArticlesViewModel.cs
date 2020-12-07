using System.Collections.Generic;

namespace Books.Models
{
    public class ArticlesViewModel
    {
        public List<ArticleModel> Articles { get; set; }
        public List<BookModel> Books { get; set; }
        public bool Switcher { get; set; }
    }
}
