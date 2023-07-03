using System;
using System.Collections.Generic;
using System.Linq;
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

        public int MafiaFamiliesId { get; private set; }

        public int MafiaMembersId { get; private set; }

    }
}
