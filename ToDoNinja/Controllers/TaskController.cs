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
    public class TaskController : Controller
    {
        private ToDoNinjaEntities db = new ToDoNinjaEntities();

        //
        // GET: /Task/

        public ActionResult Index()
        {
            var tasks = db.Tasks.Include(t => t.Priority).Include(t => t.Project).Include(t => t.Resource).Include(t => t.Status).Include(t => t.Urgency);
            return View(tasks.ToList());
        }

        //
        // GET: /Task/Details/5

        public ActionResult Details(long id = 0)
        {
            Task task = db.Tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        //
        // GET: /Task/Create

        public ActionResult Create()
        {
            ViewBag.PriorityID = new SelectList(db.Priorities, "ID", "Name");
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "Name");
            ViewBag.ResourceID = new SelectList(db.Resources, "ID", "Name");
            ViewBag.StatusID = new SelectList(db.Status, "ID", "Name");
            ViewBag.UrgencyID = new SelectList(db.Urgencies, "ID", "Name");
            return View();
        }

        //
        // POST: /Task/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Task task)
        {
            if (ModelState.IsValid)
            {
                db.Tasks.Add(task);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PriorityID = new SelectList(db.Priorities, "ID", "Name", task.PriorityID);
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "Name", task.ProjectID);
            ViewBag.ResourceID = new SelectList(db.Resources, "ID", "Name", task.ResourceID);
            ViewBag.StatusID = new SelectList(db.Status, "ID", "Name", task.StatusID);
            ViewBag.UrgencyID = new SelectList(db.Urgencies, "ID", "Name", task.UrgencyID);
            return View(task);
        }

        //
        // GET: /Task/Edit/5

        public ActionResult Edit(long id = 0)
        {
            Task task = db.Tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            ViewBag.PriorityID = new SelectList(db.Priorities, "ID", "Name", task.PriorityID);
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "Name", task.ProjectID);
            ViewBag.ResourceID = new SelectList(db.Resources, "ID", "Name", task.ResourceID);
            ViewBag.StatusID = new SelectList(db.Status, "ID", "Name", task.StatusID);
            ViewBag.UrgencyID = new SelectList(db.Urgencies, "ID", "Name", task.UrgencyID);
            return View(task);
        }

        //
        // POST: /Task/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Task task)
        {
            if (ModelState.IsValid)
            {
                db.Entry(task).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PriorityID = new SelectList(db.Priorities, "ID", "Name", task.PriorityID);
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "Name", task.ProjectID);
            ViewBag.ResourceID = new SelectList(db.Resources, "ID", "Name", task.ResourceID);
            ViewBag.StatusID = new SelectList(db.Status, "ID", "Name", task.StatusID);
            ViewBag.UrgencyID = new SelectList(db.Urgencies, "ID", "Name", task.UrgencyID);
            return View(task);
        }

        //
        // GET: /Task/Delete/5

        public ActionResult Delete(long id = 0)
        {
            Task task = db.Tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        //
        // POST: /Task/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Task task = db.Tasks.Find(id);
            db.Tasks.Remove(task);
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