using Domain.Entities.ShopAggregate;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace UI.Applications.Gun.Commands.StoreGuns
{
    public class StoreGunsCommandHandler : IRequestHandler<StoreGunsCommand, Unit>
    {
        private readonly MafiaApiDbContext _dbContext;

        public StoreGunsCommandHandler(MafiaApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(StoreGunsCommand request, CancellationToken cancellationToken)
        {
            await AddNewGun(request.Name, request.Count, request.Type, request.SupportAmmo, request.Price);
            return Unit.Value;
        }

        public async Task AddNewGun(string name, int count, string type, string supportAmmo, decimal price)
        {
            Domain.Entities.ShopAggregate.Gun newGun = new(name, count, type, supportAmmo, price)
            {
                Name = name,
                Type = type,
                SupportAmmo = supportAmmo,
                Price = price
            };

            _dbContext.Guns.Add(newGun);
            _dbContext.SaveChanges();
        }
    }

    
}
