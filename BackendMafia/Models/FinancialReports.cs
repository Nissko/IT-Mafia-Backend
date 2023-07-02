namespace BackendMafia.Models
{
    public class FinancialReports
    {
        public int Id { get; set; }

        public string Date { get; set; }

        public int Revenue { get; set; }

        public int Expense { get; set; }

        public int NetIncome { get; set; }

        public int FamilyDonate { get; set; }

        public int CompaniesId { get; set; }
    }
}
