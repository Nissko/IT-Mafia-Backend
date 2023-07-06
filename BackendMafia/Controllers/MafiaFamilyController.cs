
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Net;
using System.Text.RegularExpressions;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MafiaFamilyController : ControllerBase
    {
        //DB Init
        private readonly MafiaApiDbContext dbMafiaFamily;

        public MafiaFamilyController(MafiaApiDbContext dbMafiaFamily) 
        {
            this.dbMafiaFamily = dbMafiaFamily;
        }
        
        //Получение списка всех семей со всеми коллекциями
        [HttpGet]
        public IActionResult GetMafiaFamily()
        {
            /*Подключаем ICollection*/
            var mafiaFamilies = dbMafiaFamily.MafiaFamilies
                                .Include(t => t.MafiaMembers)
                                .Include(t => t.MafiaCompanies)
                                .ThenInclude(MafiaCompany => MafiaCompany.FinancialReports)
                                .ToList();

            return Ok(mafiaFamilies);
        }

        //Поиск названия семьи по её ID (Вспомогательный)
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetNameById([FromRoute] int id)
        {
            var FindMember = dbMafiaFamily.MafiaFamilies.FirstOrDefault(x => x.Id == id);

            if (FindMember != null)
            {
                return Ok(new { Name = FindMember.Name });
            }

            return NotFound();
        }

        //Список всех "опекаемых" компаний в городе по названию семьи
        [HttpGet]
        [Route("FindCompaniesForName/{name}")]
        public IActionResult GetCompaniesByName([FromRoute] string name)
        {
            string nameConverted;
            while ((nameConverted = Uri.UnescapeDataString(name)) != name)
                name = nameConverted;
            var FindMember = dbMafiaFamily.MafiaFamilies
                            .Include(t => t.MafiaCompanies)
                            .ThenInclude(MafiaCompany => MafiaCompany.FinancialReports)
                            .FirstOrDefault(x => x.Name == nameConverted);

            if (FindMember != null)
            {
                return Ok(new { Companies = FindMember.MafiaCompanies.ToList() });
            }

            return NotFound();
        }

        //Добавление информации о новой семье
        [HttpPost]
        public IActionResult AddMafiaFamily(MafiaFamily AddMafiaFamilyRequest)
        {
            var MafiaFamily = new MafiaFamily(WebUtility.HtmlEncode(Regex.Replace(AddMafiaFamilyRequest.Name, "<[^>]*(>|$)", string.Empty)).ToString(),
                                               WebUtility.HtmlEncode(Regex.Replace(AddMafiaFamilyRequest.Description, "<[^>]*(>|$)", string.Empty)).ToString());

            dbMafiaFamily.MafiaFamilies.Add(MafiaFamily);
            dbMafiaFamily.SaveChanges();

            return Ok(MafiaFamily);
        }

        //Удаление информации о семье
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteMafiaFamily([FromRoute] int id)
        {
            var FindFamily = dbMafiaFamily.MafiaFamilies.Find(id);

            if (FindFamily != null)
            {
                dbMafiaFamily.Remove(FindFamily);
                dbMafiaFamily.SaveChanges();

                return Ok("Семья расформирована");
            }

            return NotFound();
        }
    }
}
