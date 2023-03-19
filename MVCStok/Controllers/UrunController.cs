using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using MVCStok.Models.Entity;

namespace MVCStok.Controllers
{
    public class UrunController : Controller
    {
        DB_MVCStokEntities db = new DB_MVCStokEntities();
        // GET: Urun
        public ActionResult Index()
        {
            var urunler = db.TBLUrunler.ToList();
            return View(urunler);
        }

        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> kategori = (from x in db.TBLKategori.ToList() 
                                             select new SelectListItem 
                                             { 
                                                 Value = x.id.ToString(), 
                                                 Text = x.ad 
                                             }).ToList();

            ViewBag.drop = kategori;
            return View();
        }

        [HttpPost]
        public ActionResult YeniUrun(TBLUrunler p)
        {
            var kategori = db.TBLKategori.Where(x => x.id == p.kategori).FirstOrDefault();
            p.TBLKategori = kategori;
            db.TBLUrunler.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            var urun = db.TBLUrunler.Find(id);
            return View(urun);
        }
    }
}