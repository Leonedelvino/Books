using Microsoft.EntityFrameworkCore;

namespace Books.Models
{
    public class BooksContext : DbContext
    {
        public DbSet<BookModel> Books { get; set; }
        public DbSet<ArticleModel> Articles { get; set; }

        public BooksContext(DbContextOptions<BooksContext> options) : base(options)
        {
        }
    }
}
