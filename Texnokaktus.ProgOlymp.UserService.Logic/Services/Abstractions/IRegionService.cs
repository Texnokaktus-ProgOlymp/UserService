using Texnokaktus.ProgOlymp.UserService.Domain;

namespace Texnokaktus.ProgOlymp.UserService.Logic.Services.Abstractions;

public interface IRegionService
{
    Task<IEnumerable<Region>> GetAllRegionsAsync();
    Task<bool> ExistsAsync(int id);
}
