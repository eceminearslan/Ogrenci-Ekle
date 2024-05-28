using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using vize.Models;

namespace vize.Controllers
{
    public class BolumController : Controller
    {
        OrnekVizeContext db = new OrnekVizeContext();

        [HttpGet]
        public IActionResult BolumEkle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult BolumEkle(Bolum bolum)
        {
            db.Bolums.Add(bolum);
            db.SaveChanges();
            return RedirectToAction("Index","Home");
        }
    }
}