using Books.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Controllers
{
    public class ArticleController : Controller
    {
        private readonly BooksContext db;
        private readonly IWebHostEnvironment appEnvironment;

        public ArticleController(BooksContext db, IWebHostEnvironment appEnvironment)
        {
            this.db = db;
            this.appEnvironment = appEnvironment;
        }

        public IActionResult Index()
        {
            var switcher = false;
            var articles = this.db.Articles.ToList();
            var model = new ArticlesViewModel()
            {
                Switcher = switcher,
                Articles = articles,
            };

            return this.View(model);
        }

        [HttpPost]
        public IActionResult Index(ArticlesViewModel model)
        {
            if (model.Switcher == false)
            {
                var articles = db.Articles.ToList();
                model.Switcher = true;
                model.Articles = articles;
                return View(model);
            }
            else
            {
                var articles = db.Articles.ToList();
                model.Switcher = false;
                model.Articles = articles;
                return View(model);
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ArticleModel model, IFormFile file)
        {
            if (!ModelState.IsValid)
            {
            }

            var path = "/ArticleCovers/" + file.FileName;
            using (var fileStream = new FileStream(appEnvironment.WebRootPath + path, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            model.CoverPath = path;
            db.Articles.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
