using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.ShopAggregate
{
    public class Ammunition
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [StringLength(150, ErrorMessage = "Введите корректное название", MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Range(0, 10000, ErrorMessage = "Введите корректное количество")]
        public int Count { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Range(0, 1000000, ErrorMessage = "Введите корректную цену")]
        public decimal Price { get; set; }
    }
}
