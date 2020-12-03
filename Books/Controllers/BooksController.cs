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
        private readonly BooksManager manager;

        public BooksController(BooksContext context, BooksManager manager)
        {
            this.db = context;
            this.manager = manager;
        }

        public IActionResult Index()
        {
            var books = this.db.Books.ToList();
            var switcher = false;
            var booksList = new BookViewModel()
            {
                Books = books,
                Switcher = switcher,
            };
            return this.View(booksList);
        }

        [HttpPost]
        public IActionResult Index(BookViewModel model)
        {
            if (model.Switcher == false)
            {
                var books = this.db.Books.ToList();
                model.Switcher = true;
                model.Books = books;
                return this.View(model);
            }
            else
            {
                var books = this.db.Books.ToList();
                model.Switcher = false;
                model.Books = books;
                return this.View(model);
            }
        }

        public IActionResult Details(int Id)
        {
            var books = this.db.Books.Find(Id);
            return this.View(books);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = this.db.Books.ToList();
            return this.View(model);
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
