using Microsoft.AspNetCore.Mvc;
using MyMusic.Models;
using MyMusic.Repository;
using System.Data.SqlClient;
using System.Diagnostics;

namespace MyMusic.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private DBManager dBManager;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            dBManager = new DBManager();
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(dBManager.GetAllBrani());
        }

        [HttpGet]
        public IActionResult Modifica(int id)
        {
            var brano = dBManager.GetAllBrani().Where(x => x.IDBrano == id).FirstOrDefault();
            return View(brano);
        }

        [HttpPost]
        public IActionResult Modifica(BraniViewModel brano)
        {
            var res = dBManager.GetAllBrani().Where(x => x.IDBrano == brano.IDBrano).FirstOrDefault();
            if (res != null)
                dBManager.EditBrano(brano);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Aggiungi()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Aggiungi(BraniViewModel brano)
        {
            dBManager.AggiungiBrano(brano);
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
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