using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VinciEnergiesData.Controllers
{
    [Authorize]
    public class BilanOptiqueController : Controller
    {


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult IndexB2B()
        {
            return RedirectToAction("Index", "BO_B2B");
        }

        public IActionResult IndexFTTS()
        {
            return RedirectToAction("Index", "BO_FTTS");
        }
    }
}
