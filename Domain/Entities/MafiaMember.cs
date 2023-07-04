namespace Domain.Entities
{
    public class MafiaMember
    {
        public int Id { get; private set; }

        public string Name { get; private set; }

        public string Surname { get; private set; }

        public string Patronymic { get; private set; }

        public string Birthday { get; private set; }

        public string Phone { get; private set; }

        public string Login { get; private set; }

        public string Password { get; private set; }

        public int MafiaFamiliesId { get; private set; }
    
        public virtual ICollection<MafiaCompany> MafiaCompanies { get; private set; }

        public MafiaMember(string name, string surname, string patronymic, string birthday, string phone, string login, string password, int mafiaFamiliesId)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            Birthday = birthday;
            Phone = phone;
            Login = login;
            Password = password;
            MafiaFamiliesId = mafiaFamiliesId;
        }
    }
}