using Domain.Entities.MainAggregate;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Net;
using System.Text.RegularExpressions;

namespace BackendMafia.Controllers.MainControllers
{
    [ApiController]
    [Route("[controller]")]
    public class MafiaMemberController : ControllerBase
    {
        //DB Init
        private readonly MafiaApiDbContext dbMafiaMember;

        public MafiaMemberController(MafiaApiDbContext dbMafiaMember)
        {
            this.dbMafiaMember = dbMafiaMember;
        }

        //Получение списка всех членов семей
        [HttpGet]
        public IActionResult GetMafiaMember()
        {
            /*Подключаем ICollection*/
            var mafiaMembers = dbMafiaMember.MafiaMembers
                                .Select(z => z)
                                .Include(z => z.OrderShops);

            return Ok(mafiaMembers);
        }

        //Добавление членов семьи
        [HttpPost]
        public IActionResult AddMafiaMember(MafiaMember AddMafiaMemberRequuest)
        {
            // Проверка существования внешнего ключа
            bool mafiaFamilyExists = dbMafiaMember.MafiaFamilies.Any(x => x.Id == AddMafiaMemberRequuest.MafiaFamilyId);
            if (!mafiaFamilyExists)
            {
                return BadRequest("Участник не может относиться к этой семье. Указанного MafiaFamilyId не существует");
            }

            var MafiaMember = new MafiaMember(WebUtility.HtmlEncode(Regex.Replace(AddMafiaMemberRequuest.Name, "<[^>]*(>|$)", string.Empty)).ToString(),
                                               WebUtility.HtmlEncode(Regex.Replace(AddMafiaMemberRequuest.Surname, "<[^>]*(>|$)", string.Empty)).ToString(),
                                               WebUtility.HtmlEncode(Regex.Replace(AddMafiaMemberRequuest.Patronymic, "<[^>]*(>|$)", string.Empty)).ToString(),
                                               WebUtility.HtmlEncode(Regex.Replace(AddMafiaMemberRequuest.Birthday, "<[^>]*(>|$)", string.Empty)).ToString(),
                                               WebUtility.HtmlEncode(Regex.Replace(AddMafiaMemberRequuest.Phone, "<[^>]*(>|$)", string.Empty)).ToString(),
                                               AddMafiaMemberRequuest.MafiaFamilyId,
                                               AddMafiaMemberRequuest.Health,
                                               AddMafiaMemberRequuest.Strength);

            dbMafiaMember.MafiaMembers.Add(MafiaMember);
            dbMafiaMember.SaveChanges();

            return Ok(MafiaMember);
        }

        //Update
        [HttpPut]
        [Route("/health/{id:int}/{health:int}")]
        public IActionResult UpdateHealth([FromRoute] int id, [FromRoute] int health)
        {
            var FindMember = dbMafiaMember.MafiaMembers.Find(id);

            if (FindMember != null)
            {
                FindMember.Health = health;
                dbMafiaMember.SaveChanges();
                return Ok(String.Format("Показатель здоровья {0} обновлен значением {1}", FindMember.Name, health));
            }

            return NotFound();
        }

        [HttpPut]
        [Route("/strength/{id:int}/{strength:int}")]
        public IActionResult UpdateStrength([FromRoute] int id, [FromRoute] int strength)
        {
            var FindMember = dbMafiaMember.MafiaMembers.Find(id);

            if (FindMember != null)
            {
                FindMember.Strength = strength;
                dbMafiaMember.SaveChanges();
                return Ok(String.Format("Показатель силы {0} обновлен значением {1}", FindMember.Name, strength));
            }

            return NotFound();
        }

        [HttpPut]
        [Route("/battle/{id1:int}/{id2:int}")]
        public IActionResult Battle([FromRoute] int id1, [FromRoute] int id2)
        {
            var FindMember1 = dbMafiaMember.MafiaMembers.Find(id1);
            var FindMember2 = dbMafiaMember.MafiaMembers.Find(id2);

            if (FindMember1 != null && FindMember2 != null)
            {
                FindMember1.Health -= FindMember2.Strength;
                FindMember2.Health -= FindMember1.Strength;
                bool flag1 = false, flag2 = false;
                if (FindMember1.Health < 0)
                {
                    FindMember2.Strength += FindMember1.Strength;
                    dbMafiaMember.Remove(FindMember1);
                    flag2 = true;
                }
                if (FindMember2.Health < 0)
                {
                    FindMember1.Strength += FindMember2.Strength;
                    dbMafiaMember.Remove(FindMember2);
                    flag1 = true;
                }
                dbMafiaMember.SaveChanges();
                if (flag1) return Ok(String.Format("Бой завершился победой {0}", FindMember1.Name));
                if (flag2) return Ok(String.Format("Бой завершился победой {0}", FindMember2.Name));
                return Ok("Бой завершился ничьей");
            }

            return NotFound();
        }

        //Удаление члена семьи
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteMafiaMember([FromRoute] int id)
        {
            var FindMemberDelete = dbMafiaMember.MafiaMembers.Find(id);

            if (FindMemberDelete != null)
            {
                dbMafiaMember.Remove(FindMemberDelete);
                dbMafiaMember.SaveChanges();
                return Ok("Член семьи был изгнан");
            }

            return NotFound();
        }
    }
}
