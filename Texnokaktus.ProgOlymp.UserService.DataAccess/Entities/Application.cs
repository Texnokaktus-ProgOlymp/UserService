namespace Texnokaktus.ProgOlymp.UserService.DataAccess.Entities;

public class Application
{
    public int Id { get; init; }
    public required int ContestId { get; init; }
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required string? Patronym { get; init; }
    public required DateOnly BirthDate { get; init; }
    public required string Snils { get; init; }
    public required string Email { get; init; }
    public required string YandexIdLogin { get; init; }
    public required string SchoolName { get; init; }
    public required int RegionId { get; init; }
    public required ThirdPerson Parent { get; init; }
    public required Teacher Teacher { get; init; }
    public required bool PersonalDataConsent { get; init; }
    public required int Grade { get; init; }

    public Region Region { get; set; }
}
