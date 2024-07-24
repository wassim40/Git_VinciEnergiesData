using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VinciEnergiesData.Controllers
{
    [Authorize]
    public class Facturation_PVR_BC_B2BController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
