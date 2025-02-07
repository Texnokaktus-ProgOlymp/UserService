using Microsoft.AspNetCore.Http.HttpResults;
using Texnokaktus.ProgOlymp.UserService.Models;

namespace Texnokaktus.ProgOlymp.UserService.Services.Abstractions;

public interface IRegistrationService
{
    Task<Results<Created, Conflict>> RegisterUserAsync(int contestId, string login, UserInsertModel insertModel);
}
