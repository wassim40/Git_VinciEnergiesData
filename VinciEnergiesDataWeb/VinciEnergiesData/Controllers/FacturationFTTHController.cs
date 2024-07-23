using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VinciEnergiesData.Controllers
{
    [Authorize]
    public class FacturationFTTHController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
