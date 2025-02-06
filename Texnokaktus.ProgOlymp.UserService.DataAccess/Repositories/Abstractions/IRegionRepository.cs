using System.Linq.Expressions;
using Texnokaktus.ProgOlymp.UserService.DataAccess.Entities;

namespace Texnokaktus.ProgOlymp.UserService.DataAccess.Repositories.Abstractions;

public interface IRegionRepository
{
    Task<Region[]> GetAllAsync();
    Task<bool> ExistsAsync(Expression<Func<Region, bool>> predicate);
}
