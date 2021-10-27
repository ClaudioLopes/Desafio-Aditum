using Desafio.Service;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Desafio.Controllers
{
    public class HomeController : Controller
    {
        private readonly HomeService homeService;

        public HomeController()
        {
            homeService = new HomeService();
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Filter(TimeSpan hora)
        {
            var model = homeService.GetRestaurantesByHora(hora);

            return PartialView("_ListaRestaurantes", model);
        }
    }
}
