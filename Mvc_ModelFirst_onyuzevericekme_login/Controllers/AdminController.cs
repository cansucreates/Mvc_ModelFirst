using Mvc_ModelFirst_onyuzevericekme_login.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_ModelFirst_onyuzevericekme_login.Controllers
{
    public class AdminController : Controller
    {
        MVC_ModelFirstEntities db = new MVC_ModelFirstEntities();

        // GET: Admin
        // Admin Giriş için login sayfası

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Kullanicilar kullanici) // Kullanıcı giriş kontrolü
        {
            var login = from x in db.Kullanicilars
                        where x.KullaniciAdi == kullanici.KullaniciAdi && x.Sifre == kullanici.Sifre
                        select x;
            if (login.Count() > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }


        // Admin ana sayfa
        public ActionResult Index() // Admin sayfası
        {
            return View();
        }


        // Kullanıcı Listeleme
        public ActionResult Kullanicilar()
        {

            return View(db.Kullanicilars.ToList());
        }

        // Kullanıcı Kayıt
        public ActionResult Kaydet() // Boş sayfa
        {
            return View();
        }

        [HttpPost]
        public ActionResult Kaydet(Kullanicilar kullanici)
        {
            db.Kullanicilars.Add(kullanici);
            db.SaveChanges();
            return RedirectToAction("Kullanicilar");
        }

        // Kullanıcı güncelleme
        public ActionResult Guncelle(int id)
        {
            var guncelle = db.Kullanicilars.Where(x => x.id == id).FirstOrDefault();
            return View(guncelle);
        }

        [HttpPost]
        public ActionResult Guncelle(int id, Kullanicilar kullanici)
        {
            
            db.Kullanicilars.AddOrUpdate(kullanici);
            db.SaveChanges();
            return RedirectToAction("Kullanicilar");
        }

        // Kullanıcı Silme
        public ActionResult Sil(int id)
        {
            var sil = db.Kullanicilars.Where(x => x.id == id).FirstOrDefault();
            db.Kullanicilars.Remove(sil);
            db.SaveChanges();
            return RedirectToAction("Kullanicilar");
        }



    }
}