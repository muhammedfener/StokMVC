using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStok.Models.Entity;

namespace MVCStok.Controllers
{
    public class AdminController : Controller
    {
        DB_MVCStokEntities db = new DB_MVCStokEntities();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet] 
        public ActionResult YeniAdmin() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniAdmin(TBLAdmin admin)
        {
            db.TBLAdmin.Add(admin);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}