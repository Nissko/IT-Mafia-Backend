using MediatR;

namespace BackendMafia.Applications.Gun.Queries
{
    public class GetGunsQuery : IRequest<IEnumerable<Domain.Entities.ShopAggregate.Gun>> { }
}
