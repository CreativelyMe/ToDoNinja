using System;
using System.Web;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using ToDoNinja.Models;
using System.Data.Entity;
using System.Collections.Generic;

namespace ToDoNinja.Controllers
{
    public class PriorityController : Controller
    {
        private ToDoNinjaEntities db = new ToDoNinjaEntities();

        //
        // GET: /Priority/

        public ActionResult Index()
        {
            return View(db.Priorities.ToList());
        }

        //
        // GET: /Priority/Details/5

        public ActionResult Details(int id = 0)
        {
            Priority priority = db.Priorities.Find(id);
            if (priority == null)
            {
                return HttpNotFound();
            }
            return View(priority);
        }

        //
        // GET: /Priority/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Priority/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Priority priority)
        {
            if (ModelState.IsValid)
            {
                db.Priorities.Add(priority);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(priority);
        }

        //
        // GET: /Priority/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Priority priority = db.Priorities.Find(id);
            if (priority == null)
            {
                return HttpNotFound();
            }
            return View(priority);
        }

        //
        // POST: /Priority/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Priority priority)
        {
            if (ModelState.IsValid)
            {
                db.Entry(priority).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(priority);
        }

        //
        // GET: /Priority/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Priority priority = db.Priorities.Find(id);
            if (priority == null)
            {
                return HttpNotFound();
            }
            return View(priority);
        }

        //
        // POST: /Priority/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Priority priority = db.Priorities.Find(id);
            db.Priorities.Remove(priority);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}