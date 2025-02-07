using Texnokaktus.ProgOlymp.Common.Contracts.Grpc.YandexId;

namespace Texnokaktus.ProgOlymp.UserService.Infrastructure.Clients.Abstractions;

public interface IYandexIdUserServiceClient
{
    Task<string> GetOAuthUrlAsync(string? urlRequest);
    Task<User> AuthenticateUserAsync(string code);
}
