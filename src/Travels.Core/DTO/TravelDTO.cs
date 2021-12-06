using System.Collections.Generic;

namespace Travels.Infrastructure.DTO
{
    public class TravelDTO
    {
        public string Name { get;  set; }
        public string Description { get; set; }
        public IEnumerable<TripDTO> Trips { get;  set; }
    }
}
