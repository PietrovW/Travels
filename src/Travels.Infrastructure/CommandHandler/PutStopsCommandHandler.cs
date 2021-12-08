using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Travels.Core.Entities;
using Travels.Core.Interfaces;
using Travels.Infrastructure.Command;
using Travels.Infrastructure.DTO;

namespace Travels.Infrastructure.CommandHandler
{
    public class PutStopsCommandHandler : IRequestHandler<PutStopsCommand, StopsDTO>
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
            var trave = new Travel(id: request.Id, created: request.Created, name: request.Name, description: request.Description);
            await TravelRepository.UpdateAsync(trave, cancellationToken);
            return _mapper.Map<StopsDTO>(trave);
        }
    }
}
