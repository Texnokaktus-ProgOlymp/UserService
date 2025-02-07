using Texnokaktus.ProgOlymp.Common.Contracts.Grpc.ContestService;
using Texnokaktus.ProgOlymp.UserService.Infrastructure.Clients.Abstractions;

namespace Texnokaktus.ProgOlymp.UserService.Infrastructure.Clients;

public class ContestRegistrationServiceClient(RegistrationService.RegistrationServiceClient client) : IContestRegistrationService
{
    public async Task<bool> GetRegistrationState(int contestId)
    {
        var request = new GetRegistrationStateRequest
        {
            ContestId = contestId
        };

        var response = await client.GetRegistrationStateAsync(request);

        return response.Result;
    }

    public async Task RegisterUserToPreliminaryStageAsync(int contestId, string login, string? displayName)
    {
        var request = new RegisterUserToPreliminaryStageRequest
        {
            ContestId = contestId,
            DisplayName = displayName,
            Login = login
        };

        await client.RegisterUserToPreliminaryStageAsync(request);
    }
}
