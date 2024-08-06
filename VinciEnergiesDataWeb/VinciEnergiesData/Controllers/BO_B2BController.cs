using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VinciEnergiesData.Data;
using VinciEnergiesData.Models;

namespace VinciEnergiesData.Controllers
{
    [Authorize]
    public class BO_B2BController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly string wwwrootDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files");

        public BO_B2BController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return RedirectToAction("ShowVilles");
        }


        //GET

        public IActionResult ShowVilles()
        {
            var files = _db.fichiers.ToList();
            List<string> villes = new List<string>();
            foreach (var i in files)
            {
                if (!villes.Contains(i.annee) && i.dossier == BO_Dossier.BO_B2B.ToString())
                {
                    villes.Add(i.ville);
                }
            }
            return View(villes);
        }

        public IActionResult CreateFile(string city)
        {
            var filesTable = _db.fichiers.ToList();
            List<string> files = new List<string>();
            foreach (var i in filesTable)
            {
                if (i.ville == city && i.dossier == BO_Dossier.BO_B2B.ToString())
                {
                    files.Add(i.nom);
                }
            }
            var viewModel = new FileViewModel
            {
                Files = files,
                City = BO_Dossier.BO_B2B.ToString()
            };

            return View(viewModel);
        }
        [HttpPost]
        public IActionResult CreateFile(IFormFile myFile, string city, string year, string dossier)
        {
            if (ModelState.IsValid)
            {
                if (myFile != null && myFile.Length > 0)
                {
                    var fileName = Path.GetFileName(myFile.FileName);
                    var fileExtension = Path.GetExtension(myFile.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        myFile.CopyTo(stream);
                    }

                    var fichier = new Fichier
                    {
                        nom = fileName,
                        extension = fileExtension,
                        dossier = dossier, // Assuming you save files in the "uploads" folder
                        ville = city.ToUpper(),
                        annee = year
                    };

                    _db.fichiers.Add(fichier);
                    _db.SaveChanges();

                    return RedirectToAction("Index"); // or wherever you want to redirect after the upload
                }
            }

            return View();
        }
    }
}
