
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
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
            return Ok(dbMafiaFamily.MafiaFamilies.ToList());
        }

        //Store
        [HttpPost]
        public IActionResult AddMafiaFamily(MafiaFamily AddMafiaFamilyRequest)
        {
            /*var MafiaFamily = new MafiaFamily()
            {
                Name = AddMafiaFamilyRequest.Name,
                Description = AddMafiaFamilyRequest.Description,
            };*/

            var MafiaFamily = new MafiaFamily(AddMafiaFamilyRequest.Name,
                                               AddMafiaFamilyRequest.Description);

            dbMafiaFamily.MafiaFamilies.Add(MafiaFamily);
            dbMafiaFamily.SaveChanges();

            return Ok(MafiaFamily);
        }
    }
}
