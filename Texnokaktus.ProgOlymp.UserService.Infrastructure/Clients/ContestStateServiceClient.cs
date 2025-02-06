using Grpc.Core;
using Texnokaktus.ProgOlymp.Common.Contracts.Grpc.ContestService;
using Texnokaktus.ProgOlymp.UserService.Infrastructure.Clients.Abstractions;

namespace Texnokaktus.ProgOlymp.UserService.Infrastructure.Clients;

public class ContestStateServiceClient(StateService.StateServiceClient client) : IContestStateServiceClient
{
    public async Task<bool> GetRegistrationStateAsync(int contestId)
    {
        var request = new GetRegistrationStateRequest()
        {
            ContestId = contestId
        };

        try
        {
            var response = await client.GetRegistrationStateAsync(request);
            return response.Result;
        }
        catch (RpcException e) when (e.Status.StatusCode == StatusCode.NotFound)
        {
            return false;
        }
    }
}
