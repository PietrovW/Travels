using System.Linq.Expressions;
using Travels.Application.Entities;
using Travels.Application.Interfaces;
using Travels.Application.Specifications;

namespace Travels.Domain.Extensions;
public static class QuerySpecificationExtensions
{
    public static ISpecification<T> Criteria<T>(Expression<Func<T, bool>> criteria) where T : BaseEntity, IAggregateRoot
    {
        return new BaseSpecification<T>(criteria);
    }
}
