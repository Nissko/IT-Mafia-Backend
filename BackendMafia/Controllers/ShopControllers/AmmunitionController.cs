using Domain.Entities.ShopAggregate;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using System.Net;
using System.Text.RegularExpressions;

namespace BackendMafia.Controllers.ShopControllers
{
    [ApiController]
    [Route("[controller]")]
    public class AmmunitionController : ControllerBase
    {
        //DB Init
        private readonly MafiaApiDbContext dbAmmunition;

        public AmmunitionController(MafiaApiDbContext dbAmmunition)
        {
            this.dbAmmunition = dbAmmunition;
        }

        //Index
        [HttpGet]
        public IActionResult GetAmmunition()
        {
            return Ok(dbAmmunition.Ammunitions.ToList());
        }

        //Store
        [HttpPost]
        public IActionResult StoreAmmunition(Ammunition AddAmmunitionRequest)
        {
            var AddAmmunition = new Ammunition(WebUtility.HtmlEncode(Regex.Replace(AddAmmunitionRequest.Name, "<[^>]*(>|$)", string.Empty)).ToString(),
                                 AddAmmunitionRequest.Count,
                                 AddAmmunitionRequest.Price);

            dbAmmunition.Ammunitions.Add(AddAmmunition);
            dbAmmunition.SaveChanges();

            return Ok(AddAmmunition);
        }

        //Update
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateAmmunition([FromRoute] int id, Ammunition UpdateAmmunitionRequest)
        {
            var UpdateAmmunition = dbAmmunition.Ammunitions.Find(id);

            if (UpdateAmmunition != null)
            {
                UpdateAmmunition.Name = WebUtility.HtmlEncode(Regex.Replace(UpdateAmmunitionRequest.Name, "<[^>]*(>|$)", string.Empty)).ToString();
                UpdateAmmunition.Count = UpdateAmmunitionRequest.Count;
                UpdateAmmunition.Price = UpdateAmmunitionRequest.Price;

                dbAmmunition.SaveChanges();

                return Ok(UpdateAmmunition);
            }

            return NotFound();
        }

        //Delete
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteAmmunition([FromRoute] int id)
        {
            var FindAmmunitionn = dbAmmunition.Ammunitions.Find(id);

            if (FindAmmunitionn != null)
            {
                dbAmmunition.Remove(FindAmmunitionn);
                dbAmmunition.SaveChanges();

                return Ok("Боеприпасы были удалены");
            }

            return NotFound();
        }
    }
}
