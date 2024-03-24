using System;
using System.Collections.Generic;

namespace Travels.Infrastructure.DTO;

public class TripDTO
{
    public int CountryID { get; set; }
    public int DaysCount { get; set; }
    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset EndDate { get; set; }
    public string Destination { get; set; }

    public TravelDTO Travel { get; private set; }

    public IEnumerable<StopsDTO> Stops { get; private set; }
}
