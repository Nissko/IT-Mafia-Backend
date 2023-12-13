using Domain.Entities.ShopAggregate;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendMafia.Applications.Gun.Queries
{
    public class GetGunsQueryHandler : IRequestHandler<GetGunsQuery, IEnumerable<Domain.Entities.ShopAggregate.Gun>>
    {
        private readonly MafiaApiDbContext _dbContext;

        public GetGunsQueryHandler(MafiaApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Domain.Entities.ShopAggregate.Gun>> Handle(GetGunsQuery request, CancellationToken cancellationToken)
        {
            var guns = await _dbContext.Guns.ToListAsync();
            return guns;
        }
    }
}
