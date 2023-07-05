﻿using System;
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

        public int MafiaCompanyId { get; private set; }

        public FinancialReports(string date, string revenue, string expense, string netIncome, string familyDonate, int mafiaCompanyId)
        {
            Date = date;
            Revenue = revenue;
            Expense = expense;
            NetIncome = netIncome;
            FamilyDonate = familyDonate;
            MafiaCompanyId = mafiaCompanyId;
        }
    }
}
