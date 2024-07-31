﻿using Microsoft.AspNetCore.Mvc;
using VinciEnergiesData.Data;

namespace VinciEnergiesData.Controllers
{
    public class Facturation_B2B_NRAController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly string wwwrootDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files");

        public Facturation_B2B_NRAController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var filesTable = _db.fichiers.ToList();
            List<string> files = new List<string>();
            foreach (var i in filesTable)
            {
                if (i.dossier.ToString()== "Facturation_B2B_NRA")
                {
                    files.Add(i.nom);
                }
            }
            return View(files);
        }
    }
}
