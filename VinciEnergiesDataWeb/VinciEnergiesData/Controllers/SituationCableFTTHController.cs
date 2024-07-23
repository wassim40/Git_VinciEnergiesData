using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VinciEnergiesData.Controllers
{
    [Authorize]
    public class SituationCableFTTHController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
