using System;

namespace Travels.Core.Entities
{
    public abstract class BaseEntity
    {
        public long Id { get;  set; }

        public DateTimeOffset Created { get; set; }

        public BaseEntity(long id, 
            DateTimeOffset created)
        {
            Id = id;
            Created = created;
        }
        public BaseEntity() { }
    }
}
