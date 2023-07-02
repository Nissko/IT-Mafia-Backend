using System.Collections.ObjectModel;

namespace BackendMafia.Models
{
    public class MafiaFamily
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<MafiaMember> MafiaMembers { get; set; }

        public List<MafiaCompany> MafiaCompanies { get; set; }
    }
}
