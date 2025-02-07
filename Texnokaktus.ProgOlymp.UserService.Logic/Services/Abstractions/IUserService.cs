using Texnokaktus.ProgOlymp.UserService.Logic.Models;

namespace Texnokaktus.ProgOlymp.UserService.Logic.Services.Abstractions;

public interface IUserService
{
    Task<bool> IsUserRegisteredAsync(int contestId, string login);
    Task<int> RegisterUserAsync(UserInsertModel userInsertModel);
}
