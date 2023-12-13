using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Applications.Gun.Commands.StoreGuns
{
    public class StoreGunsCommand : IRequest<Unit>
    {
        public StoreGunsCommand(string name, int count, string type, string supportAmmo, decimal price)
        {
            Name = name;
            Count = count;
            Type = type;
            SupportAmmo = supportAmmo;
            Price = price;
        }

        public string Name { get; private set; }
        public int Count { get; private set; }
        public string Type { get; private set; }
        public string SupportAmmo { get; private set; }
        public decimal Price { get; private set; }
    }
}
