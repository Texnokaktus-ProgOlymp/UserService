using Microsoft.AspNetCore.Http.HttpResults;
using Texnokaktus.ProgOlymp.UserService.Logic.Services.Abstractions;
using Texnokaktus.ProgOlymp.UserService.Models;
using Texnokaktus.ProgOlymp.UserService.Services.Abstractions;
using ThirdPerson = Texnokaktus.ProgOlymp.UserService.Logic.Models.ThirdPerson;

namespace Texnokaktus.ProgOlymp.UserService.Services;

public class RegistrationService(IUserService userService) : IRegistrationService
{
    public async Task<Results<Created, Conflict>> RegisterUserAsync(int contestId, string login, UserInsertModel insertModel)
    {
        var model = insertModel.MapUserInsertModel(contestId, login);
        await userService.RegisterUserAsync(model);

        return TypedResults.Created();
    }
}

file static class MappingExtensions
{
    public static Logic.Models.UserInsertModel MapUserInsertModel(this UserInsertModel userInsertModel,
                                                                  int contestId,
                                                                  string login) =>
        new(contestId,
            login,
            userInsertModel.Name.MapName(),
            userInsertModel.BirthDate,
            userInsertModel.Snils,
            userInsertModel.Email,
            userInsertModel.SchoolName,
            userInsertModel.RegionId,
            userInsertModel.Parent.MapThirdPerson(),
            userInsertModel.Teacher.MapTeacher(),
            userInsertModel.PersonalDataConsent,
            userInsertModel.Grade);
    
    private static Logic.Models.Teacher MapTeacher(this Teacher teacher)
    {
        var thirdPerson = teacher.MapThirdPerson();
        return new(thirdPerson.Name,
                   thirdPerson.Email,
                   thirdPerson.Phone,
                   teacher.School);
    }
    
    private static ThirdPerson MapThirdPerson(this Models.ThirdPerson thirdPerson) =>
        new(thirdPerson.Name.MapName(),
            thirdPerson.Email,
            thirdPerson.Phone);
    
    private static Logic.Models.Name MapName(this Name name) =>
        new(name.FirstName,
            name.LastName,
            name.Patronym);
}
