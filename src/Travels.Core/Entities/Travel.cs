using System;
using System.Collections.Generic;
using Travels.Core.Interfaces;

namespace Travels.Core.Entities
{
    public class Travel : BaseEntity, IAggregateRoot
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<Trip> Trips { get; private set; }

        public Travel(DateTimeOffset created,
            string name,
            string description)
            : base(created)
        {
            Name = name;
            Description = description;
        }
    }
}
