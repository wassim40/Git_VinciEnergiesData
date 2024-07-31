﻿using Microsoft.AspNetCore.Mvc;
using VinciEnergiesData.Data;

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
            var filesTable = _db.fichiers.ToList();
            List<string> files = new List<string>();
            foreach (var i in filesTable)
            {
                if (i.dossier == "Facturation_FTTS_PT")
                {
                    files.Add(i.nom);
                }
            }
            return View(files);
        }
    }

}
