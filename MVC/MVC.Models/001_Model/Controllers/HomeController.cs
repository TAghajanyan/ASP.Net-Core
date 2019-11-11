using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using _001_Model.Models;

namespace _001_Model.Controllers
{
    public class HomeController : Controller
    {
        //[Route("{controller}/index/{id?}")]
        public string Index()
        {
            PlainModel model = new PlainModel()
            {
                Company = "AppleIndex",
                Employees = 1000000,
                Salary = 400000
            };

            return $"Company: {model.Company}\nEmployees: {model.Employees}\nSalary: {model.Salary}\n";

        }

        public string Home1()
        {
            PlainModel model = new PlainModel()
            {
                Company = "AppleIndex1",
                Employees = 2000000,
                Salary = 800000
            };

            return $"Company: {model.Company}\nEmployees: {model.Employees}\nSalary: {model.Salary}\n";
        }

    }
}
