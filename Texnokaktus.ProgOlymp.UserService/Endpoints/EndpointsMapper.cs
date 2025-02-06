using Texnokaktus.ProgOlymp.UserService.Logic.Service.Abstractions;

namespace Texnokaktus.ProgOlymp.UserService.Endpoints;

internal static class EndpointsMapper
{
    public static IEndpointRouteBuilder MapRegionEndpoints(this IEndpointRouteBuilder builder)
    {
        builder.MapGet("/", (IRegionService s) => s.GetAllRegionsAsync());

        return builder;
    }
}
