using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VinciEnergiesData.Data;

namespace VinciEnergiesData.Controllers
{
    [Authorize]
    public class RecoulementFTTSController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly string wwwrootDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files");

        public RecoulementFTTSController(ApplicationDbContext db)
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
                if (!years.Contains(i.annee) && i.genre == Enums.GenreFolder.FTTS && i.folder == Enums.FolderType.Recoulement)
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
                if (!villes.Contains(i.ville) && i.annee == year && i.genre == Enums.GenreFolder.FTTS && i.folder == Enums.FolderType.Recoulement)
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
                if (i.ville == city && i.annee == year && i.genre == Enums.GenreFolder.FTTS && i.folder == Enums.FolderType.Recoulement)
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
    }
}
