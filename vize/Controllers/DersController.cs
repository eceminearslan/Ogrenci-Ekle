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
    public class DersController : Controller
    {
        OrnekVizeContext db = new OrnekVizeContext();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ara(string dersAdi)
        {
            var dersler = db.Ders.Where(d => d.DersAd.Contains(dersAdi)).ToList();
            return View("Ara", dersler);
        }       
    }
}