namespace Texnokaktus.ProgOlymp.UserService.Logic.Service.Abstractions;

public interface IContestService
{
    Task<bool> CanRegisterAsync(int contestId);
    Task RegisterUserToPreliminaryStageAsync(int contestId, string login);
}
