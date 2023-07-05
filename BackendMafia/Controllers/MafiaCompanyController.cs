﻿using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Migrations;

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
    }
}
