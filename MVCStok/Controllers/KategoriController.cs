using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStok.Models.Entity;

namespace MVCStok.Controllers
{
    public class KategoriController : Controller
    {
        DB_MVCStokEntities db = new DB_MVCStokEntities();

        // GET: Kategori
        public ActionResult Index()
        {
            var kategoriler = db.TBLKategori.ToList();
            return View(kategoriler);
        }

        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniKategori(TBLKategori p)
        {
            db.TBLKategori.Add(p);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult KategoriSil(int id)
        {
            var kategori = db.TBLKategori.Find(id);
            db.TBLKategori.Remove(kategori);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int id)
        {
            var kategori = db.TBLKategori.Find(id);

            return View(kategori);
        }

        [HttpPost]
        public ActionResult KategoriGuncelle(TBLKategori p)
        {
            var kategori = db.TBLKategori.Find(p.id);
            kategori.ad = p.ad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}