using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.ShopAggregate
{
    public class OrderShop
    {
        public int Id { get; private set; }

        [Required(ErrorMessage = "Обязательное поле")]

        public string GunName { get; set; }

        //Можно купить без патронов
        public string AmmunitonName { get; set; }

        //Можно купить без патронов
        [Range(0, 1000000, ErrorMessage = "Введите корректное количество")]
        public int AmmunitonCount { get; set; }

        [Required]
        public int MafiaMemberId { get; set; }

        public OrderShop(string gunName, string ammunitonName, int ammunitonCount, int mafiaMemberId)
        {
            GunName = gunName;
            AmmunitonName = ammunitonName;
            AmmunitonCount = ammunitonCount;
            MafiaMemberId = mafiaMemberId;
        }
    }
}
