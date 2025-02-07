using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http.HttpResults;
using Texnokaktus.ProgOlymp.UserService.Infrastructure.Clients.Abstractions;
using Texnokaktus.ProgOlymp.UserService.Models;
using IAuthenticationService = Texnokaktus.ProgOlymp.UserService.Services.Abstractions.IAuthenticationService;

namespace Texnokaktus.ProgOlymp.UserService.Services;

public class CookieAuthenticationService(IYandexIdUserServiceClient yandexIdUserServiceClient) : IAuthenticationService
{
    public async Task<Ok<UserModel>> AuthenticateUserAsync(HttpContext context, string code)
    {
        var user = await yandexIdUserServiceClient.AuthenticateUserAsync(code);

        var claimsIdentity = new ClaimsIdentity([
                                                    new(ClaimTypes.Name, user.Login)
                                                ],
                                                CookieAuthenticationDefaults.AuthenticationScheme);
        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
        
        await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                                  claimsPrincipal,
                                  new()
                                  {
                                      IsPersistent = true
                                  });

        return TypedResults.Ok(new UserModel(user.Login, user.DisplayName, user.Avatar?.AvatarId));
    }
}
