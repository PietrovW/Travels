using System;
using Travels.Application.Interfaces;

namespace Travels.Application.Entities;

public class Stops : BaseEntity, IAggregateRoot
{
    public string Name { get; private set; }
    public long Latitude { get; private set; }
    public long Longitude { get; private set; }
    public int Order { get; private set; }
    public Stops(long id,
         DateTimeOffset created,
         string name,
         long latitude,
         long longitude,
         int order) : base(created)
    {
        Name = name;
        Latitude = latitude;
        Longitude = longitude;
        Order = order;
    }
}
