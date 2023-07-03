using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class FinancialReports
    {
        public int Id { get; private set; }

        public string Date { get; private set; }

        public string Revenue { get; private set; }

        public string Expense { get; private set; }

        public string NetIncome { get; private set; }

        public string FamilyDonate { get; private set; }

        public int CompaniesId { get; private set; }
    }

    var FinancialReportsAdd = new FinancialReports()
    {
        Date = AddFinancialReportsRequest.Date,
        Revenue = AddFinancialReportsRequest.Revenue,
        Expense = AddFinancialReportsRequest.Expense,
        NetIncome = AddFinancialReportsRequest.NetIncome,
        FamilyDonate = AddFinancialReportsRequest.FamilyDonate,
        CompaniesId = AddFinancialReportsRequest.CompaniesId,
    };
}
