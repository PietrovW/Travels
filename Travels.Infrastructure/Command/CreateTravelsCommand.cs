
using MediatR;
using Travels.Core.Domain;
using Travels.Core.Entities;

namespace Travels.Infrastructure.Command
{
    public interface CreateTravelsCommand : ITravel,IRequest<Travel>
    {
    }
}
