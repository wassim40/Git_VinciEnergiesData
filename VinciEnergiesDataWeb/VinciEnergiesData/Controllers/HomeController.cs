using VinciEnergiesData.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using VinciEnergiesData.Data;

namespace VinciEnergiesData.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ApplicationDbContext _db;
        private readonly string wwwrootDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files");

        public HomeController(ApplicationDbContext db, ILogger<HomeController> logger)
        {
            _db = db;
            _logger = logger;

        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Index0()
        {
            return View();
        }

        public IActionResult Index1()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> LogOut()
        {

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login","Access");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //GET
        public IActionResult CreateFolder()
        {
            return View();
        }


        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateFolder(Dossier obj)
        {

            if (ModelState.IsValid)
            {

                obj.ville = obj.ville.ToUpper();
                _db.dossiers.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(obj);
        }


        public async Task<IActionResult> DownloadFile(string filePath)
        {

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files", filePath);

            var memory = new MemoryStream();

            using (var stream = new FileStream(path, FileMode.Open))

            {

                await stream.CopyToAsync(memory);

            }

            memory.Position = 0;

            var contentType = "APPLICATION/octet-stream";

            var fileName = Path.GetFileName(path);

            return File(memory, contentType, fileName);
        }
    }
}