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
    public class MachineController : Controller
    {
        private LBFrontendContext db = new LBFrontendContext();

        //
        // GET: /Machine/

        public ActionResult Index()
        {
            return View(db.Machines.ToList());
        }

        //
        // GET: /Machine/Details/5

        public ActionResult Details(int id = 0)
        {
            Machine machine = db.Machines.Find(id);
            if (machine == null)
            {
                return HttpNotFound();
            }
            return View(machine);
        }

        //
        // GET: /Machine/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Machine/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Machine machine)
        {
            if (ModelState.IsValid)
            {
                db.Machines.Add(machine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(machine);
        }

        //
        // GET: /Machine/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Machine machine = db.Machines.Find(id);
            if (machine == null)
            {
                return HttpNotFound();
            }
            return View(machine);
        }

        //
        // POST: /Machine/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Machine machine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(machine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(machine);
        }

        //
        // GET: /Machine/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Machine machine = db.Machines.Find(id);
            if (machine == null)
            {
                return HttpNotFound();
            }
            return View(machine);
        }

        //
        // POST: /Machine/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Machine machine = db.Machines.Find(id);
            db.Machines.Remove(machine);
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