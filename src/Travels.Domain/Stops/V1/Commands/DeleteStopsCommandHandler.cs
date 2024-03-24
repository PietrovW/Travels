using Travels.Application.Entities;
using Travels.Application.Interfaces;
using Travels.Domain.Travel.V1.Commands;

namespace Travels.Domin.V1.Command;

public class DeleteStopsCommandHandler
{
    private readonly ITravelRepository TravelRepository;
    
    public DeleteStopsCommandHandler(ITravelRepository travelRepository)
    {
        TravelRepository = travelRepository;
    }
    public async Task Handle(DeleteTravelCommand request, CancellationToken cancellationToken)
    {
        Travel travel = await TravelRepository.FirstAsync(Domain.Extensions.QuerySpecificationExtensions.Criteria<Travel>(x => x.Id == request.Id), cancellationToken:cancellationToken);
        await TravelRepository.DeleteAsync(travel, cancellationToken:cancellationToken);
    }
}
