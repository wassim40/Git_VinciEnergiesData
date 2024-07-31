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
            return View();
        }

        public IActionResult IndexFTTS()
        {
            return View();
        }


    }
}
