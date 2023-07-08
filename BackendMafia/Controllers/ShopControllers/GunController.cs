using Domain.Entities;
using Domain.Entities.ShopAggregate;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using Persistence.Migrations;
using System.Net;
using System.Text.RegularExpressions;

namespace BackendMafia.Controllers.ShopControllers
{
    [ApiController]
    [Route("[controller]")]
    public class GunController : ControllerBase
    {
        //DB Init
        private readonly MafiaApiDbContext dbGun;

        public GunController(MafiaApiDbContext dbGun)
        {
            this.dbGun = dbGun;
        }

        //Index
        [HttpGet]
        public IActionResult GetGuns()
        {
            return Ok(dbGun.Guns.ToList());
        }

        //Store
        [HttpPost]
        public IActionResult StoreGuns(Gun AddGunRequest)
        {
            var AddGun = new Gun(WebUtility.HtmlEncode(Regex.Replace(AddGunRequest.Name, "<[^>]*(>|$)", string.Empty)).ToString(),
                                 AddGunRequest.Count,
                                 WebUtility.HtmlEncode(Regex.Replace(AddGunRequest.Type, "<[^>]*(>|$)", string.Empty)).ToString(),
                                 WebUtility.HtmlEncode(Regex.Replace(AddGunRequest.SupportAmmo, "<[^>]*(>|$)", string.Empty)).ToString(),
                                 AddGunRequest.Price);

            dbGun.Guns.Add(AddGun);
            dbGun.SaveChanges();

            return Ok(AddGun);
        }

        //Update
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateGuns([FromRoute] int id, Gun UpdateGunRequest)
        {
            var UpdateGun = dbGun.Guns.Find(id);

            if (UpdateGun != null)
            {
                UpdateGun.Name = WebUtility.HtmlEncode(Regex.Replace(UpdateGunRequest.Name, "<[^>]*(>|$)", string.Empty)).ToString();
                UpdateGun.Count = UpdateGunRequest.Count;
                UpdateGun.Type = WebUtility.HtmlEncode(Regex.Replace(UpdateGunRequest.Type, "<[^>]*(>|$)", string.Empty)).ToString();
                UpdateGun.SupportAmmo = WebUtility.HtmlEncode(Regex.Replace(UpdateGunRequest.SupportAmmo, "<[^>]*(>|$)", string.Empty)).ToString();
                UpdateGun.Price = UpdateGunRequest.Price;

                dbGun.SaveChanges();

                return Ok(UpdateGun);
            }

            return NotFound();
        }

        //Delete
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteGuns([FromRoute] int id)
        {
            var FindGun = dbGun.Guns.Find(id);

            if (FindGun != null)
            {
                dbGun.Remove(FindGun);
                dbGun.SaveChanges();

                return Ok("Оружие было удалено");
            }

            return NotFound();
        }
    }
}
