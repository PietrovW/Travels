using AutoMapper;
using Travels.Application.Interfaces;
using Travels.Infrastructure.DTO;

namespace Travels.Domain.Travel.V1.Queries;

public sealed class GetAllTravelsQuerieHandler
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
        IEnumerable<Travels.Application.Entities.Travel> travels=await _travelRepository.ListAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<TravelDTO>>(travels);
    }
}
