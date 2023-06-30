using BackendMafia.Data;
using BackendMafia.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace BackendMafia.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MafiaFamilyController : Controller
    {
        private readonly MafiaAPIDb dbMafiaFamily;

        public MafiaFamilyController(MafiaAPIDb dbMafiaFamily) 
        {
            this.dbMafiaFamily = dbMafiaFamily;
        }

        [HttpGet]
        public IActionResult GetMafiaFamily()
        {
            return Ok(dbMafiaFamily.MafiaFamilies.ToList());
        }

        [HttpPost]
        public IActionResult AddMafiaFamily(AddMafiaFamilyRequest AddMafiaFamilyRequest)
        {
            var MafiaFamily = new MafiaFamily()
            {
                Id = Guid.NewGuid(),
                Name = AddMafiaFamilyRequest.Name,
                CollectionFamily = AddMafiaFamilyRequest.CollectionFamily,
                OrganisationCollection = AddMafiaFamilyRequest.OrganisationCollection
            };

            dbMafiaFamily.MafiaFamilies.Add(MafiaFamily);
            dbMafiaFamily.SaveChanges();

            return Ok(MafiaFamily);
        }
    }
}
