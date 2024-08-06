using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VinciEnergiesData.Data;
using VinciEnergiesData.Models;

namespace VinciEnergiesData.Controllers
{
    [Authorize]
    public class SituationCableFTTHController : Controller
    {

        private readonly ApplicationDbContext _db;
        private readonly string wwwrootDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files");

        public SituationCableFTTHController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return RedirectToAction("CreateFile");
        }

        public IActionResult CreateFile()
        {
            var filesTable = _db.fichiers.ToList();
            List<string> files = new List<string>();
            foreach (var i in filesTable)
            {
                if (i.dossier == Enums.GenreFolder.SC_FTTH.ToString())
                {
                    files.Add(i.nom);
                }
            }
            var viewModel = new FileViewModel
            {
                Files = files,
                City = Enums.GenreFolder.SC_FTTH.ToString()
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
