using MediatR;
using Domain.Entities.ShopAggregate;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace BackendMafia.Applications.Gun.Queries
{
    public class GetGunsQuery : IRequest<IEnumerable<Domain.Entities.ShopAggregate.Gun>> { }
}
