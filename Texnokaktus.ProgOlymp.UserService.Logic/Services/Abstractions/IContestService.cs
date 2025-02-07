namespace Texnokaktus.ProgOlymp.UserService.Logic.Services.Abstractions;

public interface IContestService
{
    Task<bool> CanRegisterAsync(int contestId);
    Task RegisterUserToPreliminaryStageAsync(int contestId, string login);
}
