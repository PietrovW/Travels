
using MediatR;
using System;
using Travels.Infrastructure.DTO;

namespace Travels.Infrastructure.Command
{
    public class PutStopsCommand : IRequest<StopsDTO>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTimeOffset Created { get; set; }
    }
}
