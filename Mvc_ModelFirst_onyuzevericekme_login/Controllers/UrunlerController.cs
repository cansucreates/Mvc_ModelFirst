using Mvc_ModelFirst_onyuzevericekme_login.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_ModelFirst_onyuzevericekme_login.Controllers
{
    public class UrunlerController : Controller
    {
        MVC_ModelFirstEntities db = new MVC_ModelFirstEntities();
        // GET: Urunler
        public ActionResult Index() // Urunlerin listelendiği sayfa
        {
            return View(db.Urunlers.ToList());
        }

        // Urun Kaydetme
        public ActionResult Kaydet()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Kaydet(Urunler urun)
        {
            db.Urunlers.Add(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }           
    }
}