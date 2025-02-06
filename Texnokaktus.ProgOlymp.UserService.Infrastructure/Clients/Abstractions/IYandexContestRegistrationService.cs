using Texnokaktus.ProgOlymp.Common.Contracts.Grpc.YandexContest;

namespace Texnokaktus.ProgOlymp.UserService.Infrastructure.Clients.Abstractions;

public interface IYandexContestRegistrationService
{
    Task<Error?> RegisterParticipantAsync(long contestStageId, string login, string? displayName);
}
