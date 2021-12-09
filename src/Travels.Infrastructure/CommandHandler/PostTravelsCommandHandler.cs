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
    public class PostTravelsCommandHandler : IRequestHandler<PostTravelsCommand, TravelDTO>
    {
        private readonly ITravelRepository TravelRepository;
        private readonly IMapper _mapper;

        public PostTravelsCommandHandler(ITravelRepository travelRepository,
            IMapper mapper)
        {
            TravelRepository = travelRepository;
            _mapper = mapper;
        }
        public async Task<TravelDTO> Handle(PostTravelsCommand request, CancellationToken cancellationToken)
        {
            var trave = new Travel(created: request.Created, name: request.Name, description: request.Description);
           await TravelRepository.AddAsync(trave, cancellationToken);
            return _mapper.Map<TravelDTO>(trave);
        }
    }
}
