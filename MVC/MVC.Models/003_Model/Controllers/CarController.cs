using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _003_Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace _003_Model.Controllers
{
    public class CarController : Controller
    {
        public string BMW()
        {
            CarModel car = new CarModel("BMW", 150000);
            return car.GetInfo();
        }

        public string Mazda()
        {
            CarModel car = new CarModel("Mazda", 80000);
            return car.GetInfo();
        }

        public IActionResult AllCars()
        {
            List<CarModel> cars = new List<CarModel>();
            cars.Add(new CarModel("BMW", 150000));
            cars.Add(new CarModel("Mazda", 80000));

            return View(cars);
        }
    }
}