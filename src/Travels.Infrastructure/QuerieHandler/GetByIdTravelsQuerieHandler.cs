using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Travels.Core.Domain;
using Travels.Core.Interfaces;
using Travels.Core.Queries;

namespace Travels.Infrastructure.QuerieHandler
{
    public class GetByIdTravelsQuerieHandler : IRequestHandler<GetByIdTravelsQuerie, IAsyncEnumerable<ITravel>>
    {
        private readonly ITravelRepository TravelRepository;
        public GetByIdTravelsQuerieHandler(ITravelRepository travelRepository)
        {
            TravelRepository = travelRepository;
        }
        public async Task<IAsyncEnumerable<ITravel>> Handle(GetByIdTravelsQuerie request, CancellationToken cancellationToken)
        {
            await TravelRepository.ListAllAsync(cancellationToken);
            return null;
        }
    }
}
