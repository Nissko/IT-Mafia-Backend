using BackendMafia.Data;
using BackendMafia.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackendMafia.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MafiaCompanyController : Controller
    {
        private readonly MafiaAPIDb dbMafiaCompany;

        //Show All
        public MafiaCompanyController(MafiaAPIDb dbMafiaCompany)
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
            var MafiaCompany = new MafiaCompany()
            {
                Name = AddMafiaCompanyRequest.Name,
                Address = AddMafiaCompanyRequest.Address,
                ContactPhone = AddMafiaCompanyRequest.ContactPhone,
                BusinessType = AddMafiaCompanyRequest.BusinessType,
                MafiaFamiliesId = AddMafiaCompanyRequest.MafiaFamiliesId,
                MafiaMembersId = AddMafiaCompanyRequest.MafiaMembersId,
            };

            dbMafiaCompany.MafiaCompanies.Add(MafiaCompany);
            dbMafiaCompany.SaveChanges();

            return Ok(MafiaCompany);
        }
    }
}
