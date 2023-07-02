namespace BackendMafia.Models
{
    public class MafiaMember
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Patronymic { get; set; }

        public string Birthday { get; set; }

        public int Phone { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public int MafiaFamiliesId { get; set; }

        public List<MafiaCompany> MafiaCompanies { get; set; }
    }
}
