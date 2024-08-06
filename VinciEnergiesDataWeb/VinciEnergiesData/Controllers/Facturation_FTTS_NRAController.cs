using Microsoft.AspNetCore.Mvc;
using VinciEnergiesData.Data;
using VinciEnergiesData.Models;

namespace VinciEnergiesData.Controllers
{
    public class Facturation_FTTS_NRAController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly string wwwrootDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files");

        public Facturation_FTTS_NRAController(ApplicationDbContext db)
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
            var files = _db.fichiers.ToList();
            List<string> years = new List<string>();
            foreach (var i in files)
            {
                if (!years.Contains(i.annee) && i.dossier == Enums.GenreFolder.FTTS_NRA.ToString())
                {
                    years.Add(i.annee);
                }
            }
            return View(years);
        }

        public IActionResult ShowVilles(string year)
        {
            var files = _db.fichiers.ToList();
            List<string> villes = new List<string>();
            foreach (var i in files)
            {
                if (!villes.Contains(i.ville) && i.annee == year && i.dossier == Enums.GenreFolder.FTTS_NRA.ToString())
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
        public IActionResult CreateFile(string city, string year)
        {
            var filesTable = _db.fichiers.ToList();
            List<string> files = new List<string>();
            foreach (var i in filesTable)
            {
                if (i.ville == city && i.annee == year)
                {
                    files.Add(i.nom);
                }
            }
            var viewModel = new FileViewModel
            {
                Files = files,
                City = Enums.GenreFolder.FTTS_NRA.ToString()
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
