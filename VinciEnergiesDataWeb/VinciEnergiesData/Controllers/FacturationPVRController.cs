using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VinciEnergiesData.Controllers
{
    [Authorize]
    public class FacturationPVRController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
