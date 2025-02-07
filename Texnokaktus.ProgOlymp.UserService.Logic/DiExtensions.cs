using Microsoft.Extensions.DependencyInjection;
using Texnokaktus.ProgOlymp.UserService.Logic.Services;
using Texnokaktus.ProgOlymp.UserService.Logic.Services.Abstractions;

namespace Texnokaktus.ProgOlymp.UserService.Logic;

public static class DiExtensions
{
    public static IServiceCollection AddLogicServices(this IServiceCollection services) =>
        services.AddScoped<IRegionService, RegionService>()
                .Decorate<IRegionService, RegionServiceCachingDecorator>()
                .AddScoped<IContestService, ContestService>()
                .AddScoped<IUserService, Services.UserService>();
}
