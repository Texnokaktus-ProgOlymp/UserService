namespace Texnokaktus.ProgOlymp.UserService.Logic.Models;

public record Teacher(Name Name, string? Email, string? Phone, string School) : ThirdPerson(Name, Email, Phone);
