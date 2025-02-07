using Texnokaktus.ProgOlymp.UserService.Infrastructure.Clients.Abstractions;
using Texnokaktus.ProgOlymp.UserService.Logic.Services.Abstractions;
using Texnokaktus.ProgOlymp.UserService.Models;
using Texnokaktus.ProgOlymp.UserService.Services.Abstractions;

namespace Texnokaktus.ProgOlymp.UserService.Endpoints;

internal static class EndpointsMapper
{
    public static IEndpointRouteBuilder MapRegionEndpoints(this IEndpointRouteBuilder builder)
    {
        builder.MapGet("/regions", (IRegionService s) => s.GetAllRegionsAsync());

        return builder;
    }

    public static IEndpointRouteBuilder MapRegistrationEndpoints(this IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("contests/{contestId:int}");

        group.MapPost("/register",
                      (int contestId,
                       UserInsertModel model,
                       HttpContext context,
                       IRegistrationService service) =>
                      {
                          var login = context.User.Identity?.Name ?? throw new();
                          return service.RegisterUserAsync(contestId, login, model);
                      })
             .RequireAuthorization();

        return builder;
    }

    public static IEndpointRouteBuilder MapAuthorizationEndpoints(this IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("authorize");

        group.MapGet("url",
                     async (string? redirectUrl,
                            IYandexIdUserServiceClient c) => TypedResults.Ok(await c.GetOAuthUrlAsync(redirectUrl)));

        group.MapGet("redirect",
                     async (string? redirectUrl,
                            IYandexIdUserServiceClient c) =>
                         TypedResults.Redirect(await c.GetOAuthUrlAsync(redirectUrl)));

        group.MapPost("",
                      (AuthorizationModel model,
                       HttpContext context,
                       IAuthenticationService service) => service.AuthenticateUserAsync(context, model.Code));

        return builder;
    }
}
