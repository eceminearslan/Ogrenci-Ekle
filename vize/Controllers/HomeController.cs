using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vize.Models;

namespace vize.Controllers;

public class HomeController : Controller
{
    private readonly OrnekVizeContext db = new OrnekVizeContext();
    
    public IActionResult Index(int? id)
    {
        var Bolum = db.Bolums.ToList();
        var Ogrenci = db.Ogrencis.Include(x => x.Bolum).ToList();

        var alldata = (Bolum: Bolum, Ogrenci: Ogrenci);

        if(!id.HasValue || id == 0)
        {
            return View(alldata);
        }
        else
        {
            var filtreOgrenci = db.Ogrencis.Include(x => x.Bolum).Where(x => x.BolumId == id).ToList();
            alldata.Ogrenci = filtreOgrenci;
            return View(alldata);
        }
    }
}
