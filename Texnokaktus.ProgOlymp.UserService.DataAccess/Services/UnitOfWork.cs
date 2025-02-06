using Texnokaktus.ProgOlymp.UserService.DataAccess.Context;
using Texnokaktus.ProgOlymp.UserService.DataAccess.Repositories.Abstractions;
using Texnokaktus.ProgOlymp.UserService.DataAccess.Services.Abstractions;

namespace Texnokaktus.ProgOlymp.UserService.DataAccess.Services;

public class UnitOfWork(AppDbContext context, IRegionRepository regionRepository) : IUnitOfWork
{
    public IRegionRepository RegionRepository => regionRepository;
    public Task<int> SaveChangesAsync() => context.SaveChangesAsync();
}
