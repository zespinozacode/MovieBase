using Microsoft.AspNet.Identity;
using MovieBase.Models;
using MovieBase.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieBase_MVC.Controllers
{
    [Authorize]
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MovieService(userId);
            var model = service.GetMovies();

            return View(model);
        }

        // GET: Movie/Details/5
        public ActionResult Details(int id)
        {
            var svc = CreateMovieService();
            var model = svc.GetMovieById(id);
            return View(model);
        }

        // GET: Movie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movie/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MovieCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateMovieService();

            service.CreateMovie(model);

            return RedirectToAction("Index");
        }

        private MovieService CreateMovieService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MovieService(userId);
            return service;
        }

        // GET: Movie/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Movie/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Movie/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Movie/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
