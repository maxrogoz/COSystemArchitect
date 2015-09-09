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
    public class BackupTaskController : Controller
    {
        private LBFrontendContext db = new LBFrontendContext();

        //
        // GET: /BackupTask/

        public ActionResult Index(int machineId = 0)
        {
            Machine machine = db.Machines.Find(machineId);
            if (machine == null)
            {
                return HttpNotFound();
            }
            ViewData["Machine"] = machine;
            //var backuptasks = machine.BackupTasks.First(). db.BackupTasks.Where(bt => bt.MachineId == machineId).Include(b => b.Machine)
            //    .Include(b => b.SourceUser).Include(b => b.DestUser);
            return View(machine.BackupTasks.ToList());
        }

        //
        // GET: /BackupTask/Details/5

        public ActionResult Details(int id = 0)
        {
            BackupTask backuptask = db.BackupTasks.Find(id);
            if (backuptask == null)
            {
                return HttpNotFound();
            }
            return View(backuptask);
        }

        //
        // GET: /BackupTask/Create

        public ActionResult Create(int machineId = 0)
        {
            ViewBag.MachineId = db.Machines.Find(machineId);
            if (ViewBag.MachineId == null)
            {
                return HttpNotFound();
            }
            return View();
        }

        //
        // POST: /BackupTask/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BackupTask backuptask)
        {
            if (ModelState.IsValid)
            {
                db.BackupTasks.Add(backuptask);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MachineId = new SelectList(db.Machines, "MachineId", "IpAdress", backuptask.MachineId);
            return View(backuptask);
        }

        //
        // GET: /BackupTask/Edit/5

        public ActionResult Edit(int id = 0)
        {
            BackupTask backuptask = db.BackupTasks.Find(id);
            if (backuptask == null)
            {
                return HttpNotFound();
            }
            ViewBag.MachineId = new SelectList(db.Machines, "MachineId", "IpAdress", backuptask.MachineId);
            return View(backuptask);
        }

        //
        // POST: /BackupTask/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BackupTask backuptask)
        {
            if (ModelState.IsValid)
            {
                db.Entry(backuptask).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MachineId = new SelectList(db.Machines, "MachineId", "IpAdress", backuptask.MachineId);
            return View(backuptask);
        }

        //
        // GET: /BackupTask/Delete/5

        public ActionResult Delete(int id = 0)
        {
            BackupTask backuptask = db.BackupTasks.Find(id);
            if (backuptask == null)
            {
                return HttpNotFound();
            }
            return View(backuptask);
        }

        //
        // POST: /BackupTask/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BackupTask backuptask = db.BackupTasks.Find(id);
            db.BackupTasks.Remove(backuptask);
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