using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiniImdb.Controllers;
using MiniImdb.Models;

namespace MiniImdb.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        private MoviesDBEntities _db = new MoviesDBEntities();

        public ActionResult Index()

        {

            return View(_db.Movies1.ToList());

        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")] Movie movieToCreate)
        {
            try
            {
                if (!ModelState.IsValid)

                    return View();

                _db.Movies1.Add(movieToCreate);

                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var movieToEdit = (from m in _db.Movies1

                                   where m.Id == id

                                   select m).First();

                return View(movieToEdit);
            }
            catch
            {
                return View();
            }
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(Movie movieToEdit)
        {
            try
            {
                var originalMovie = (from m in _db.Movies1

                                     where m.Id == movieToEdit.Id

                                     select m).First();

                if (!ModelState.IsValid)

                    return View(originalMovie);

               
                _db.Movies1.Attach(movieToEdit);
                _db.Entry(movieToEdit).State = System.Data.Entity.EntityState.Modified;

                _db.SaveChanges();


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(Movie movieToDelete)
        {
            _db.Movies1.Remove(movieToDelete);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
