using Microsoft.Extensions.DependencyInjection;
using Texnokaktus.ProgOlymp.UserService.Logic.Service;
using Texnokaktus.ProgOlymp.UserService.Logic.Service.Abstractions;

namespace Texnokaktus.ProgOlymp.UserService.Logic;

public static class DiExtensions
{
    public static IServiceCollection AddLogicServices(this IServiceCollection services) =>
        services.AddScoped<IRegionService, RegionService>()
                .Decorate<IRegionService, RegionServiceCachingDecorator>();
}
