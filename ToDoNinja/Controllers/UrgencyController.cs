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
    public class UrgencyController : Controller
    {
        private ToDoNinjaEntities db = new ToDoNinjaEntities();

        //
        // GET: /Urgency/

        public ActionResult Index()
        {
            return View(db.Urgencies.ToList());
        }

        //
        // GET: /Urgency/Details/5

        public ActionResult Details(int id = 0)
        {
            Urgency urgency = db.Urgencies.Find(id);
            if (urgency == null)
            {
                return HttpNotFound();
            }
            return View(urgency);
        }

        //
        // GET: /Urgency/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Urgency/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Urgency urgency)
        {
            if (ModelState.IsValid)
            {
                db.Urgencies.Add(urgency);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(urgency);
        }

        //
        // GET: /Urgency/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Urgency urgency = db.Urgencies.Find(id);
            if (urgency == null)
            {
                return HttpNotFound();
            }
            return View(urgency);
        }

        //
        // POST: /Urgency/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Urgency urgency)
        {
            if (ModelState.IsValid)
            {
                db.Entry(urgency).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(urgency);
        }

        //
        // GET: /Urgency/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Urgency urgency = db.Urgencies.Find(id);
            if (urgency == null)
            {
                return HttpNotFound();
            }
            return View(urgency);
        }

        //
        // POST: /Urgency/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Urgency urgency = db.Urgencies.Find(id);
            db.Urgencies.Remove(urgency);
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