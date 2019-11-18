using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Razor.Controllers
{
    public class RazorController : Controller
    {
        public IActionResult WriteFromSevice()
        {
            return View();
        }
    }
}