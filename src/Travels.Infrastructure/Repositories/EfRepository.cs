using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Travels.Application.Entities;
using Travels.Application.Interfaces;
using Travels.Infrastructure.Data;
using Travels.Infrastructure.Extensions;

namespace Travels.Infrastructure.Repositories;

public class EfRepository<T> : IAsyncRepository<T> where T : BaseEntity, IAggregateRoot
{
    protected readonly TravelsContext _dbContext;

    public EfRepository(TravelsContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<T>> ListAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<T>().ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<T>> ListAsync(ISpecification<T> spec, CancellationToken cancellationToken = default)
    {
        var specificationResult = ApplySpecification(spec);
        return await specificationResult.ToListAsync(cancellationToken);
    }

    public async Task<int> CountAsync(ISpecification<T> spec, CancellationToken cancellationToken = default)
    {
        var specificationResult = ApplySpecification(spec);
        return await specificationResult.CountAsync(cancellationToken);
    }

    public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        await _dbContext.Set<T>().AddAsync(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return entity;
    }

    public async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
    {
        _dbContext.Set<T>().Remove(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<T> FirstAsync(ISpecification<T> spec, CancellationToken cancellationToken = default)
    {
        var specificationResult = ApplySpecification(spec);
        return await specificationResult.FirstAsync(cancellationToken);
    }

    public async Task<T> FirstOrDefaultAsync(ISpecification<T> spec, CancellationToken cancellationToken = default)
    {
        var specificationResult = ApplySpecification(spec);
        return await specificationResult.FirstOrDefaultAsync(cancellationToken);
    }

    private IQueryable<T> ApplySpecification(ISpecification<T> specification)
    {
        var query = _dbContext.Set<T>().AsQueryable();
        query.Specify(specification);
        return query;
    }
}
