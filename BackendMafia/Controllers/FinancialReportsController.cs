using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FinancialReportsController : ControllerBase
    {
        private readonly MafiaApiDbContext dbFinancialReports;

        //Show All
        public FinancialReportsController(MafiaApiDbContext dbFinancialReports)
        {
            this.dbFinancialReports = dbFinancialReports;
        }

        [HttpGet]
        public IActionResult GetFinancialReports()
        {
            return Ok(dbFinancialReports.FinancialReports.ToList());
        }

        //Store
        [HttpPost]
        public IActionResult AddFinancialReports(FinancialReports AddFinancialReportsRequest)
        {

            var FinancialReportsAdd = new FinancialReports(AddFinancialReportsRequest.Date,
                                                           AddFinancialReportsRequest.Revenue,
                                                           AddFinancialReportsRequest.Expense,
                                                           AddFinancialReportsRequest.NetIncome,
                                                           AddFinancialReportsRequest.FamilyDonate,
                                                           AddFinancialReportsRequest.CompaniesId);

            dbFinancialReports.FinancialReports.Add(FinancialReportsAdd);
            dbFinancialReports.SaveChanges();

            return Ok(FinancialReportsAdd);
        }
    }
}
