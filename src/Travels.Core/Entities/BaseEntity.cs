using System;

namespace Travels.Core.Entities
{
    public abstract class BaseEntity
    {
        public long Id { get; protected set; }

        public DateTimeOffset Created { get; protected set; }

        public BaseEntity(long id, 
            DateTimeOffset created)
        {
            Id = id;
            Created = created;
        }
        private BaseEntity() { }
    }
}
