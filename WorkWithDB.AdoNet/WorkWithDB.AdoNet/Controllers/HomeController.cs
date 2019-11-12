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
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace WorkWithDB.AdoNet.Controllers
{
    public class HomeController : Controller
    {
        //IConfiguration config;
        [Route("db/GithubProfiles")]
        public IActionResult GithubProfiles()
        {
            List<GithubProfileModel> modelList;
            //string x = 
            DBConnection connection = new DBConnection("Data Source=STUDY-2-5\\SQLEXPRESS;Initial Catalog=Monitoring;Integrated Security=True;");// config.GetConnectionString("DefaultConnectionString"));
            connection.GetInfoFromDB(out modelList);
            Dictionary<string, List<GithubProfileModel>> pairs = new Dictionary<string, List<GithubProfileModel>>();

            return View(modelList);
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
