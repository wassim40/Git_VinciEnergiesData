using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VinciEnergiesData.Data;


namespace VinciEnergiesData.Controllers
{
    [Authorize]
    public class DT_MaintenanceController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly string wwwrootDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files");

        public DT_MaintenanceController(ApplicationDbContext db)
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
                if (!years.Contains(i.annee) && i.genre == Enums.GenreFolder.Maintenance && i.folder == Enums.FolderType.DossierTechnique)
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
                if (!villes.Contains(i.ville) && i.annee == year && i.genre == Enums.GenreFolder.Maintenance && i.folder == Enums.FolderType.DossierTechnique)
                {
                    villes.Add(i.ville);
                }
            }
            return View(villes);
        }
        public IActionResult ShowFolders(string city, string year)
        {
            var files = _db.dossiers.ToList();
            List<string> folders = new List<string>();
            foreach (var i in files)
            {
                if (i.ville == city && i.annee == year && i.genre == Enums.GenreFolder.Maintenance && i.folder == Enums.FolderType.DossierTechnique)
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
