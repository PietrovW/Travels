using AutoMapper;
using Travels.Application.Interfaces;

namespace Travels.Domain.Travel.V1.Commands;

public class UpdateTravelsCommandHandler
{
    private readonly ITravelRepository TravelRepository;
    private readonly IMapper Mapper;

    public UpdateTravelsCommandHandler(ITravelRepository travelRepository,
        IMapper mapper)
    {
        TravelRepository = travelRepository;
        Mapper = mapper;
    }
    public async Task<Travels.Application.Entities.Travel> Handle(UpdateTravelsComman request, CancellationToken cancellationToken)
    {
        var trave = new Travels.Application.Entities.Travel( created: request.Created, name: request.Name, description: request.Description);
        await TravelRepository.UpdateAsync(trave, cancellationToken);
        return trave;
    }
}
