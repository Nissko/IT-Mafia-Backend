using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Persistence;
using System.Web;
using System;
using System.Net;
using System.Text.RegularExpressions;
using Domain.Entities.MainAggregate;

namespace BackendMafia.Controllers.MainControllers
{
    [ApiController]
    [Route("[controller]")]
    public class MafiaCompanyController : ControllerBase
    {
        //DB Init
        private readonly MafiaApiDbContext dbMafiaCompany;

        public MafiaCompanyController(MafiaApiDbContext dbMafiaCompany)
        {
            this.dbMafiaCompany = dbMafiaCompany;
        }

        //Получение всех компаний с коллекциями
        [HttpGet]
        public IActionResult GetMafiaCompany()
        {
            /*Подключаем ICollection*/
            var mafiaCompanies = dbMafiaCompany.MafiaCompanies
                                .Select(z => z)
                                .Include(z => z.FinancialReports)
                                .ToList();

            return Ok(mafiaCompanies);
        }

        //Вывод какой семье принадлежит компания по ее названию
        [HttpGet]
        [Route("FindNameFamily/{name}")]
        public IActionResult GetContributorByName([FromRoute] string name)
        {
            string nameConverted;
            while ((nameConverted = Uri.UnescapeDataString(name)) != name)
                name = nameConverted;
            var FindMember = dbMafiaCompany.MafiaCompanies.FirstOrDefault(x => x.Name == nameConverted);

            if (FindMember != null)
            {
                return RedirectToAction("GetNameById", "MafiaFamily", new { id = FindMember.MafiaFamilyId });
            }

            return NotFound();
        }

        //Добавление компании
        [HttpPost]
        public IActionResult AddMafiaCompany(MafiaCompany AddMafiaCompanyRequest)
        {
            bool mafiaFamilyExists = dbMafiaCompany.MafiaFamilies.Any(x => x.Id == AddMafiaCompanyRequest.MafiaFamilyId);
            if (!mafiaFamilyExists)
            {
                return BadRequest("Компания не может относиться к этой семье. Указанного MafiaFamilyId не существует");
            }

            var MafiaCompany = new MafiaCompany(WebUtility.HtmlEncode(Regex.Replace(AddMafiaCompanyRequest.Name, "<[^>]*(>|$)", string.Empty)).ToString(),
                                               WebUtility.HtmlEncode(Regex.Replace(AddMafiaCompanyRequest.Address, "<[^>]*(>|$)", string.Empty)).ToString(),
                                               WebUtility.HtmlEncode(Regex.Replace(AddMafiaCompanyRequest.ContactPhone, "<[^>]*(>|$)", string.Empty)).ToString(),
                                               WebUtility.HtmlEncode(Regex.Replace(AddMafiaCompanyRequest.BusinessType, "<[^>]*(>|$)", string.Empty)).ToString(),
                                               AddMafiaCompanyRequest.MafiaFamilyId);


            dbMafiaCompany.MafiaCompanies.Add(MafiaCompany);
            dbMafiaCompany.SaveChanges();

            return Ok(MafiaCompany);
        }

        //Удаление компании по названию
        [HttpDelete]
        [Route("{name}")]
        public IActionResult DeleteMafiaMember([FromRoute] string name)
        {
            string nameConverted;
            while ((nameConverted = Uri.UnescapeDataString(name)) != name)
                name = nameConverted;
            var FindMember = dbMafiaCompany.MafiaCompanies.FirstOrDefault(x => x.Name == WebUtility.HtmlEncode(nameConverted));

            if (FindMember != null)
            {
                dbMafiaCompany.MafiaCompanies.Remove(FindMember);
                dbMafiaCompany.SaveChanges();
                return Ok("Компания лишилась покровительства");
            }

            return NotFound();
        }

    }
}
