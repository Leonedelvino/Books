using Books.Models;
using GeneralSemantics.Data;
using GeneralSemantics.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GeneralSemantics.Controllers
{
    public class ArticleController : Controller
    {
        private readonly BooksContext db;
        private readonly GeneralSemanticsManager manager;

        public ArticleController(BooksContext db, GeneralSemanticsManager manager)
        {
            this.db = db;
            this.manager = manager;
        }

        public ActionResult Index()
        {
            var switcher = false;
            var model = new ArticlesViewModel()
            {
                Switcher = switcher
            };

            return View(model);
        }
        
        public ActionResult GetImage(int articleId)
        {
            var article = db.Articles.FirstOrDefault(_ => _.Id == articleId);
            return File(article.Cover, article.CoversMimeType);
        }
        
        [HttpPost]
        public ActionResult Index(ArticlesViewModel model)
        {
            if(model.Switcher == false)
            {
                var articles = db.Articles.ToList();
                model.Switcher = true;
                model.Articels = articles;
                return View(model);
            }
            else
            {
                var articles = db.Articles.ToList();
                model.Switcher = false;
                model.Articels = articles;
                return View(model);
            }
        }

        public ActionResult Article(int id)
        {
            return View();
        }
        
        public ActionResult Create()
        {
            var model = db.Articles.ToList();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            if(!ModelState.IsValid)
            {
            }

            var article = collection.Keys;

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
