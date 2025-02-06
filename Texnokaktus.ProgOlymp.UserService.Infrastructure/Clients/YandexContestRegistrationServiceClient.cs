using Texnokaktus.ProgOlymp.Common.Contracts.Grpc.YandexContest;
using Texnokaktus.ProgOlymp.UserService.Infrastructure.Clients.Abstractions;

namespace Texnokaktus.ProgOlymp.UserService.Infrastructure.Clients;

public class YandexContestRegistrationServiceClient(RegistrationService.RegistrationServiceClient client) : IYandexContestRegistrationService
{
    public async Task<Error?> RegisterParticipantAsync(long contestStageId, string login, string? displayName)
    {
        var request = new RegisterParticipantRequest
        {
            ContestStageId = contestStageId,
            YandexIdLogin = login,
            DisplayName = displayName
        };
        var response = await client.RegisterParticipantAsync(request);

        return response.Error;
    }
}
