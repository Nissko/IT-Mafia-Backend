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

        //Store
        [HttpPost]
        public IActionResult AddMafiaMember(MafiaMember AddMafiaMemberRequuest)
        {

            var MafiaMember = new MafiaMember(AddMafiaMemberRequuest.Name,
                                               AddMafiaMemberRequuest.Surname,
                                               AddMafiaMemberRequuest.Patronymic,
                                               AddMafiaMemberRequuest.Birthday,
                                               AddMafiaMemberRequuest.Phone,
                                               AddMafiaMemberRequuest.MafiaFamilyId);

            dbMafiaMember.MafiaMembers.Add(MafiaMember);
            dbMafiaMember.SaveChanges();

            return Ok(MafiaMember);
        }

        //Delete
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteMafiaMember([FromRoute] int id)
        {
            var FindMember = dbMafiaMember.MafiaMembers.Find(id);

            if (FindMember != null)
            {
                dbMafiaMember.Remove(FindMember);
                dbMafiaMember.SaveChanges();
                return Ok("Член семьи был изгнан");
            }

            return NotFound();
        }
    }
}
