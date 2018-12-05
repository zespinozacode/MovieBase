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
            var service = CreateMovieService();
            var detail = service.GetMovieById(id);
            var model =
                new MovieEdit
                {
                    MovieId = detail.MovieId,
                    Title = detail.Title,
                    ReleaseDate = detail.ReleaseDate,
                    Description = detail.Description,
                    CoverPicture = detail.CoverPicture,
                    TrailerLink = detail.TrailerLink,
                    GenreName = detail.GenreName
                };
            return View(model);
        }

        // POST: Movie/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MovieEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.MovieId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateMovieService();

            if (service.UpdateMovie(model))
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Movie/Delete/5
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateMovieService();
            var model = svc.GetMovieById(id);

            return View(model);
        }

        // POST: Movie/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateMovieService();

            service.DeleteMovie(id);

            return RedirectToAction("Index");
        }
    }
}
