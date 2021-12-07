using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Travels.Core.Entities;
using Travels.Core.Interfaces;
using Travels.Infrastructure.Command;
using Travels.Infrastructure.Extensions;

namespace Travels.Infrastructure.CommandHandler
{
    public class DeleteTravelCommandHandler : IRequestHandler<DeleteTravelCommand>
    {
        private readonly ITravelRepository TravelRepository;
        
        public DeleteTravelCommandHandler(ITravelRepository travelRepository)
        {
            TravelRepository = travelRepository;
        }
        public async Task<Unit> Handle(DeleteTravelCommand request, CancellationToken cancellationToken)
        {
            Travel travel = await TravelRepository.FirstAsync(QuerySpecificationExtensions.Criteria<Travel>(x => x.Id == request.Id), cancellationToken);
            await TravelRepository.DeleteAsync(travel, cancellationToken);
            return Unit.Value;
        }
    }
}
