using MediatR;
using System.Collections.Generic;
using Travels.Core.Domain;

namespace Travels.Core.Queries
{
    public class GetByIdTravelsQuerie : IRequest<IList<ITravel>>
    {
        public long Id { get; set; }
    }
}
