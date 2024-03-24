using Travels.Application.Entities;
using Travels.Application.Interfaces;
using Travels.Infrastructure.Data;

namespace Travels.Infrastructure.Repositories;

public class TravelRepository: EfRepository<Travel>, ITravelRepository
{
    public TravelRepository(TravelsContext dbContext) : base(dbContext) { }
}
