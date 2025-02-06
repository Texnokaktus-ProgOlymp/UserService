namespace Texnokaktus.ProgOlymp.UserService.Infrastructure.Clients.Abstractions;

public interface IContestStateServiceClient
{
    Task<bool> GetRegistrationStateAsync(int contestId);
}
