using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace BackendMafia.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FinancialReportsController : Controller
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

            var FinancialReportsAdd = new FinancialReports()
            {
                Date = AddFinancialReportsRequest.Date,
                Revenue = AddFinancialReportsRequest.Revenue,
                Expense = AddFinancialReportsRequest.Expense,
                NetIncome = AddFinancialReportsRequest.NetIncome,
                FamilyDonate = AddFinancialReportsRequest.FamilyDonate,
                CompaniesId = AddFinancialReportsRequest.CompaniesId,
            };

            dbFinancialReports.FinancialReports.Add(FinancialReportsAdd);
            dbFinancialReports.SaveChanges();

            return Ok(FinancialReportsAdd);
        }
    }
}
