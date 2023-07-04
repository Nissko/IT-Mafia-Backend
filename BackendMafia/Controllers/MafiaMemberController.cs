using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MafiaMemberController : ControllerBase
    {
        private readonly MafiaApiDbContext dbMafiaMember;

        //Show All
        public MafiaMemberController(MafiaApiDbContext dbMafiaMember)
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

            var MafiaMember = new MafiaMember(AddMafiaMemberRequuest.Name,
                                               AddMafiaMemberRequuest.Surname,
                                               AddMafiaMemberRequuest.Patronymic,
                                               AddMafiaMemberRequuest.Birthday,
                                               AddMafiaMemberRequuest.Phone,
                                               AddMafiaMemberRequuest.Login,
                                               AddMafiaMemberRequuest.Password,
                                               AddMafiaMemberRequuest.MafiaFamiliesId);

            dbMafiaMember.MafiaMembers.Add(MafiaMember);
            dbMafiaMember.SaveChanges();

            return Ok(MafiaMember);
        }
    }
}
