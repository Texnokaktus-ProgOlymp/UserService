using Texnokaktus.ProgOlymp.UserService.DataAccess.Repositories.Abstractions;

namespace Texnokaktus.ProgOlymp.UserService.DataAccess.Services.Abstractions;

public interface IUnitOfWork
{
    IRegionRepository RegionRepository { get; }
    Task<int> SaveChangesAsync();
}
