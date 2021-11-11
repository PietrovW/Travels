using System;
using System.Linq.Expressions;
using Travels.Core.Entities;

namespace Travels.Core.Specifications
{
    public sealed class TripSpecification : BaseSpecification<Trip>
    {
        public TripSpecification(Expression<Func<Trip, bool>> criteria):base(criteria)
        {
        }
    }
}
