using System.Linq.Expressions;
using Texnokaktus.ProgOlymp.UserService.DataAccess.Entities;
using Texnokaktus.ProgOlymp.UserService.DataAccess.Models;

namespace Texnokaktus.ProgOlymp.UserService.DataAccess.Repositories.Abstractions;

public interface IApplicationRepository
{
    Application Add(UserInsertModel insertModel);
    Task<bool> ExistsAsync(Expression<Func<Application, bool>> predicate);
}
