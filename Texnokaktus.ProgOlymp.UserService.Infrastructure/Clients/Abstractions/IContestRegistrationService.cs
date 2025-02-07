namespace Texnokaktus.ProgOlymp.UserService.Infrastructure.Clients.Abstractions;

public interface IContestRegistrationService
{
    Task<bool> GetRegistrationState(int contestId);
    Task RegisterUserToPreliminaryStageAsync(int contestId, string login, string? displayName);
}
