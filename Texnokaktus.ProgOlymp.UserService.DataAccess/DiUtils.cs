using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Texnokaktus.ProgOlymp.UserService.DataAccess.Context;
using Texnokaktus.ProgOlymp.UserService.DataAccess.Repositories;
using Texnokaktus.ProgOlymp.UserService.DataAccess.Repositories.Abstractions;
using Texnokaktus.ProgOlymp.UserService.DataAccess.Services;
using Texnokaktus.ProgOlymp.UserService.DataAccess.Services.Abstractions;

namespace Texnokaktus.ProgOlymp.UserService.DataAccess;

public static class DiUtils
{
    public static IServiceCollection AddDataAccess(this IServiceCollection serviceCollection,
                                                   Action<DbContextOptionsBuilder> optionsAction) =>
        serviceCollection.AddDbContext<AppDbContext>(optionsAction)
                         .AddScoped<IUnitOfWork, UnitOfWork>()
                         .AddScoped<IRegionRepository, RegionRepository>()
                         .AddScoped<IApplicationRepository, ApplicationRepository>();

    public static IHealthChecksBuilder AddDatabaseHealthChecks(this IHealthChecksBuilder builder) =>
        builder.AddDbContextCheck<AppDbContext>("database");
}
