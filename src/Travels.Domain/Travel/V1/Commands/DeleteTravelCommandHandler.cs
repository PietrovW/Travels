using Travels.Application.Interfaces;
using Travels.Application.Entities;
using Travels.Domain.Extensions;

namespace Travels.Domain.Travel.V1.Commands;

public class DeleteTravelCommandHandler
{
    private readonly ITravelRepository TravelRepository;
    
    public DeleteTravelCommandHandler(ITravelRepository travelRepository)
    {
        TravelRepository = travelRepository;
    }
    public async Task Handle(DeleteTravelCommand request, CancellationToken cancellationToken)
    {
        Travels.Application.Entities.Travel travel = await TravelRepository.FirstAsync(QuerySpecificationExtensions.Criteria<Travels.Application.Entities.Travel>(x => x.Id == request.Id), cancellationToken: cancellationToken);
        await TravelRepository.DeleteAsync(travel, cancellationToken: cancellationToken);
    }
}
