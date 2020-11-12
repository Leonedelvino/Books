using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Models
{
    public class BooksContext : DbContext
    {
        public DbSet<BookModel> Books { get; set; }

        public BooksContext(DbContextOptions<BooksContext> options) : base(options)
        {
        }
    }
}
