using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Travels.Core.Domain;
using Travels.Core.Interfaces;
using Travels.Core.Queries;


namespace Travels.Infrastructure.QuerieHandler
{
    public class GetAllTravelsQuerieHandler : IRequestHandler<GetAllTravelsQuerie, IList<ITravel>>
    {
        private readonly ITravelRepository TravelRepository;
        public GetAllTravelsQuerieHandler(ITravelRepository travelRepository)
        {
            TravelRepository = travelRepository;
        }
        public async Task<IList<ITravel>> Handle(GetAllTravelsQuerie request, CancellationToken cancellationToken)
        {
            await TravelRepository.ListAllAsync(cancellationToken);
            return null;
        }
    }
}
