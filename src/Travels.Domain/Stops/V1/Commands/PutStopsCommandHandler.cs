using AutoMapper;
using Travels.Application.Entities;
using Travels.Application.Interfaces;
using Travels.Infrastructure.DTO;

namespace Travels.Domin.V1.Command;

public class PutStopsCommandHandler
{
    private readonly ITravelRepository TravelRepository;
    private readonly IMapper _mapper;

    public PutStopsCommandHandler(ITravelRepository travelRepository,
        IMapper mapper)
    {
        TravelRepository = travelRepository;
        _mapper = mapper;
    }
    public async Task<StopsDTO> Handle(PutStopsCommand request, CancellationToken cancellationToken)
    {
        var trave = new Travel(created: request.Created, name: request.Name, description: request.Description);
        await TravelRepository.UpdateAsync(trave, cancellationToken);
        return _mapper.Map<StopsDTO>(trave);
    }
}

