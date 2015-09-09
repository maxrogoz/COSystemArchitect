using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LBDataModel;
using LBFrontend.Models;

namespace LBFrontend.Controllers
{
    public class ScheduleController : Controller
    {
        private LBFrontendContext db = new LBFrontendContext();

        //
        // GET: /Schedule/

        public ActionResult Index(int id = 0)
        {
            BackupTask task = db.BackupTasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            //var schedules = db.Schedules.Include(s => s.BackupTask);
            ViewData["BackupTask"] = task;
            return View(task.Schedules.ToList());
        }

        //
        // GET: /Schedule/Create

        public ActionResult Create(int id = 0)
        {
            BackupTask task = db.BackupTasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            ViewBag.BackupTaskId = task.BackupTaskId;//new SelectList(db.BackupTasks, "BackupTaskId", "SourceFolder");
            return View();
        }

        //
        // POST: /Schedule/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                db.Schedules.Add(schedule);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = schedule.BackupTaskId });
            }

            ViewBag.BackupTaskId = schedule.BackupTaskId;
            return View(schedule);
        }

        //
        // GET: /Schedule/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Schedule schedule = db.Schedules.Find(id);
            if (schedule == null)
            {
                return HttpNotFound();
            }
            return View(schedule);
        }

        //
        // POST: /Schedule/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(schedule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = schedule.BackupTaskId });
            }
            return View(schedule);
        }

        //
        // GET: /Schedule/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Schedule schedule = db.Schedules.Find(id);
            if (schedule == null)
            {
                return HttpNotFound();
            }
            return View(schedule);
        }

        //
        // POST: /Schedule/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Schedule schedule = db.Schedules.Find(id);
            db.Schedules.Remove(schedule);
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