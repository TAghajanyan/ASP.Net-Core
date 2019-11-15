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
    public class dbController : Controller
    {
        private static List<GithubProfileModel> modelList;

        public dbController(IConfiguration config)
        {
            DBConnection connection = new DBConnection(config.GetSection("ConnectionString").GetValue<string>("DefaultConnectionString"));
            connection.GetInfoFromDB(out modelList);
        }

        //IConfiguration config;
        [Route("db/GithubProfiles")]
        public IActionResult GithubProfiles()
        {
            return View(modelList);
        }
    }
}
