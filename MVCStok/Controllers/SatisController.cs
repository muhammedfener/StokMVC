using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStok.Models.Entity;

namespace MVCStok.Controllers
{
    public class SatisController : Controller
    {
        DB_MVCStokEntities db = new DB_MVCStokEntities();
        // GET: Satis
        public ActionResult Index()
        {
            var satislar = db.TBLSatislar.ToList();
            return View(satislar);
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            //Ürünler
            List<SelectListItem> urun = (from x in db.TBLUrunler.ToList()
                                         select new SelectListItem
                                         {
                                             Value = x.id.ToString(),
                                             Text = x.ad
                                         }).ToList();

            ViewBag.dropdown1 = urun;

            //Personeller
            List<SelectListItem> personel = (from x in db.TBLPersonel.ToList()
                                             select new SelectListItem
                                             {
                                                 Value = x.id.ToString(),
                                                 Text = x.ad + " " + x.soyad
                                             }).ToList();

            ViewBag.dropdown2 = personel;


            //Müşteriler
            List<SelectListItem> musteriler = (from x in db.TBLMusteri.ToList()
                                               select new SelectListItem
                                               {
                                                   Value = x.id.ToString(),
                                                   Text = x.ad + " " + x.soyad
                                               }).ToList();

            ViewBag.dropdown3 = musteriler;

            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(TBLSatislar satis)
        {
            var urun = db.TBLUrunler.Where(x => x.id == satis.TBLUrunler.id).FirstOrDefault();
            var musteri = db.TBLMusteri.Where(x => x.id == satis.TBLMusteri.id).FirstOrDefault();
            var personel = db.TBLPersonel.Where(x => x.id == satis.TBLPersonel.id).FirstOrDefault();

            satis.TBLUrunler = urun;
            satis.TBLMusteri = musteri;
            satis.TBLPersonel = personel;
            satis.tarih = DateTime.Now;
            db.TBLSatislar.Add(satis);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}