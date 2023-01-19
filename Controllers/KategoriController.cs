using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MvcStok.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori

        MvcDbStokEntities db=new MvcDbStokEntities();

        public ActionResult Index_Kategori(int sayfa=1)
        {
            //var degerler = db.TBLKATEGORILER.ToList();
            var degerler = db.TBLKATEGORILER.ToList().ToPagedList(sayfa, 4);
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniKategori(TBLKATEGORILER P1)
        {
            if (!ModelState.IsValid)  /*= modelin durumunda doğrulama kodu yapılmadıysa anlamı taşır*/
            {
                return View("YeniKategori");
            }
            db.TBLKATEGORILER.Add(P1);
            db.SaveChanges();
            return View();
            
        }
        public ActionResult SIL(int id)
        {
            var kategri = db.TBLKATEGORILER.Find(id);
            db.TBLKATEGORILER.Remove(kategri);
            db.SaveChanges();
            return RedirectToAction("Index_Kategori");
        }
        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.TBLKATEGORILER.Find(id);
            return View("KategoriGetir",ktgr);
        }
        public ActionResult GUNCELLE(TBLKATEGORILER p1)
        {
            var ktg = db.TBLKATEGORILER.Find(p1.KATEGORIID);
            ktg.KATEGORIAD = p1.KATEGORIAD;
            db.SaveChanges();
            return RedirectToAction("Index_Kategori");
        }
    }
}