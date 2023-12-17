using MediatR;

namespace UI.Applications.Gun.Commands.UpdateGuns
{
    public class UpdateGunsCommand : IRequest<Unit>
    {
        public UpdateGunsCommand(int id, string name, int count, string type, string supportAmmo, decimal price)
        {
            Id = id;
            Name = name;
            Count = count;
            Type = type;
            SupportAmmo = supportAmmo;
            Price = price;
        }

        public int Id { get; }
        public string Name { get; private set; }
        public int Count { get; private set; }
        public string Type { get; private set; }
        public string SupportAmmo { get; private set; }
        public decimal Price { get; private set; }
    }
}
