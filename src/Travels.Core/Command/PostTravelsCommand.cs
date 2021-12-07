
using MediatR;
using System;
using Travels.Core.Domain;
using Travels.Core.Entities;

namespace Travels.Infrastructure.Command
{
    public class PostTravelsCommand : ITravel,IRequest<Travel>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTimeOffset Created { get; set; }
    }
}
