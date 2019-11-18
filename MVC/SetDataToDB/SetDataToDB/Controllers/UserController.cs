using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SetDataToDB.EFCore;
using SetDataToDB.Models;

namespace SetDataToDB.Controllers
{
    public class UserController : Controller
    {
        public IActionResult UsersByName()
        {
            AppContext context = new AppContext("Server=DESKTOP-1E9TT7S\\SQLEXPRESS2017; Database=UserDB; Trusted_Connection=true;");

            return View(context.Users.ToList());
        }

        

    }
}
