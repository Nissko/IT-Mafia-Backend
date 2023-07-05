
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MafiaFamilyController : ControllerBase
    {
        private readonly MafiaApiDbContext dbMafiaFamily;

        //Show All
        public MafiaFamilyController(MafiaApiDbContext dbMafiaFamily) 
        {
            this.dbMafiaFamily = dbMafiaFamily;
        }

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

        //Store
        [HttpPost]
        public IActionResult AddMafiaFamily(MafiaFamily AddMafiaFamilyRequest)
        {
            var MafiaFamily = new MafiaFamily(AddMafiaFamilyRequest.Name,
                                               AddMafiaFamilyRequest.Description);

            dbMafiaFamily.MafiaFamilies.Add(MafiaFamily);
            dbMafiaFamily.SaveChanges();

            return Ok(MafiaFamily);
        }

        //Destroy
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
