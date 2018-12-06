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
    public class AppearanceController : Controller
    {
        [Authorize]
        // GET: Appearance
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AppearanceService(userId);
            var model = service.GetAppearances();

            return View(model);
        }

        // GET: Appearance/Details/5
        public ActionResult Details(int id)
        {
            var svc = CreateAppearanceService();
            var model = svc.GetAppearanceById(id);

            return View();
        }

        // GET: Appearance/Create
        public ActionResult Create()
        {
            var svc = CreateAppearanceService();
            var userId = Guid.Parse(User.Identity.GetUserId());
            var actorList = new SelectList(svc.Actors(), "ActorId", "Name");
            ViewBag.ActorId = actorList;

            var movieList = new SelectList(svc.Movies(), "MovieId", "Title");
            ViewBag.MovieId = movieList;

            return View();
        }

        // POST: Appearance/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AppearanceCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            AppearanceService service = CreateAppearanceService();

            service.CreateAppearance(model);

            ViewBag.ActorId = new SelectList(service.Actors(), "ActorId", "Name", model.ActorId);
            ViewBag.MovieId = new SelectList(service.Movies(), "MovieId", "Title", model.MovieId);


            return RedirectToAction("Index");
        }

        private AppearanceService CreateAppearanceService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AppearanceService(userId);
            return service;
        }

        // GET: Appearance/Edit/5
        public ActionResult Edit(int id)
        {
            var service = CreateAppearanceService();
            var detail = service.GetAppearanceById(id);
            var model =
                new AppearanceEdit
                {
                    AppearanceId = detail.AppearanceId,
                    ActorId = detail.ActorId,
                    MovieId = detail.MovieId
                };

            var actorList = new SelectList(service.Actors(), "ActorId", "Name", detail.ActorId);
            ViewBag.ActorId = actorList;
            var movieList = new SelectList(service.Movies(), "MovieId", "Title", detail.MovieId);
            ViewBag.MovieId = movieList;

            return View(model);
        }

        // POST: Appearance/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AppearanceEdit model)
        {
            if(!ModelState.IsValid) return View(model);

            if(model.AppearanceId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateAppearanceService();
            if (service.UpdateAppearance(model))
            {
                return RedirectToAction("Index");
            }

            var actorList = new SelectList(service.Actors(), "ActorId", "Name", model.Appearance.AppearanceId);
            ViewBag.ActorId = actorList;
            var movieList = new SelectList(service.Movies(), "MovieId", "Title", model.Appearance.AppearanceId);
            ViewBag.MovieId = movieList;

            return View(model);
        }

        // GET: Appearance/Delete/5
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateAppearanceService();
            var model = svc.GetAppearanceById(id);

            return View(model);
        }

        // POST: Appearance/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateAppearanceService();

            service.DeleteAppearance(id);

            return RedirectToAction("Index");
            
        }
    }
}
