using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using System.Net;
using System.Text.RegularExpressions;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FinancialReportsController : ControllerBase
    {
        //DB Init
        private readonly MafiaApiDbContext dbFinancialReports;

        public FinancialReportsController(MafiaApiDbContext dbFinancialReports)
        {
            this.dbFinancialReports = dbFinancialReports;
        }

        //Вывод всех финансовых отчетов
        [HttpGet]
        public IActionResult GetFinancialReports()
        {
            return Ok(dbFinancialReports.FinancialReports.ToList());
        }

        //Добавление финансового отчета
        [HttpPost]
        public IActionResult AddFinancialReports(FinancialReports AddFinancialReportsRequest)
        {

            var FinancialReportsAdd = new FinancialReports(WebUtility.HtmlEncode(Regex.Replace(AddFinancialReportsRequest.Date, "<[^>]*(>|$)", string.Empty)).ToString(),
                                                           AddFinancialReportsRequest.Revenue,
                                                           AddFinancialReportsRequest.Expense,
                                                           AddFinancialReportsRequest.NetIncome,
                                                           AddFinancialReportsRequest.FamilyDonate,
                                                           AddFinancialReportsRequest.MafiaCompanyId);

            dbFinancialReports.FinancialReports.Add(FinancialReportsAdd);
            dbFinancialReports.SaveChanges();

            return Ok(FinancialReportsAdd);
        }

        //Удаление финансового отчета
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteFinancialReport([FromRoute] int id)
        {
            var FindFinancialReport = dbFinancialReports.FinancialReports.Find(id);

            if (FindFinancialReport != null)
            {
                dbFinancialReports.Remove(FindFinancialReport);
                dbFinancialReports.SaveChanges();
                return Ok("Отчет был удален");
            }

            return NotFound();
        }
    }
}
