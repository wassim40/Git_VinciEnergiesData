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

        public IActionResult Index_PVR_BC_B2B()
        {
            return RedirectToAction("Index", "Facturation_PVR_BC_B2B");
        }

        public IActionResult Index_PVR_BC_FTTS()
        {
            return RedirectToAction("Index", "Facturation_PVR_BC_FTTS");
        }
    }
}
