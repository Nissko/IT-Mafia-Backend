using BackendMafia.Data;
using BackendMafia.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackendMafia.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FinancialReportsController : Controller
    {
        private readonly MafiaAPIDb dbFinancialReports;

        //Show All
        public FinancialReportsController(MafiaAPIDb dbFinancialReports)
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
            var FinancialReports = new FinancialReports()
            {
                Date = AddFinancialReportsRequest.Date,
                Revenue = AddFinancialReportsRequest.Revenue,
                Expense = AddFinancialReportsRequest.Expense,
                NetIncome = AddFinancialReportsRequest.NetIncome,
                FamilyDonate = AddFinancialReportsRequest.FamilyDonate,
                CompaniesId = AddFinancialReportsRequest.CompaniesId,
            };

            dbFinancialReports.FinancialReports.Add(FinancialReports);
            dbFinancialReports.SaveChanges();

            return Ok(FinancialReports);
        }
    }
}
