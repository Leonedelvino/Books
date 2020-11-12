using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using Books.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Net.Mime;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.StaticFiles;

namespace Books.Controllers
{
    public class BooksController : Controller
    {
        private readonly BooksContext db;
        private readonly BookssManager manager;

        public BooksController(BooksContext context, BookssManager manager)
        {
            this.db = context;
            this.manager = manager;
        }

        public IActionResult Index()
        {
            var books = this.db.Books.ToList();
            return this.View(books);
        }

        public IActionResult Details(int Id)
        {
            var book = this.db.Books.Find(Id);
            return this.View(book);
        }

        public IActionResult GetBook(int Id)
        {
            var foundBook = this.db.Books.Find(Id);
            var bookDirectory = "wwwroot/library/";
            var bookPath = manager.GetBooksPath(bookDirectory, foundBook);
            var extension = Path.GetExtension(bookPath);
            var contentType = manager.GetBooksType(extension);
            return PhysicalFile(bookPath, contentType);
        }
    }
}
