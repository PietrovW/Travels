using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using Travels.Core.Entities;
using Travels.Core.Interfaces;
using Travels.Core.Specifications;

namespace Travels.Infrastructure.Extensions
{
    public static class QuerySpecificationExtensions
    {
        public static ISpecification<T> Criteria<T>(Expression<Func<T, bool>> criteria) where T : BaseEntity, IAggregateRoot
        {
            return new BaseSpecification<T>(criteria);
    }
        public static IQueryable<T> Specify<T>(this IQueryable<T> query, ISpecification<T> specification) where T : BaseEntity, IAggregateRoot
        {
            if (specification.Criteria != null)
            {
                query = query.Where(specification.Criteria);
            }

            query = specification.Includes.Aggregate(query, (current, include) => current.Include(include));

            query = specification.IncludeStrings.Aggregate(query, (current, include) => current.Include(include));

            if (specification.OrderBy != null)
            {
                query = query.OrderBy(specification.OrderBy);
            }
            else if (specification.OrderByDescending != null)
            {
                query = query.OrderByDescending(specification.OrderByDescending);
            }

            if (specification.GroupBy != null)
            {
                query = query.GroupBy(specification.GroupBy).SelectMany(x => x);
            }
            if (specification.IsPagingEnabled)
            {
                query = query.Skip(specification.Skip)
                             .Take(specification.Take);
            }
            return query;
        }
    }
}
