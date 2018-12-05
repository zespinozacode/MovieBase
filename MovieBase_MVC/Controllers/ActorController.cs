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
    public class ActorController : Controller
    {
        // GET: Actor
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ActorService(userId);
            var model = service.GetActors();
            return View(model);
        }

        // GET: Actor/Details/5
        public ActionResult Details(int id)
        {
            var svc = CreateActorService();
            var model = svc.GetActorById(id);

            return View(model);
        }

        // GET: Actor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Actor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ActorCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateActorService();

            service.CreateActor(model);

            return RedirectToAction("Index");
        }

        private ActorService CreateActorService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ActorService(userId);
            return service;
        }

        // GET: Actor/Edit/5
        public ActionResult Edit(int id)
        {
            var service = CreateActorService();
            var detail = service.GetActorById(id);
            var model =
                new ActorEdit
                {
                    ActorId = detail.ActorId,
                    Name = detail.Name
                };
            return View(model);
        }

        // POST: Actor/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ActorEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ActorId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateActorService();

            if (service.UpdateActor(model))
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Actor/Delete/5
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateActorService();
            var model = svc.GetActorById(id);

            return View(model);
        }

        // POST: Actor/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateActorService();

            service.DeleteActor(id);

            return RedirectToAction("Index");
        }
    }
}
