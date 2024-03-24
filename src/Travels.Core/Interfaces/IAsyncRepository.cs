using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Travels.Application.Entities;

namespace Travels.Application.Interfaces;

public interface IAsyncRepository<T> where T : BaseEntity, IAggregateRoot
{
    Task<IEnumerable<T>> ListAllAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<T>> ListAsync(ISpecification<T> spec, CancellationToken cancellationToken = default);
    Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
    Task UpdateAsync(T entity, CancellationToken cancellationToken = default);
    Task DeleteAsync(T entity, CancellationToken cancellationToken = default);
    Task<int> CountAsync(ISpecification<T> spec, CancellationToken cancellationToken = default);
    Task<T> FirstAsync(ISpecification<T> spec, CancellationToken cancellationToken = default);
    Task<T> FirstOrDefaultAsync(ISpecification<T> spec, CancellationToken cancellationToken = default);
}
