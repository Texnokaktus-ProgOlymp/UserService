using Texnokaktus.ProgOlymp.UserService.Infrastructure.Clients.Abstractions;
using Texnokaktus.ProgOlymp.UserService.Logic.Service.Abstractions;

namespace Texnokaktus.ProgOlymp.UserService.Logic.Service;

public class ContestService(IContestStateServiceClient contestStateServiceClient,
                            IYandexContestRegistrationService yandexContestRegistrationService) : IContestService
{
    public Task<bool> CanRegisterAsync(int contestId) => contestStateServiceClient.GetRegistrationStateAsync(contestId);

    public async Task RegisterUserToPreliminaryStageAsync(int contestId, string login)
    {
        
        if (await yandexContestRegistrationService.RegisterParticipantAsync(0L, login, login) is { } error)
        {
            /*  Handle error */
        }
    }
}
