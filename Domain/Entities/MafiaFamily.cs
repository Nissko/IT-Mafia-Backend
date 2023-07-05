using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MafiaFamily
    {
        public int Id { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public virtual ICollection<MafiaMember> MafiaMembers { get; private set; }

        public virtual ICollection<MafiaCompany> MafiaCompanies { get; private set; }

        public MafiaFamily(string name, string description)
        {
            Name = name;
            Description = description;
            MafiaMembers = new HashSet<MafiaMember>();
            MafiaCompanies = new HashSet<MafiaCompany>();
        }
    }
}
