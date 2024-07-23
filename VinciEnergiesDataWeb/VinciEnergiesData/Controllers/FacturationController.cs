using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VinciEnergiesData.Controllers
{
    [Authorize]
    public class FacturationController : Controller
    {

       
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult IndexB2B()
        {
            return RedirectToAction("Index", "FacturationB2B");
        }

        public IActionResult IndexFTTS()
        {
            return RedirectToAction("Index", "FacturationFTTS");
        }

        public IActionResult IndexFTTH()
        {
            return RedirectToAction("Index", "FacturationFTTH");
        }

        public IActionResult IndexBC()
        {
            return RedirectToAction("Index", "FacturationBC");
        }

        public IActionResult IndexPVR()
        {
            return RedirectToAction("Index", "FacturationPVR");
        }
    }
}
