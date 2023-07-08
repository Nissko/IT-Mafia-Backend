using Domain.Entities;
using Domain.Entities.ShopAggregate;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using System.Net;
using System.Text.RegularExpressions;

namespace BackendMafia.Controllers.ShopControllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderShopController : ControllerBase
    {
        //DB Init
        private readonly MafiaApiDbContext dbOrderShop;

        public OrderShopController(MafiaApiDbContext dbOrderShop)
        {
            this.dbOrderShop = dbOrderShop;
        }

        //Получение списка всех заказов
        [HttpGet]
        public IActionResult GetMafiaMember()
        {
            return Ok(dbOrderShop.OrderShops.ToList());
        }

        //Добавление членов семьи
        [HttpPost]
        public IActionResult AddOrderShop(OrderShop AddOrderShopRequest)
        {
            // Проверка существования внешнего ключа
            bool mafiaMemberExists = dbOrderShop.OrderShops.Any(x => x.Id == AddOrderShopRequest.MafiaMemberId);
            if (!mafiaMemberExists)
            {
                return BadRequest("Заказ не может быть создан. Указанного MafiaMemberId не существует");
            }

            // Проверка не имеет ли оружия член мафии
            bool mafiaMemberFind = dbOrderShop.OrderShops.Any(x => x.MafiaMemberId == AddOrderShopRequest.MafiaMemberId);
            if (mafiaMemberFind)
            {
                return BadRequest("Заказ не может быть создан. У вас уже есть оружие");
            }

            var OrderShopAdd = new OrderShop(WebUtility.HtmlEncode(Regex.Replace(AddOrderShopRequest.GunName, "<[^>]*(>|$)", string.Empty)).ToString(),
                                             WebUtility.HtmlEncode(Regex.Replace(AddOrderShopRequest.AmmunitonName, "<[^>]*(>|$)", string.Empty)).ToString(),
                                             AddOrderShopRequest.AmmunitonCount,
                                             AddOrderShopRequest.MafiaMemberId);

            dbOrderShop.OrderShops.Add(OrderShopAdd);
            dbOrderShop.SaveChanges();

            return Ok(OrderShopAdd);
        }
    }
}
