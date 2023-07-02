namespace BackendMafia.Models
{
    public class MafiaCompany
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string ContactPhone { get; set; }

        public string BusinessType { get; set; }

        public int MafiaFamiliesId { get; set; }

        public int MafiaMembersId { get; set; }

    }
}
