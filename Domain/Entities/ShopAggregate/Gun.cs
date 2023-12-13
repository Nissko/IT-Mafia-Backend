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

        [Required(ErrorMessage = "Обязательное поле")]
        [StringLength(100, ErrorMessage = "Введите корректное название")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Range(0, 100, ErrorMessage = "Введите корректное кол-во")]
        public int Count { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [StringLength(50, ErrorMessage = "Введите корректный тип", MinimumLength = 3)]
        public string Type { get; set; }

        [StringLength(30, ErrorMessage = "Введите корректный тип поддерживаемых патронов")]
        public string SupportAmmo { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Range(0, 1000000, ErrorMessage = "Введите корректную цену")]
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
