using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VinciEnergiesData.Controllers
{
    [Authorize]
    public class RecoulementController : Controller
    {

       

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult IndexB2B()
        {
            return RedirectToAction("Index", "RecoulementB2B");
        }

        public IActionResult IndexFTTS()
        {
            return RedirectToAction("Index", "RecoulementFTTS");
        }

        public IActionResult IndexMaintenance()
        {
            return RedirectToAction("Index", "RecoulementMaintenance");
        }
    }
}
