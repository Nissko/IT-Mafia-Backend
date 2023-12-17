using MediatR;
using Persistence;

namespace UI.Applications.Gun.Commands.DeleteGuns
{
    public class DeleteGunsCommandHandler : IRequestHandler<DeleteGunsCommand, Unit>
    {
        private readonly MafiaApiDbContext _dbContext;

        public DeleteGunsCommandHandler(MafiaApiDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<Unit> Handle(DeleteGunsCommand request, CancellationToken cancellationToken)
        {
            await DeleteGun(request.Id);
            return Unit.Value;
        }

        public async Task DeleteGun(int id)
        {
            var DeleteGun = _dbContext.Guns.Find(id);

            if (DeleteGun == null)
            {
                throw new ArgumentNullException(nameof(DeleteGun));
            }

            _dbContext.Remove(DeleteGun);
            _dbContext.SaveChanges();
        }
    }
}
