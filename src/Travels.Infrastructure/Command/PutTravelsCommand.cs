
using MediatR;
using Travels.Core.Domain;
using Travels.Core.Entities;

namespace Travels.Infrastructure.Command
{
    public interface PutTravelsCommand : ITravel,IRequest<Travel>
    {
    }
}
