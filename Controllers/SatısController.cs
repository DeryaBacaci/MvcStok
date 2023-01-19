using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class SatısController : Controller
    {
        // GET: Satıs
        MvcDbStokEntities db=new MvcDbStokEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            
                return View();
            
        }
        [HttpPost]
        public ActionResult YeniSatis(TBLSATISLAR p)
        {

            db.TBLSATISLAR.Add(p);
            db.SaveChanges();
            return RedirectToAction("SatısEkranı","Satıs");

        }
        public ActionResult SatısEkranı()
        {
            var satis = db.TBLSATISLAR.ToList();
            return View(satis);
        }
    }
}