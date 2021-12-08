
using MediatR;
using Travels.Core.Domain;
using Travels.Infrastructure.DTO;

namespace Travels.Infrastructure.Command
{
    public interface PostStopsCommand : ITravel,IRequest<StopsDTO>
    {
    }
}
