using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Travels.Core.Entities;
using Travels.Core.Interfaces;
using Travels.Infrastructure.Command;

namespace Travels.Infrastructure.CommandHandler
{
    public class PutTravelsCommandHandler : IRequestHandler<PutTravelsCommand, Travel>
    {
        private readonly ITravelRepository TravelRepository;
        private readonly IMapper Mapper;

        public PutTravelsCommandHandler(ITravelRepository travelRepository,
            IMapper mapper)
        {
            TravelRepository = travelRepository;
            Mapper = mapper;
        }
        public async Task<Travel> Handle(PutTravelsCommand request, CancellationToken cancellationToken)
        {
            var trave = new Travel( created: request.Created, name: request.Name, description: request.Description);
            await TravelRepository.UpdateAsync(trave, cancellationToken);
            return trave;
        }
    }
}
