using System;

namespace Travels.Core.Domain
{
    public interface ITravel
    {
        long Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        DateTimeOffset Created { get; set; }
    }
}
