using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Travels.Core.Entities;
using Travels.Core.Interfaces;
using Travels.Core.Queries;
using Travels.Infrastructure.DTO;
using Travels.Infrastructure.Extensions;

namespace Travels.Infrastructure.QuerieHandler
{
    public class GetByIdTravelsQuerieHandler : IRequestHandler<GetByIdTravelsQuerie, TravelDTO>
    {
        private readonly ITravelRepository _travelRepository;
        private readonly IMapper _mapper;
        public GetByIdTravelsQuerieHandler(ITravelRepository travelRepository,
            IMapper mapper)
        {
            _travelRepository = travelRepository;
            _mapper = mapper;
        }
        public async Task<TravelDTO> Handle(GetByIdTravelsQuerie request, CancellationToken cancellationToken)
        {
            return _mapper.Map<TravelDTO>(await _travelRepository.FirstAsync(QuerySpecificationExtensions.Criteria<Travel>(x => x.Id == request.Id), cancellationToken));
        }
    }
}
