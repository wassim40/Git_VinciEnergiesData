using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VinciEnergiesData.Data;
using VinciEnergiesData.Enums;
using VinciEnergiesData.Models;

namespace VinciEnergiesData.Controllers
{
    [Authorize]
    public class BO_FTTSController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly string wwwrootDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files");

        public BO_FTTSController(ApplicationDbContext db)
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
                if (!villes.Contains(i.annee) && i.dossier == BO_Dossier.BO_FTTS.ToString())
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
                if (i.ville == city && i.dossier == BO_Dossier.BO_FTTS.ToString())
                {
                    files.Add(i.nom);
                }
            }
            var viewModel = new FileViewModel
            {
                Files = files,
                City = city,
                Year = BO_Dossier.BO_FTTS.ToString()
            };

            return View(viewModel);
        }
        [HttpPost]
        public IActionResult CreateFile(IFormFile myFile, string city, string dossier)
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
                    };

                    _db.fichiers.Add(fichier);
                    _db.SaveChanges();

                }
            }
            if (myFile == null)
            {
                ModelState.AddModelError("CustomError", "The file field is required.");
            }

            var filesTable0 = _db.fichiers.ToList();
            List<string> files0 = new List<string>();
            foreach (var i in filesTable0)
            {
                if (i.ville == city && i.dossier == BO_Dossier.BO_FTTS.ToString())
                {
                    files0.Add(i.nom);
                }
            }
            var viewModel0 = new FileViewModel
            {
                Files = files0,
                City = city,
                Year = BO_Dossier.BO_FTTS.ToString()
            };
            return View(viewModel0);
        }

        [HttpPost]
        public IActionResult DeleteFile(string filePath, string city)
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                var fullPath = Path.Combine(wwwrootDirectory, filePath);
                if (System.IO.File.Exists(fullPath))
                {
                    System.IO.File.Delete(fullPath);

                    // Optionally, add a message or redirect to indicate success
                    var files = _db.fichiers.ToList();
                    foreach (var fichier in files)
                    {
                        if (fichier.nom == filePath)
                        {
                            _db.fichiers.Remove(fichier);
                            _db.SaveChanges();
                        }
                    }
                }
            }

            // Adjust the redirect to pass the city back if necessary
            return RedirectToAction("CreateFile", new { city = city });
        }

    }
}
