using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Texnokaktus.ProgOlymp.Common.Contracts.Grpc.ContestService;
using Texnokaktus.ProgOlymp.Common.Contracts.Grpc.YandexContest;
using Texnokaktus.ProgOlymp.UserService.Infrastructure.Clients;
using Texnokaktus.ProgOlymp.UserService.Infrastructure.Clients.Abstractions;

namespace Texnokaktus.ProgOlymp.UserService.Infrastructure;

public static class DiExtensions
{
    public static IServiceCollection AddGrpcClients(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddGrpcClient<StateService.StateServiceClient>(options => options.Address = configuration.GetConnectionStringUri(nameof(StateService)));
        services.AddGrpcClient<RegistrationService.RegistrationServiceClient>(options => options.Address = configuration.GetConnectionStringUri("YandexContestRegistrationService"));

        return services.AddScoped<IContestStateServiceClient, ContestStateServiceClient>()
                       .AddScoped<IYandexContestRegistrationService, YandexContestRegistrationServiceClient>();
    }

    private static Uri? GetGrpcConnectionString<TGrpcService>(this IConfiguration configuration) =>
        configuration.GetConnectionStringUri(typeof(TGrpcService).Name);

    private static Uri? GetConnectionStringUri(this IConfiguration configuration, string name) =>
        configuration.GetConnectionString(name) is { } connectionString
            ? new Uri(connectionString)
            : null;
}
