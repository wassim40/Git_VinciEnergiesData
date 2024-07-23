﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VinciEnergiesData.Controllers
{
    [Authorize]
    public class BO_FTTSController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
