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

        [Required(ErrorMessage = "Обязательное поле")]
        [StringLength(10, ErrorMessage = "Неверно указана дата")]
        public string Date { get; private set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Range(1, 1000000, ErrorMessage = "Неверно указан доход")]
        public decimal Revenue { get; private set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Range(1, 1000000, ErrorMessage = "Неверно указаны расходы")]
        public decimal Expense { get; private set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Range(1, 1000000, ErrorMessage = "Неверно указан чистый доход")]
        public decimal NetIncome { get; private set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Range(1, 1000000, ErrorMessage = "Неверно указано семейное пожертвование")]
        public decimal FamilyDonate { get; private set; }

        [Required(ErrorMessage = "Обязательное поле")]
        public int MafiaCompanyId { get; private set; }

        public FinancialReports(string date, decimal revenue, decimal expense, decimal netIncome, decimal familyDonate, int mafiaCompanyId)
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
