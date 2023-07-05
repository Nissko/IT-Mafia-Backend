using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MafiaCompany
    {
        public int Id { get; private set; }

        public string Name { get; private set; }

        public string Address { get; private set; }

        public string ContactPhone { get; private set; }

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
    }
}
