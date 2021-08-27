using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CariController : Controller
    {

        // GET: Cari
        Context c = new Context();
        
        public ActionResult Index()
        {
            var degerler = c.Carilers.Where(x=>x.Durum==true).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult CariEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CariEkle(Cariler ca)
        {
            c.Carilers.Add(ca);
            ca.Durum = true;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariSil(int id)
        {
            var sil = c.Carilers.Find(id);
            sil.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariGetir(int id)
        {
            var carilerim = c.Carilers.Find(id);
            return View("CariGetir",carilerim);
        }
        public ActionResult CariGuncelle(Cariler cg)
        {
            if (!ModelState.IsValid)
            {
                return View("CariGetir");
            }
            var cari = c.Carilers.Find(cg.CariID);
            cari.CariAd = cg.CariAd;
            cari.CariSoyad = cg.CariSoyad;
            cari.CariSehir = cg.CariSehir;
            cari.CariMail = cg.CariMail;
            cari.Durum = cg.Durum;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriSatisDetay(int id)
        {
            var musteri = c.SatisHarekets.Where(x => x.Cariid == id).ToList();
            var prsnlsts = c.Carilers.Where(x => x.CariID == id).Select(y => y.CariAd + " " + y.CariSoyad).FirstOrDefault();
            ViewBag.prs = prsnlsts;
            return View(musteri);
        }
    }
}