using Microsoft.AspNetCore.Http.HttpResults;
using Texnokaktus.ProgOlymp.UserService.Models;

namespace Texnokaktus.ProgOlymp.UserService.Services.Abstractions;

public interface IAuthenticationService
{
    Task<Ok<UserModel>> AuthenticateUserAsync(HttpContext context, string code);
}
