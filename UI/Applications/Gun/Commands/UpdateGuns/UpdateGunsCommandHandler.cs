using MediatR;
using Persistence;

namespace UI.Applications.Gun.Commands.UpdateGuns
{
    public class UpdateGunsCommandHandler : IRequestHandler<UpdateGunsCommand, Unit>
    {
        private readonly MafiaApiDbContext _dbContext;

        public UpdateGunsCommandHandler(MafiaApiDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<Unit> Handle(UpdateGunsCommand request, CancellationToken cancellationToken)
        {
            await UpdateCurrentGun(request.Id, 
                                request.Name, 
                                request.Count, 
                                request.Type, 
                                request.SupportAmmo, 
                                request.Price);
            return Unit.Value;
        }

        public async Task UpdateCurrentGun(int id, 
                                        string name, 
                                        int count, 
                                        string type, 
                                        string supportAmmo, 
                                        decimal price)
        {
            var UpdateGun = _dbContext.Guns.FindAsync(id);

            if (await UpdateGun == null)
            {
                throw new ArgumentNullException(nameof(UpdateGun));
            }

            UpdateGun.Result.Name = name;
            UpdateGun.Result.Count = count;
            UpdateGun.Result.Type = type;
            UpdateGun.Result.SupportAmmo = supportAmmo;
            UpdateGun.Result.Price = price;

            _dbContext.SaveChanges();
        }
    }
}
