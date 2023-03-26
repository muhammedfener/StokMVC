using MVCStok.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCStok.Controllers
{
    public class GirisYapController : Controller
    {
        DB_MVCStokEntities db = new DB_MVCStokEntities();

        // GET: GirisYap
        public ActionResult Giris()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Giris(TBLAdmin t)
        {
            var bilgiler = db.TBLAdmin.FirstOrDefault(x => x.kullanici == t.kullanici && x.sifre == t.sifre);
            if(bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.kullanici, false);
                return RedirectToAction("Index", "Musteri");
            }

            return View();
        }
    }
}