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
                dBManager.ModificaBrano(brano);

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
        //Album
        [HttpGet]
        public IActionResult ModificaAlbum(int id)
        {
            var album = dBManager.GetAllAlbum().Where(x => x.IDAlbum == id).FirstOrDefault();
            return View(album);
        }

        [HttpPost]
        public IActionResult ModificaAlbum(AlbumViewModel album)
        {
            var res = dBManager.GetAllAlbum().Where(x => x.IDAlbum == album.IDAlbum).FirstOrDefault();
            if (res != null)
                dBManager.ModificaAlbum(album);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AggiungiAlbum()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AggiungiAlbum(AlbumViewModel album)
        {
            dBManager.AggiungiAlbum(album);
            return RedirectToAction("Index");
        }
        //Band
        [HttpGet]
        public IActionResult ModificaBand(int id)
        {
            var band = dBManager.GetAllBand().Where(x => x.IDBand == id).FirstOrDefault();
            return View(band);
        }

        [HttpPost]
        public IActionResult ModificaBand(BandViewModel band)
        {
            var res = dBManager.GetAllBand().Where(x => x.IDBand == band.IDBand).FirstOrDefault();
            if (res != null)
                dBManager.ModificaBand(band);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AggiungiBand()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AggiungiBand(BandViewModel band)
        {
            dBManager.AggiungiBand(band);
            return RedirectToAction("Index");
        }
        //Artista
        [HttpGet]
        public IActionResult ModificaArtista(int id)
        {
            var artista = dBManager.GetAllArtista().Where(x => x.IDArtista == id).FirstOrDefault();
            return View(artista);
        }

        [HttpPost]
        public IActionResult ModificaArtista(ArtistaViewModel artista)
        {
            var res = dBManager.GetAllArtista().Where(x => x.IDArtista == artista.IDArtista).FirstOrDefault();
            if (res != null)
                dBManager.ModificaArtista(artista);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AggiungiArtista()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AggiungiArtista(ArtistaViewModel artista)
        {
            dBManager.AggiungiArtista(artista);
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