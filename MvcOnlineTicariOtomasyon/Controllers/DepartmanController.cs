using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class DepartmanController : Controller
    {
        // GET: Departman
        Context c = new Context();
        
        public ActionResult Index()
        {
            var degerler = c.Departmens.Where(x => x.Durum == true).ToList();
            return View(degerler);
        }
        [Authorize(Roles = "A")]
        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DepartmanEkle(Departman d)
        {
            c.Departmens.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanSil(int id)
        {
            var sil = c.Departmens.Find(id);
            sil.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult DepartmanGetir(int id)
        {
            var departman = c.Departmens.Find(id);
            return View("DepartmanGetir",departman);
        }
        public ActionResult DepartmanGuncelle(Departman d)
        {
            var dprtmn = c.Departmens.Find(d.DepartmanID);
            dprtmn.DepartmanAd = d.DepartmanAd;
            dprtmn.Durum = d.Durum;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanDetay(int id)
        {
            var detay = c.Personels.Where(x=>x.departmanid==id).ToList();
            var dprtm = c.Departmens.Where(x => x.DepartmanID == id).Select(y => y.DepartmanAd).FirstOrDefault();
            ViewBag.dpr = dprtm;
            return View(detay);
        }
        public ActionResult DepartmanPersonelSatis(int id)
        {
            var detay = c.SatisHarekets.Where(x => x.Personelid == id).ToList();
            var prsnl = c.Personels.Where(x => x.PersonelID == id).Select(y => y.PersonelAd + " "+ y.PersonelSoyad).FirstOrDefault();
            ViewBag.prs = prsnl;
            return View(detay);
        }

    }
}