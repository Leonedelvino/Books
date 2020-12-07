using Books.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;

namespace Books.Controllers
{
    public class ArticleController : Controller
    {
        private readonly BooksContext db;

        public ArticleController(BooksContext db)
        {
            this.db = db;
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
            if(model.Switcher == false)
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
        public ActionResult Create(IFormCollection collection)
        {
            if(!ModelState.IsValid)
            {
            }

            byte[] imageData = null;

            if(collection.Files != null && collection.Files.Count > 0)
            {
                var fileName = Path.GetFileName(collection.Files.FirstOrDefault().FileName);
                var fileExtension = Path.GetExtension(fileName);
                var newFileName = String.Concat(Convert.ToString(Guid.NewGuid()), fileExtension);
            }

            return View();
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
