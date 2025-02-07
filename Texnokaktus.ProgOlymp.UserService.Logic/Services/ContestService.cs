using Texnokaktus.ProgOlymp.UserService.Infrastructure.Clients.Abstractions;
using Texnokaktus.ProgOlymp.UserService.Logic.Services.Abstractions;

namespace Texnokaktus.ProgOlymp.UserService.Logic.Services;

public class ContestService(IContestRegistrationService contestRegistrationService) : IContestService
{
    public Task<bool> CanRegisterAsync(int contestId) => contestRegistrationService.GetRegistrationState(contestId);

    public Task RegisterUserToPreliminaryStageAsync(int contestId, string login) =>
        contestRegistrationService.RegisterUserToPreliminaryStageAsync(contestId, login, login);
}
