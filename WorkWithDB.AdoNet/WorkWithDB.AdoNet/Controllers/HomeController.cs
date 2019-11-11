using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorkWithDB.AdoNet.Models;
using WorkWithDB.AdoNet;
using Microsoft.Extensions.Configuration;
using ADO.NET.WorkWithDB;

namespace WorkWithDB.AdoNet.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult GithubProfileModel(IConfiguration config)
        {
            List<GithubProfileModel> modelList;
            DBConnection connection = new DBConnection(config.GetConnectionString("DefaultConnectionString"));
            connection.GetInfoFromDB(out modelList);

            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
