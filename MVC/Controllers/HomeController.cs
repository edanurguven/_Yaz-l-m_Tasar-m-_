using DAL;
using DAL.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMalzeme _malzeme;
        public HomeController(IMalzeme malzeme)
        {
            _malzeme = malzeme;
        }

        public IActionResult Index()
        {
            //tarifleri gösteren ana safya
            var result = _malzeme.GetAll();
            return View(result);
        }
        [HttpGet]
        public IActionResult AramaSonuclari(string malzeme)
        {
            //Arama sonuçları gösterilecek
            if (malzeme != null)
            {
                char[] delimiterChars = { ',', '.', ':' };
                string[] array = malzeme.Split(delimiterChars,StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
                var dbList = _malzeme.GetChoose(array);
                return View(dbList);
            }
            else
            {
                //liste boş dönebilir
                return View();
            }
        }   

        public IActionResult TarifiGoster(int id)
        {
            //Tıklanılan yemeğin bilgileri dönmeli

            ViewBag.Oneriler = _malzeme.GetAll().Take(3).ToList(); //oneriler icin
            var malzeme = _malzeme.GetById(id);
            return View(malzeme);
        }

        public IActionResult Hakkimizda()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
