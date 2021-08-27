using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        Context c = new Context();
        public ActionResult Index(string arama)
        {
            var urunler = from x in c.Uruns select x;
            if (!string.IsNullOrEmpty(arama))
            {
                urunler = urunler.Where(y => y.UrunAd.Contains(arama));
            }
            return View(urunler.ToList());
        }
        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            return View();
        }
        [HttpPost]
        public ActionResult YeniUrun(Urun u)
        {
            c.Uruns.Add(u);
            u.Durum = true;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunSil(int id)
        {
            var sil = c.Uruns.Find(id);
            sil.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            var urunguncelle = c.Uruns.Find(id);
            return View("UrunGetir", urunguncelle);
        }
        public ActionResult UrunGuncelle(Urun u)
        {
            var urunum= c.Uruns.Find(u.UrunID);
            urunum.UrunAd = u.UrunAd;
            urunum.Marka = u.Marka;
            urunum.Stok = u.Stok;
            urunum.AlisFiyat = u.AlisFiyat;
            urunum.SatisFiyat = u.SatisFiyat;
            urunum.Durum = u.Durum;
            urunum.Kategoriid = u.Kategoriid;
            urunum.UrunGorsel = u.UrunGorsel;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult SatisYap(int id)
        {
            List<SelectListItem> deger2 = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd + " " + x.PersonelSoyad,
                                               Value = x.PersonelID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;

            var deger1 = c.Uruns.Find(id);
            ViewBag.dgr1 = deger1.UrunID;
            ViewBag.dgr3 = deger1.SatisFiyat;

            return View();
        }
        [HttpPost]
        public ActionResult SatisYap(SatisHareket p)
        {
            c.SatisHarekets.Add(p);
            p.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SaveChanges();
            return RedirectToAction("Index","Satis");
        }
    }
}