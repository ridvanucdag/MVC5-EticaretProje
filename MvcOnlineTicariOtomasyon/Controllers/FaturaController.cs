using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class FaturaController : Controller
    {
        // GET: Fatura
        Context c = new Context();
        public ActionResult Index()
        {
            var deger = c.Faturalars.ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult FaturaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FaturaEkle(Faturalar f)
        {
            c.Faturalars.Add(f);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaGetir(int id)
        {
            var getir = c.Faturalars.Find(id);
            return View("FaturaGetir",getir);
        }
        public ActionResult FaturaGuncelle(Faturalar f)
        {
            var gncl = c.Faturalars.Find(f.FaturaID);
            gncl.FaturaSeriNo = f.FaturaSeriNo;
            gncl.FaturaSiraNo = f.FaturaSiraNo;
            gncl.VergiDairesi = f.VergiDairesi;
            gncl.TeslimAlan = f.TeslimAlan;
            gncl.TeslimEden = f.TeslimEden;
            gncl.Saat = f.Saat;
            gncl.Tarih = f.Tarih;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaDetay(int id)
        {
            var deger = c.FaturaKalems.Where(x => x.Faturaid == id).ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult YeniKalem()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKalem(FaturaKalem fa)
        {
            c.FaturaKalems.Add(fa);
            c.SaveChanges();
            return RedirectToAction("FaturaDetay");
        }
        public ActionResult DinamikFatura()
        {
            DinamikFaturam df = new DinamikFaturam();
            df.deger1 = c.Faturalars.ToList();
            df.deger2 = c.FaturaKalems.ToList();
            return View(df);
        }

        public ActionResult Dinamik()
        {
            DinamikFaturam df = new DinamikFaturam();
            df.deger1 = c.Faturalars.ToList();
            df.deger2 = c.FaturaKalems.ToList();
            return View(df);
        }

        public ActionResult DinamikFaturam()
        {
            DinamikFaturam df = new DinamikFaturam();
            df.deger1 = c.Faturalars.ToList();
            df.deger2 = c.FaturaKalems.ToList();
            return View(df);
        }

        public ActionResult FaturaKaydet(string FaturaSeriNo, string FaturaSiraNo, DateTime Tarih, string VergiDairesi, string Saat, 
            string TeslimEden, string TeslimAlan,string Toplam, FaturaKalem[] kalemler)
        {
            Faturalar f = new Faturalar();
            f.FaturaSeriNo = FaturaSeriNo;
            f.FaturaSiraNo = FaturaSiraNo;
            f.Tarih = Tarih;
            f.VergiDairesi = VergiDairesi;
            f.Saat = Saat;
            f.TeslimEden = TeslimEden;
            f.TeslimAlan = TeslimAlan;
            f.Toplam = decimal.Parse(Toplam);
            c.Faturalars.Add(f);
            foreach(var x in kalemler)
            {
                FaturaKalem fk = new FaturaKalem();
                fk.Aciklama = x.Aciklama;
                fk.BirimFiyat = x.BirimFiyat;
                fk.Faturaid = x.FaturaKalemID;
                fk.Tutar = x.Tutar;
                c.FaturaKalems.Add(fk);
            }
            c.SaveChanges();
            return Json("İşlem başarılı bir şekilde kaydedildi.", JsonRequestBehavior.AllowGet);
        }
    }
}