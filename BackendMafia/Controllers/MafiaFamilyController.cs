using BackendMafia.Data;
using BackendMafia.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace BackendMafia.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MafiaFamilyController : Controller
    {
        private readonly MafiaAPIDb dbMafiaFamily;

        //Show All
        public MafiaFamilyController(MafiaAPIDb dbMafiaFamily) 
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
            var MafiaFamily = new MafiaFamily()
            {
                Name = AddMafiaFamilyRequest.Name,
                Description = AddMafiaFamilyRequest.Description,
            };

            dbMafiaFamily.MafiaFamilies.Add(MafiaFamily);
            dbMafiaFamily.SaveChanges();

            return Ok(MafiaFamily);
        }
    }
}
