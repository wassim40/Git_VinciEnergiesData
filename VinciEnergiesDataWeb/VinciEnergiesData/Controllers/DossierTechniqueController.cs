using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VinciEnergiesData.Controllers
{
    [Authorize]
    public class DossierTechniqueController : Controller
    {

        [Authorize]

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult IndexB2B()
        {
            return RedirectToAction("Index","DT_B2B");
        }

        public IActionResult IndexFTTS()
        {
            return RedirectToAction("Index", "DT_FTTS");
        }

        public IActionResult IndexMaintenance()
        {
            return RedirectToAction("Index", "DT_Maintenance");
        }
    }
}
