using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VinciEnergiesData.Controllers
{
    public class FacturationBCController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
