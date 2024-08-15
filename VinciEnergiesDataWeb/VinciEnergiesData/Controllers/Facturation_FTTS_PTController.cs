﻿using Microsoft.AspNetCore.Mvc;
using VinciEnergiesData.Data;
using VinciEnergiesData.Enums;
using VinciEnergiesData.Models;

namespace VinciEnergiesData.Controllers
{
    public class Facturation_FTTS_PTController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly string wwwrootDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files");

        public Facturation_FTTS_PTController(ApplicationDbContext db)
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
                if (!years.Contains(i.annee) && i.dossier == Enums.GenreFolder.FTTS_PT.ToString())
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
                if (!villes.Contains(i.ville) && i.annee == year && i.dossier == Enums.GenreFolder.FTTS_PT.ToString())
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
                if (i.ville == city && i.annee == year && i.dossier == Enums.GenreFolder.FTTS_PT.ToString())
                {
                    files.Add(i.nom);
                }
            }
            var viewModel = new FileViewModel
            {
                Files = files,
                City = Enums.GenreFolder.FTTS_PT.ToString()
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
                if (i.ville == city && i.annee == year && i.dossier == GenreFolder.FTTS_PT.ToString())
                {
                    files0.Add(i.nom);
                }
            }
            var viewModel0 = new FileViewModel
            {
                Files = files0,
                City = Enums.GenreFolder.FTTS_PT.ToString()
            };
            return View(viewModel0);
        }

        [HttpPost]
        public IActionResult DeleteFile(string filePath, string city, string year)
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
            return RedirectToAction("CreateFile", new { city = city, year = year });
        }
    }

}