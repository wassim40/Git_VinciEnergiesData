using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VinciEnergiesData.Controllers
{
    [Authorize]
    public class DT_B2BController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
