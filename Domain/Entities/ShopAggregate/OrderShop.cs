using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.ShopAggregate
{
    public class OrderShop
    {
        public int Id { get; set; }

        public string GunName { get; set; }

        public string AmmunitonName { get; set; }

        public string AmmunitonCount { get; set; }
    }
}
