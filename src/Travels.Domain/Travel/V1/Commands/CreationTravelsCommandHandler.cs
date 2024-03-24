using AutoMapper;
using Travels.Application.Interfaces;
using Travels.Infrastructure.DTO;

namespace Travels.Domain.Travel.V1.Commands;

public class CreationTravelsCommandHandler
{
    private readonly ITravelRepository TravelRepository;
    private readonly IMapper _mapper;

    public CreationTravelsCommandHandler(ITravelRepository travelRepository,
        IMapper mapper)
    {
        TravelRepository = travelRepository;
        _mapper = mapper;
    }
    public async Task<TravelDTO> Handle(CreationTravelsCommand request, CancellationToken cancellationToken)
    {
        var trave = new Travels.Application.Entities.Travel(created: request.Created, name: request.Name, description: request.Description);
        await TravelRepository.AddAsync(trave, cancellationToken);
        return _mapper.Map<TravelDTO>(trave);
    }
}
