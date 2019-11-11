using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using _002_ModelToView.Models;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace _002_ModelToView.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            PlainModel plainModel = new PlainModel()
            {
                Company = "Apple",
                Employees = 1000000,
                Salary = 400000
            };

            ViewDataDictionary valuePairs = new ViewDataDictionary(ViewData);
            valuePairs.Add("Company", "Apple");
            valuePairs.Add("Employees", "1000000");
            valuePairs.Add("Salary", "400000");
            valuePairs.Add("user", "password");
            valuePairs.Add("count", valuePairs.Count);

            foreach (var item in valuePairs)
            {
                ViewData[item.Key] = item.Value;
            }
            return View(valuePairs);
        }
    }
}
