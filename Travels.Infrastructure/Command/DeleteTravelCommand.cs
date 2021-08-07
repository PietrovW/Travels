using MediatR;
using System;

namespace Travels.Infrastructure.Command
{
    public class DeleteTravelCommand : IRequest
    {
        public long Id { get; set; }
    }
}
