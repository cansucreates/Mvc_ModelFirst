using Mvc_ModelFirst_onyuzevericekme_login.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_ModelFirst_onyuzevericekme_login.Controllers
{
    public class HomeController : Controller
    {
        MVC_ModelFirstEntities db = new MVC_ModelFirstEntities();
        // GET: Home
        public ActionResult Index()
        {
            return View(db.Urunlers.ToList()) ;
        }
    }
}