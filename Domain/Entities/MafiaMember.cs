using System.Collections.ObjectModel;

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

        public int MafiaFamilyId { get; private set; }

        public MafiaMember(string name, string surname, string patronymic, string birthday, string phone, int mafiaFamilyId)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            Birthday = birthday;
            Phone = phone;
            MafiaFamilyId = mafiaFamilyId;
        }
    }
}