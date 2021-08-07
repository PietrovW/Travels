﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Travels.Core.Domain;
using Travels.Core.Entities;
using Travels.Core.Specifications;
using Travels.Infrastructure.Queries;
using Travels.Infrastructure.Repositories;

namespace Travels.Infrastructure.QuerieHandler
{
    public class GetAllTravelsQuerieHandler : IRequestHandler<GetAllTravelsQuerie, IList<ITravel>>
    {
        private readonly EfRepository<Travel> TravelRepository;
        public GetAllTravelsQuerieHandler(EfRepository<Travel> travelRepository)
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
