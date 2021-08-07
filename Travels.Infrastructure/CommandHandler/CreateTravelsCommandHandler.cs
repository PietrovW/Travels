using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Travels.Core.Entities;
using Travels.Infrastructure.Command;
using Travels.Infrastructure.Repositories;

namespace Travels.Infrastructure.CommandHandler
{
    public class CreateTravelsCommandHandler : IRequestHandler<CreateTravelsCommand, Travel>
    {
        private readonly EfRepository<Travel> TravelRepository;
        private readonly IMapper Mapper;

        public CreateTravelsCommandHandler(EfRepository<Travel> travelRepository,
            IMapper mapper)
        {
            TravelRepository = travelRepository;
            Mapper = mapper;
        }
        public async Task<Travel> Handle(CreateTravelsCommand request, CancellationToken cancellationToken)
        {
            var trave = new Travel(id: request.Id, created: request.Created, name: request.Name, description: request.Description);
            return await TravelRepository.AddAsync(trave, cancellationToken);
        }
    }
}
