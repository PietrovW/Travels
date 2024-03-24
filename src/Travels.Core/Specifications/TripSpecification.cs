using System;
using System.Linq.Expressions;
using Travels.Application.Entities;

namespace Travels.Application.Specifications;

public class TripSpecification : BaseSpecification<Trip>
{
    public TripSpecification(Expression<Func<Trip, bool>> criteria):base(criteria)
    {
    }
}
