using MovieBase.Models;
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
            var model = new AppearanceListItem[0];   
            return View(model);
        }

        // GET: Appearance/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Appearance/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Appearance/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AppearanceCreate model)
        {
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }

        // GET: Appearance/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Appearance/Edit/5
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

        // GET: Appearance/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Appearance/Delete/5
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
