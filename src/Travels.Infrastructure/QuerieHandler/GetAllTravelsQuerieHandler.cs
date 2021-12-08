using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Travels.Core.Domain;
using Travels.Core.Entities;
using Travels.Core.Interfaces;
using Travels.Core.Queries;
using Travels.Infrastructure.DTO;

namespace Travels.Infrastructure.QuerieHandler
{
    public class GetAllTravelsQuerieHandler : IRequestHandler<GetAllTravelsQuerie, IEnumerable<TravelDTO>>
    {
        private readonly ITravelRepository _travelRepository;
        private readonly IMapper _mapper;
        public GetAllTravelsQuerieHandler(ITravelRepository travelRepository,
            IMapper mapper)
        {
            _travelRepository = travelRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<TravelDTO>> Handle(GetAllTravelsQuerie request, CancellationToken cancellationToken)
        {
            IEnumerable<Travel> travels=await _travelRepository.ListAllAsync(cancellationToken);
            return _mapper.Map<IEnumerable<TravelDTO>>(travels);
        }
    }
}
