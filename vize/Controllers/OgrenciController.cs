using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using vize.Models;

namespace vize.Controllers
{
    public class OgrenciController : Controller
    {
        OrnekVizeContext db = new OrnekVizeContext();

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult OgrenciEkle()
        {
            ViewBag.Bolumler = new SelectList(db.Bolums, "BolumId", "BolumAd");
            return View();
        }

        [HttpPost]
        public IActionResult OgrenciEkle(Ogrenci ogrenci)
        {
            db.Ogrencis.Add(ogrenci);
            db.SaveChanges();
            return RedirectToAction ("Index", "Home");
        }
    }
}