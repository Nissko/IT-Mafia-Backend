using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MafiaCompany
    {
        public int Id { get; private set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [StringLength(100, ErrorMessage = "Неверно написано название компании", MinimumLength = 10)]
        public string Name { get; private set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [StringLength(150, ErrorMessage = "Неверно написан адрес", MinimumLength = 10)]
        public string Address { get; private set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [StringLength(20, ErrorMessage = "Неверно указан номер телефона")]
        [Phone(ErrorMessage = "Некорректный номер телефоа")]
        public string ContactPhone { get; private set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [StringLength(100, ErrorMessage = "Неверно написан тип бизнеса", MinimumLength = 10)]
        public string BusinessType { get; private set; }

        public int MafiaFamilyId { get; private set; }

        public virtual ICollection<FinancialReports> FinancialReports { get; private set; }

        public MafiaCompany(string name, string address, string contactPhone, string businessType, int mafiaFamilyId)
        {
            Name = name;
            Address = address;
            ContactPhone = contactPhone;
            BusinessType = businessType;
            MafiaFamilyId = mafiaFamilyId;
            FinancialReports = new HashSet<FinancialReports>();
        }

        public void Update(string name, string address, string contactPhone, string businessType, int mafiaFamilyId)
        {
            Name = name;
            Address = address;
            ContactPhone = contactPhone;
            BusinessType = businessType;
            MafiaFamilyId = mafiaFamilyId;
            FinancialReports = new HashSet<FinancialReports>();
        }
    }
}
