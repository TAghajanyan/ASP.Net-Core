using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _003_Model.Models
{
    public class CarModel
    {
        public string Model { get; set; }
        public int Price { get; set; }

        public CarModel(string model, int price)
        {
            Model = model;
            Price = price;
        }

        internal string GetInfo()
        {
            return $"Model: {Model}{Environment.NewLine}Price: {Price}";
        }
    }
}
