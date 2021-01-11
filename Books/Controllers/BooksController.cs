using System.Linq;
using System.IO;
using System.Threading.Tasks;
using Books.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Books.Controllers
{
    public class BooksController : Controller
    {
        private readonly BooksContext db;
        private readonly BooksManager manager;
        private readonly IWebHostEnvironment appEnvironment;

        public BooksController(BooksContext context, BooksManager manager, IWebHostEnvironment appEnvironment)
        {
            this.db = context;
            this.manager = manager;
            this.appEnvironment = appEnvironment;
        }

        public IActionResult Index(bool switcher)
        {
            var books = this.db.Books.ToList();
            var booksList = new BookViewModel()
            {
                Books = books,
                Switcher = switcher,
            };
            return this.View(booksList);
        }

        public IActionResult Details(int Id)
        {
            var books = this.db.Books.Find(Id);
            return this.View(books);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new BookModel();
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(BookModel model, IFormFile file)
        {
            if (!ModelState.IsValid)
            {
                return this.View();
            }

            var path = "/img/BookCovers/" + file.FileName;
            using (var fileStream = new FileStream(appEnvironment.WebRootPath + path, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            model.CoverPath = "~/img/BookCovers/" + file.FileName;
            db.Books.Add(model);
            db.SaveChanges();
            return this.RedirectToAction("Index");
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
