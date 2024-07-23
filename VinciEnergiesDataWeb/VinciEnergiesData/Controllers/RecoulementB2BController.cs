using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VinciEnergiesData.Controllers
{
    [Authorize]
    public class RecoulementB2BController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
