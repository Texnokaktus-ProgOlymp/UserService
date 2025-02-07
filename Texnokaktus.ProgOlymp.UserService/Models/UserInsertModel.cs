namespace Texnokaktus.ProgOlymp.UserService.Models;

public record UserInsertModel(Name Name,
                              DateOnly BirthDate,
                              string Snils,
                              string Email,
                              string SchoolName,
                              int RegionId,
                              ThirdPerson Parent,
                              Teacher Teacher,
                              bool PersonalDataConsent,
                              int Grade);
