using AutoMapper;
using Travels.Application.Interfaces;
using Travels.Domain.Extensions;
using Travels.Infrastructure.DTO;

namespace Travels.Domain.Travel.V1.Queries;

public class GetByIdTravelsQuerieHandler
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
        return _mapper.Map<TravelDTO>(await _travelRepository.FirstAsync(QuerySpecificationExtensions.Criteria<Travels.Application.Entities.Travel>(x => x.Id == request.Id), cancellationToken));
    }
}
