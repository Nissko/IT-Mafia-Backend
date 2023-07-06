using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Persistence;
using Persistence.Migrations;
using System.Web;
using System;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MafiaCompanyController : ControllerBase
    {
        private readonly MafiaApiDbContext dbMafiaCompany;

        //Show All
        public MafiaCompanyController(MafiaApiDbContext dbMafiaCompany)
        {
            this.dbMafiaCompany = dbMafiaCompany;
        }

        [HttpGet]
        public IActionResult GetMafiaCompany()
        {
            /*Подключаем ICollection*/
            var mafiaCompanies = dbMafiaCompany.MafiaCompanies.Select(z => z).Include(z => z.FinancialReports).ToList();

            return Ok(mafiaCompanies);
        }

        [HttpGet]
        [Route("{name}")]
        public IActionResult GetContributorByName([FromRoute] string name)
        {
            string nameConverted;
            while ((nameConverted = Uri.UnescapeDataString(name)) != name)
                name = nameConverted;
            var FindMember = dbMafiaCompany.MafiaCompanies.FirstOrDefault(x => x.Name == nameConverted);
            if (FindMember != null)
            {
                return RedirectToAction("GetNameById", "MafiaFamily", new {id = FindMember.MafiaFamilyId});
            }

            return NotFound();
        }

        //Store
        [HttpPost]
        public IActionResult AddMafiaCompany(MafiaCompany AddMafiaCompanyRequest)
        {

            var MafiaCompany = new MafiaCompany(AddMafiaCompanyRequest.Name,
                                               AddMafiaCompanyRequest.Address,
                                               AddMafiaCompanyRequest.ContactPhone,
                                               AddMafiaCompanyRequest.BusinessType,
                                               AddMafiaCompanyRequest.MafiaFamilyId);

            dbMafiaCompany.MafiaCompanies.Add(MafiaCompany);
            dbMafiaCompany.SaveChanges();

            return Ok(MafiaCompany);
        }

        [HttpDelete]
        [Route("{name}")]
        public IActionResult DeleteMafiaMember([FromRoute] string name)
        {
            string nameConverted;
            while ((nameConverted = Uri.UnescapeDataString(name)) != name)
                name = nameConverted;
            var FindMember = dbMafiaCompany.MafiaCompanies.FirstOrDefault(x => x.Name == nameConverted);

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
