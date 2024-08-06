using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using VinciEnergiesData.Data;
using VinciEnergiesData.Models;

namespace VinciEnergiesData.Controllers
{
    [Authorize]
    public class DT_B2BController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly string wwwrootDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files");
        
        public DT_B2BController(ApplicationDbContext db)
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
                if (!years.Contains(i.annee) && i.genre == Enums.GenreFolder.B2B && i.folder == Enums.FolderType.DossierTechnique)
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
                if (!villes.Contains(i.ville) && i.annee == year && i.genre == Enums.GenreFolder.B2B && i.folder == Enums.FolderType.DossierTechnique)
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
                if (i.ville == city && i.annee == year && i.genre == Enums.GenreFolder.B2B && i.folder == Enums.FolderType.DossierTechnique)
                {
                    folders.Add(i.codeSite);
                }
            }
            return View(folders);
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
        public IActionResult CreateFile(IFormFile myFile, string city, string year, string dossier)
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
            return View();
        }

       
    }
}
