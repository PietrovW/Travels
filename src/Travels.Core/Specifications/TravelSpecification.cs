using System;
using System.Linq.Expressions;
using Travels.Core.Entities;

namespace Travels.Core.Specifications
{
    public sealed class TravelSpecification : BaseSpecification<Travel>
    {
        public TravelSpecification(Expression<Func<Travel, bool>> criteria) : base(criteria)
        {
        }
    }
}
