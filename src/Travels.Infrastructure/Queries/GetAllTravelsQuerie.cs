using MediatR;
using System.Collections.Generic;
using Travels.Core.Domain;

namespace Travels.Infrastructure.Queries
{
    public class GetAllTravelsQuerie : IRequest<IList<ITravel>>
    {
    }
}
