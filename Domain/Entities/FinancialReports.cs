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

        public int Revenue { get; private set; }

        public int Expense { get; private set; }

        public int NetIncome { get; private set; }

        public int FamilyDonate { get; private set; }

        public int CompaniesId { get; private set; }
    }
}
