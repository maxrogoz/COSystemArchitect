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
    public class LogController : Controller
    {
        private LBDataModelContext db = new LBDataModelContext();

        //
        // GET: /Log/

        public ActionResult Index()
        {
            return View(db.Logs.ToList());
        }

        //
        // GET: /Log/Details/5

        public ActionResult Details(int id = 0)
        {
            Log log = db.Logs.Find(id);
            if (log == null)
            {
                return HttpNotFound();
            }
            return View(log);
        }


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}