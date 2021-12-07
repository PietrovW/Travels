using MediatR;
using System.Collections.Generic;
using Travels.Core.Domain;

namespace Travels.Core.Queries
{
    public class GetAllTravelsQuerie : IRequest<IAsyncEnumerable<ITravel>>
    {
    }
}
