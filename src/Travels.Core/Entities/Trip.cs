using System;
using System.Collections.Generic;
using Travels.Core.Interfaces;

namespace Travels.Core.Entities
{
    public class Trip : BaseEntity, IAggregateRoot
    {
        public int CountryID { get; private set; }
        public int DaysCount { get; private set; }
        public DateTimeOffset StartDate { get; private set; }
        public DateTimeOffset EndDate { get; private set; }
        public string Destination { get; private set; }

        public Travel Travel { get; private set; }

        public IEnumerable<Stops> Stops { get; private set; }

        public Trip(long id,
             DateTimeOffset created,
            int countryID, 
            int daysCount, 
            DateTimeOffset startDate,
            DateTimeOffset endDate,
            string destination) : base(id, created)
        {
            CountryID = countryID;
            DaysCount = daysCount;
            StartDate = startDate;
            EndDate = endDate;
            Destination = destination;
        }
    }
}
