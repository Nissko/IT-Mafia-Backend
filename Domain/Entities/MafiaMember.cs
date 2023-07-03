namespace Domain.Entities
{
    public class MafiaMember
    {
        public int Id { get; private set; }

        public string Name { get; private set; }

        public string Surname { get; private set; }

        public string Patronymic { get; private set; }

        public DateTime Birthday { get; private set; }

        public int Phone { get; private set; }

        public string Login { get; private set; }

        public string Password { get; private set; }

        public int MafiaFamiliesId { get; private set; }
    }
}