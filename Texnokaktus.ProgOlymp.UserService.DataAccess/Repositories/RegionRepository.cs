using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Texnokaktus.ProgOlymp.UserService.DataAccess.Context;
using Texnokaktus.ProgOlymp.UserService.DataAccess.Entities;
using Texnokaktus.ProgOlymp.UserService.DataAccess.Repositories.Abstractions;

namespace Texnokaktus.ProgOlymp.UserService.DataAccess.Repositories;

public class RegionRepository(AppDbContext context) : IRegionRepository
{
    public Task<Region[]> GetAllAsync() =>
        context.Regions
               .AsNoTracking()
               .OrderByDescending(region => region.Order)
               .ThenBy(region => region.Id)
               .ToArrayAsync();

    public Task<bool> ExistsAsync(Expression<Func<Region, bool>> predicate) =>
        context.Regions
               .AsNoTracking()
               .AnyAsync(predicate);
}
