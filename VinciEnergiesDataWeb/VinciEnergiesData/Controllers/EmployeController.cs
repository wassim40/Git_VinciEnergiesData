using Microsoft.AspNetCore.Mvc;
using VinciEnergiesData.Data;
using VinciEnergiesData.Models;

namespace VinciEnergiesData.Controllers
{
    public class EmployeController : Controller
    {

        private readonly ApplicationDbContext _db;

        public EmployeController(ApplicationDbContext db)
        {
            _db = db;
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }


        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(VMLogin obj)
        {

            if (ModelState.IsValid)
            {
                var admins = _db.administrateur.ToList();
                foreach (var i in admins)
                {
                    if(obj.Administrateur == i.Email && obj.AdminKey == i.AdminKey)
                    {
                        _db.vmLogins.Add(obj);
                        _db.SaveChanges();
                        return RedirectToAction("Index1","Home");
                    }
                }
            }
            return RedirectToAction("Index0", "Home");
        }


        public IActionResult CreateAdmin()
        {
            return View();
        }


        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateAdmin(Administrateur obj)
        {

            if (ModelState.IsValid)
            {
                var admins = _db.administrateur.ToList();
                foreach (var i in admins)
                {
                    if (obj.Admin0 == i.Email && obj.AdminKey0 == i.AdminKey)
                    {
                        _db.administrateur.Add(obj);
                        _db.SaveChanges();
                        return RedirectToAction("Index1", "Home");
                    }
                }
            }
            return RedirectToAction("Index0", "Home");
        }
    }
}
