using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VinciEnergiesData.Data;

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
            return RedirectToAction("ShowYears");
        }


        //GET

        public IActionResult ShowYears()
        {
            var files = _db.dossiers.ToList();
            List<string> years = new List<string>();
            foreach (var i in files)
            {
                if (!years.Contains(i.annee) && i.genre == Enums.GenreFolder.FTTS && i.folder == Enums.FolderType.BilanOptique)
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
                if (!villes.Contains(i.ville) && i.annee == year)
                {
                    villes.Add(i.ville);
                }
            }
            return View(villes);
        }
    }
}
