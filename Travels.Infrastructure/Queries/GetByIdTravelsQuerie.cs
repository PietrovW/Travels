using MediatR;
using System.Collections.Generic;
using Travels.Core.Domain;

namespace Travels.Infrastructure.Queries
{
    public class GetByIdTravelsQuerie : IRequest<IList<ITravel>>
    {
        public long Id { get; set; }
    }
}
