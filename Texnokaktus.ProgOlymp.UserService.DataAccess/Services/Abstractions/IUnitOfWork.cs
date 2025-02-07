using Texnokaktus.ProgOlymp.UserService.DataAccess.Repositories.Abstractions;

namespace Texnokaktus.ProgOlymp.UserService.DataAccess.Services.Abstractions;

public interface IUnitOfWork
{
    IRegionRepository RegionRepository { get; }
    IApplicationRepository ApplicationRepository { get; }
    Task<int> SaveChangesAsync();
}
