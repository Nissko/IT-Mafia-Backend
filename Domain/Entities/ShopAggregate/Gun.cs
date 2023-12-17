using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.ShopAggregate
{
    public class Gun
    {
        public int Id { get; private set; }

        public string Name { get; set; }

        public int Count { get; set; }

        public string Type { get; set; }

        public string SupportAmmo { get; set; }

        public decimal Price { get; set; }

        public Gun(string name, int count, string type, string supportAmmo, decimal price) 
        { 
            Name = name;
            Count = count;
            Type = type;
            SupportAmmo = supportAmmo;
            Price = price;
        }
    }
}
