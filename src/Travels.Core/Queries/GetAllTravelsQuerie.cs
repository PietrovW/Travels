using MediatR;
using System.Collections.Generic;
using Travels.Core.Domain;
using Travels.Infrastructure.DTO;

namespace Travels.Core.Queries
{
    public class GetAllTravelsQuerie : IRequest<IEnumerable<TravelDTO>>
    {
    }
}
