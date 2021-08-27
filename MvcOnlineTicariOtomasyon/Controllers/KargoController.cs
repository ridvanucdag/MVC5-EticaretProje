using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class KargoController : Controller
    {
        // GET: Kargo
        Context c = new Context();
        public ActionResult Index(string kod)
        {
            var takip = from x in c.KargoDetays select x;
            if (!string.IsNullOrEmpty(kod))
            {
                takip = takip.Where(y => y.TakipKodu.Contains(kod));
            }
            return View(takip.ToList());
        }
        [HttpGet]
        public ActionResult YeniKargo()
        {
            Random rdn = new Random();
            string[] karakterler = {"A", "B", "C", "D","E","F","G"};

            int k1 ,k2 ,k3;
            k1 = rdn.Next(0, 7);
            k2 = rdn.Next(0, 7);
            k3 = rdn.Next(0, 7);
            int s1, s2, s3;
            s1 = rdn.Next(100, 999);
            s2 = rdn.Next(10, 99);
            s3 = rdn.Next(10, 99);
            string kod = s1 + karakterler[k1] + s2 + karakterler[k2] + s3 + karakterler[k3];
            ViewBag.takipkod = kod;
            return View();
        }
        [HttpPost]
        public ActionResult YeniKargo(KargoDetay k)
        {
            c.KargoDetays.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KargoTakip(string id)
        {
            var detay = c.KargoTakips.Where(x => x.TakipKodu == id).ToList();
            return View(detay);
        }
    }
}