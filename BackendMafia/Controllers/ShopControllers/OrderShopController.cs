using Domain.Entities;
using Domain.Entities.MainAggregate;
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
        //DB Init OrderShop
        private readonly MafiaApiDbContext dbOrderShop;
        private readonly MafiaApiDbContext dbGun;
        private readonly MafiaApiDbContext dbAmmunition;
        private readonly MafiaApiDbContext dbMafiaMember;
        private readonly MafiaApiDbContext dbMafiaFamily;

        public OrderShopController(MafiaApiDbContext dbOrderShop,
                                   MafiaApiDbContext dbGun,
                                   MafiaApiDbContext dbAmmunition,
                                   MafiaApiDbContext dbMafiaMember,
                                   MafiaApiDbContext dbMafiaFamily)
        {
            this.dbOrderShop = dbOrderShop;
            this.dbGun = dbGun;
            this.dbAmmunition = dbAmmunition;
            this.dbMafiaMember = dbMafiaMember;
            this.dbMafiaFamily = dbMafiaFamily;
        }

        //Получение списка всех заказов
        [HttpGet]
        public IActionResult GetMafiaMember()
        {
            return Ok(dbOrderShop.OrderShops.ToList());
        }

        //Создание заказа
        [HttpPost]
        public IActionResult AddOrderShop(OrderShop AddOrderShopRequest)
        {
            //Проверка вводимых значений
            var validationResult = ValidateAddOrderShop(AddOrderShopRequest);
            if (validationResult != null)
            {
                return validationResult; // Возвращаем ошибку, если проверки не прошли успешно
            }

            //Расчет стоимости
            var ValidatePriceResult = ValidateAddOrderShopPrice(AddOrderShopRequest);
            if (ValidatePriceResult != null)
            {
                return ValidatePriceResult; // Возвращаем ошибку, если расчет не прошел успешно
            }

            var OrderShopAdd = new OrderShop(WebUtility.HtmlEncode(Regex.Replace(AddOrderShopRequest.GunName, "<[^>]*(>|$)", string.Empty)).ToString(),
                                             WebUtility.HtmlEncode(Regex.Replace(AddOrderShopRequest.AmmunitonName, "<[^>]*(>|$)", string.Empty)).ToString(),
                                             AddOrderShopRequest.AmmunitonCount,
                                             AddOrderShopRequest.MafiaMemberId);

            if (OrderShopAdd != null)
            {
                /* Создание нового заказа и сохранение изменений */
                dbOrderShop.OrderShops.Add(OrderShopAdd);
                dbOrderShop.SaveChanges();

                return Ok(OrderShopAdd);
            }
            else
            {
                var error = new SerializableError();
                error.Add("Заказ не был создан", "Проверьте корректность введенных данных");

                return new BadRequestObjectResult(error);
            }
        }

        //Метод валидации цены
        private IActionResult ValidateAddOrderShopPrice(OrderShop AddOrderShopRequest)
        {
            //Получение члена семьи из БД
            var MafiaMemberDb = dbMafiaMember.MafiaMembers.SingleOrDefault(x => x.Id == AddOrderShopRequest.MafiaMemberId);
            //Получение семьи из БД
            var MafiaFamilyDb = dbMafiaFamily.MafiaFamilies.SingleOrDefault(x => x.Id == MafiaMemberDb.MafiaFamilyId);
            //Инициализация переменной
            decimal TotalPrice = 0;

            //Получение цены оружия
            var GunDb = dbGun.Guns.SingleOrDefault(x => x.Name == AddOrderShopRequest.GunName); //Поиск оружия в БД
            if (GunDb != null)
            {
                TotalPrice += GunDb.Price;
            }
            else
            {
                var error = new SerializableError();
                error.Add("Стоимость", "Не удалось рассчитать стоимость оружия, проверьте корректность ввода");

                return new BadRequestObjectResult(error);
            }

            //Получение цены патронов
            var AmmunitionDb = dbAmmunition.Ammunitions.SingleOrDefault(x => x.Name == AddOrderShopRequest.AmmunitonName); //Поиск патрон в бд
            if (GunDb.Type == "Огнестрельное") //получение типа оружия
            {
                if (AmmunitionDb != null)
                {
                    TotalPrice += AmmunitionDb.Price * AddOrderShopRequest.AmmunitonCount;
                }
                else
                {
                    var error = new SerializableError();
                    error.Add("Стоимость", "Не удалось рассчитать стоимость патронов, проверьте корректность ввода");

                    return new BadRequestObjectResult(error);
                }
            }


            //Проверка работоспобности расчета стоимости
            if (TotalPrice < 0)
            {
                var error = new SerializableError();
                error.Add("Стоимость", "Не удалось выполнить функцию расчета стоимости, проверьте корректность вводимых данных");

                return new BadRequestObjectResult(error);
            }

            //Проверка бюджета
            if (MafiaFamilyDb.FamilyMoney < TotalPrice)
            {
                var error = new SerializableError();
                error.Add("Бюджет", "Не удалось совершить покупку, в бюджете семьи недостаточно денег");

                return new BadRequestObjectResult(error);
            }
            else
            {
                //Проверяем, что оружие в наличии
                if (GunDb.Count > 0)
                {
                    //Изменение количества оружия
                    GunDb.Count--;
                    dbGun.SaveChanges();
                }
                else
                {
                    var error = new SerializableError();
                    error.Add("Количество оружия", "Не удалось совершить покупку, выбранное оружие закончилось");

                    return new BadRequestObjectResult(error);
                }

                if (GunDb.Type == "Огнестрельное")
                {
                    //Изменение количества патрон
                    AmmunitionDb.Count = AmmunitionDb.Count - AddOrderShopRequest.AmmunitonCount;
                    dbAmmunition.SaveChanges();
                }

                //Изменение бюджета семьи
                MafiaFamilyDb.FamilyMoney = MafiaFamilyDb.FamilyMoney - TotalPrice;
                dbMafiaFamily.SaveChanges();
            }

            return null; // Если все проверки прошли успешно
        }

        //Метод валидации создания заказа
        private IActionResult ValidateAddOrderShop(OrderShop AddOrderShopRequest)
        {
            // Проверка существования внешнего ключа
            bool mafiaMemberExists = dbOrderShop.MafiaMembers.Any(x => x.Id == AddOrderShopRequest.MafiaMemberId);
            if (!mafiaMemberExists)
            {
                var error = new SerializableError();
                error.Add("Член семьи", "Указанный член мафии не найден");

                return new BadRequestObjectResult(error);
            }

            // Проверка, не имеет ли оружия член мафии
            bool mafiaMemberGunFind = dbOrderShop.OrderShops.Any(x => x.MafiaMemberId == AddOrderShopRequest.MafiaMemberId);
            if (mafiaMemberGunFind)
            {
                var error = new SerializableError();
                error.Add("Член семьи", "У указанного члена мафии уже есть оружие");

                return new BadRequestObjectResult(error);
            }

            //Если выбранное оружие не совпадает с оружием из БД
            bool GunSelect = dbGun.Guns.Any(x => x.Name == AddOrderShopRequest.GunName);
            if (!GunSelect)
            {
                var error = new SerializableError();
                error.Add("Оружие", "Указанное оружия не найдено");

                return new BadRequestObjectResult(error);
            }

            //Если выбранные патроны не подходят для оружия
            bool AmmunitionSelect = dbGun.Guns.Any(x => x.SupportAmmo == AddOrderShopRequest.AmmunitonName);
            if (!AmmunitionSelect)
            {
                var error = new SerializableError();
                error.Add("Патроны", "Выбранные патроны не подходят к этому оружию");

                return new BadRequestObjectResult(error);
            }

            //Если человек хочет купить патроны
            if (AddOrderShopRequest.AmmunitonCount != 0)
            {
                //Поиск патронов в БД
                var ammunition = dbAmmunition.Ammunitions.SingleOrDefault(x => x.Name == AddOrderShopRequest.AmmunitonName);

                //Проверка на существование указанных патрон
                if (ammunition == null)
                {
                    var error = new SerializableError();
                    error.Add("Выбранные патроны", "Выбранных патронов нет в наличии");

                    return new BadRequestObjectResult(error);
                }

                //Если количество патронов в БД меньше, чем хотят купить
                if (ammunition.Count < AddOrderShopRequest.AmmunitonCount)
                {
                    var error = new SerializableError();
                    error.Add("Количество патронов", "Вы хотите купить больше, чем есть на складе");

                    return new BadRequestObjectResult(error);
                }
            }

            return null; // Если все проверки прошли успешно
        }
    }
}