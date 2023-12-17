using MediatR;

namespace UI.Applications.Gun.Commands.DeleteGuns
{
    public class DeleteGunsCommand : IRequest<Unit>
    {
        public DeleteGunsCommand(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
