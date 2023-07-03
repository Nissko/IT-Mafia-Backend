using BackendMafia.Data;
using BackendMafia.Models;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace BackendMafia.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MafiaMemberController : Controller
    {
        private readonly MafiaAPIDb dbMafiaMember;

        //Show All
        public MafiaMemberController(MafiaAPIDb dbMafiaMember)
        {
            this.dbMafiaMember = dbMafiaMember;
        }

        [HttpGet]
        public IActionResult GetMafiaMember()
        {
            return Ok(dbMafiaMember.MafiaMembers.ToList());
        }

        [HttpPost]
        public IActionResult AddMafiaMember(MafiaMember AddMafiaMemberRequuest)
        {
            var MafiaMember = new MafiaMember()
            {
                Name = AddMafiaMemberRequuest.Name,
                Surname = AddMafiaMemberRequuest.Surname,
                Patronymic = AddMafiaMemberRequuest.Patronymic,
                Birthday = AddMafiaMemberRequuest.Birthday,
                Phone = AddMafiaMemberRequuest.Phone,
                Login = AddMafiaMemberRequuest.Login,
                Password = AddMafiaMemberRequuest.Password,
                MafiaFamiliesId = AddMafiaMemberRequuest.MafiaFamiliesId
            };

            dbMafiaMember.MafiaMembers.Add(MafiaMember);
            dbMafiaMember.SaveChanges();

            return Ok(MafiaMember);
        }
    }
}
