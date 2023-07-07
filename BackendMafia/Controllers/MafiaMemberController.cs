using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using System.Net;
using System.Text.RegularExpressions;

namespace Presentation.Controllers
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
            return Ok(dbMafiaMember.MafiaMembers.ToList());
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
                                               AddMafiaMemberRequuest.MafiaFamilyId);

            dbMafiaMember.MafiaMembers.Add(MafiaMember);
            dbMafiaMember.SaveChanges();

            return Ok(MafiaMember);
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
