using Domain.Entities.ShopAggregate;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.MainAggregate
{
    public class MafiaMember
    {
        public int Id { get; private set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [StringLength(100, ErrorMessage = "Неверно написано имя", MinimumLength = 2)]
        public string Name { get; private set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [StringLength(100, ErrorMessage = "Неверно написано фамилия", MinimumLength = 5)]
        public string Surname { get; private set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [StringLength(100, ErrorMessage = "Неверно написано отчество", MinimumLength = 5)]
        public string Patronymic { get; private set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [StringLength(10, ErrorMessage = "Неверно указана дата")]
        public string Birthday { get; private set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [StringLength(20, ErrorMessage = "Неверно указан номер телефона")]
        [Phone(ErrorMessage = "Некорректный номер телефона")]
        public string Phone { get; private set; }

        [Range(0, 100, ErrorMessage = "Некоррректное значение здоровья")]
        public int Health { get; set; }

        [Range(0, 100, ErrorMessage = "Некорректное значение силы")]
        public int Strength { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        public int MafiaFamilyId { get; private set; }

        public virtual ICollection<OrderShop> OrderShops { get; private set; }

        public MafiaMember(string name, string surname, string patronymic, string birthday, string phone, int mafiaFamilyId, int health, int strength)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            Birthday = birthday;
            Phone = phone;
            MafiaFamilyId = mafiaFamilyId;
            Health = health;
            Strength = strength;
            OrderShops = new HashSet<OrderShop>();
        }

    }
}
