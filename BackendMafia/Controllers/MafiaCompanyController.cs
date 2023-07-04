using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Persistence;

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
            return Ok(dbMafiaCompany.MafiaCompanies.ToList());
        }

        //Store
        [HttpPost]
        public IActionResult AddMafiaCompany(MafiaCompany AddMafiaCompanyRequest)
        {

            var MafiaCompany = new MafiaCompany(AddMafiaCompanyRequest.Name,
                                               AddMafiaCompanyRequest.Address,
                                               AddMafiaCompanyRequest.ContactPhone,
                                               AddMafiaCompanyRequest.BusinessType,
                                               AddMafiaCompanyRequest.MafiaFamiliesId,
                                               AddMafiaCompanyRequest.MafiaMembersId);

            dbMafiaCompany.MafiaCompanies.Add(MafiaCompany);
            dbMafiaCompany.SaveChanges();

            return Ok(MafiaCompany);
        }
    }
}
