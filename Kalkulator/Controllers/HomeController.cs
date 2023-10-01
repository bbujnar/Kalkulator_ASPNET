using Kalkulator.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Kalkulator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Imie = "Bartek";
            ViewBag.godzina = DateTime.Now.Hour;
            ViewBag.powitanie = ViewBag.godzina < 17 ? "Dzien dobry "+ViewBag.Imie+"!" : "Dobry wieczór" + ViewBag.Imie + "!";

            Dane[] osoby =
            {
                new Dane {Name = "Agnieszka", Surname= "Kowalska"},
                new Dane { Name = "Karol", Surname = "Nowak" },
                new Dane { Name = "Marek", Surname = "Kochanowski" }
            };



            return View(osoby);
        }


        public IActionResult Urodziny(Urodziny urodziny)
        {
            ViewBag.powitanie = $"Witaj {urodziny.Imie} masz {DateTime.Now.Year - urodziny.Rok} Lat";

            return View();
        }

        public IActionResult Calculator(KalkulatorDane dane)
        {
            switch (dane.znak)
            {
                case '+':
                    ViewBag.wynik = dane.pierwsza + dane.druga;
                    break;
                case '-':
                    ViewBag.wynik = dane.pierwsza - dane.druga;
                    break;
                case '*':
                    ViewBag.wynik = dane.pierwsza * dane.druga;
                    break;
                case '/':
                    ViewBag.wynik = dane.pierwsza / dane.druga;
                    break;
            };

            ViewBag.rozwiazanie = $"Wynik działania o znaku {dane.znak} to {ViewBag.wynik}";

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}