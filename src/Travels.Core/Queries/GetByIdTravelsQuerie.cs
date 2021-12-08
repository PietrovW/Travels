using MediatR;
using Travels.Infrastructure.DTO;

namespace Travels.Core.Queries
{
    public class GetByIdTravelsQuerie : IRequest<TravelDTO>
    {
        public long Id { get; set; }
    }
}
