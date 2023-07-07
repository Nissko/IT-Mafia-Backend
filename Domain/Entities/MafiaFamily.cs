﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MafiaFamily
    {
        public int Id { get; private set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [StringLength(100, ErrorMessage = "Неверно написано имя", MinimumLength = 5)]
        public string Name { get; private set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [StringLength(500, ErrorMessage = "Неверно написано описание", MinimumLength = 10)]
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
