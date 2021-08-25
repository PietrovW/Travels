using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Travels.Core.Domain;
using Travels.Core.Interfaces;
using Travels.Infrastructure.Queries;

namespace Travels.Infrastructure.QuerieHandler
{
    public class GetByIdTravelsQuerieHandler : IRequestHandler<GetByIdTravelsQuerie, IList<ITravel>>
    {
        private readonly ITravelRepository TravelRepository;
        public GetByIdTravelsQuerieHandler(ITravelRepository travelRepository)
        {
            TravelRepository = travelRepository;
        }
        public async Task<IList<ITravel>> Handle(GetByIdTravelsQuerie request, CancellationToken cancellationToken)
        {
            await TravelRepository.ListAllAsync(cancellationToken);
            return null;
        }
    }
}
