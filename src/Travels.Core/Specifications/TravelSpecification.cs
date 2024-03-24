using System;
using System.Linq.Expressions;
using Travels.Application.Entities;

namespace Travels.Application.Specifications;

public sealed class TravelSpecification : BaseSpecification<Travel>
{
    public TravelSpecification(Expression<Func<Travel, bool>> criteria) : base(criteria)
    {
    }
}
