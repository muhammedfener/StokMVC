using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStok.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MVCStok.Controllers
{
    public class MusteriController : Controller
    {
        DB_MVCStokEntities db = new DB_MVCStokEntities();
        // GET: Musteri
        public ActionResult Index(int sayfa = 1)
        {
            var musteriliste = db.TBLMusteri.Where(x => x.durum == true).ToList().ToPagedList(sayfa, 3);
            return View(musteriliste);
        }

        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniMusteri(TBLMusteri m)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            m.durum = true;
            db.TBLMusteri.Add(m);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriSil(int id)
        {
            var musteri = db.TBLMusteri.Find(id);
            musteri.durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriGetir(int id)
        {
            var musteri = db.TBLMusteri.Find(id);
            return View(musteri);
        }

        [HttpPost]
        public ActionResult MusteriGuncelle(TBLMusteri m)
        {
            var musteri = db.TBLMusteri.Find(m.id);
            musteri.ad = m.ad;
            musteri.soyad = m.soyad;
            musteri.sehir = m.sehir;
            musteri.bakiye = m.bakiye;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}