using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VinciEnergiesData.Controllers
{
    [Authorize]
    public class SituationCableController : Controller
    {

       
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult IndexFTTS()
        {
            return RedirectToAction("Index", "SituationCableFTTS");
        }

        public IActionResult IndexFTTH()
        {
            return RedirectToAction("Index", "SituationCableFTTH");
        }

    }
}
