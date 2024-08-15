using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VinciEnergiesData.Data;
using VinciEnergiesData.Models;

namespace VinciEnergiesData.Controllers
{
    [Authorize]
    public class RecoulementMaintenanceController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly string wwwrootDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files");

        public RecoulementMaintenanceController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return RedirectToAction("ShowYears");
        }


        //GET
        public IActionResult ShowYears()
        {
            var files = _db.dossiers.ToList();
            List<string> years = new List<string>();
            foreach (var i in files)
            {
                if (!years.Contains(i.annee) && i.genre == Enums.GenreFolder.Maintenance && i.folder == Enums.FolderType.Recoulement)
                {
                    years.Add(i.annee);
                }
            }
            return View(years);
        }

        public IActionResult ShowVilles(string year)
        {
            var files = _db.dossiers.ToList();
            List<string> villes = new List<string>();
            foreach (var i in files)
            {
                if (!villes.Contains(i.ville) && i.annee == year && i.genre == Enums.GenreFolder.Maintenance && i.folder == Enums.FolderType.Recoulement)
                {
                    villes.Add(i.ville);
                }
            }
            var villes_year = new ShowVillesViewModel
            {
                Year = year,
                Villes = villes
            };
            return View(villes_year);
        }


        public IActionResult ShowFolders(string city, string year)
        {
            var files = _db.dossiers.ToList();
            List<string> folders = new List<string>();
            foreach (var i in files)
            {
                if (i.ville == city && i.annee == year && i.genre == Enums.GenreFolder.Maintenance && i.folder == Enums.FolderType.Recoulement)
                {
                    folders.Add(i.codeSite);
                }
            }
            return View(folders);
        }
        public IActionResult ShowFiles(string city)
        {
            var filesTable = _db.fichiers.ToList();
            List<string> files = new List<string>();
            foreach (var i in filesTable)
            {
                if (i.dossier == city)
                {
                    files.Add(i.nom);
                }
            }
            return View(files);
        }

        public IActionResult CreateFile(string fold)
        {
            var filesTable = _db.fichiers.ToList();
            List<string> files = new List<string>();
            foreach (var i in filesTable)
            {
                if (i.dossier == fold)
                {
                    files.Add(i.nom);
                }
            }
            var viewModel = new FileViewModel
            {
                Files = files,
                City = fold
            };

            return View(viewModel);
        }
        [HttpPost]
        public IActionResult CreateFile(IFormFile myFile, string dossier)
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
                    };

                    _db.fichiers.Add(fichier);
                    _db.SaveChanges();


                }
            }

            if (myFile == null)
            {
                ModelState.AddModelError("CustomError", "The file field is required.");
            }

            var filesTable = _db.fichiers.ToList();
            List<string> files = new List<string>();
            foreach (var i in filesTable)
            {
                if (i.dossier == dossier)
                {
                    files.Add(i.nom);
                }
            }
            var viewModel = new FileViewModel
            {
                Files = files,
                City = dossier
            };
            return View(viewModel);
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
            return RedirectToAction("CreateFile", new { fold = city });
        }
    }
}
