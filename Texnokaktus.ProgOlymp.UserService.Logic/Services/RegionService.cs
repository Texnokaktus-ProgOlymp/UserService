using Texnokaktus.ProgOlymp.UserService.DataAccess.Services.Abstractions;
using Texnokaktus.ProgOlymp.UserService.Domain;
using Texnokaktus.ProgOlymp.UserService.Logic.Services.Abstractions;

namespace Texnokaktus.ProgOlymp.UserService.Logic.Services;

internal class RegionService(IUnitOfWork unitOfWork) : IRegionService
{
    public async Task<IEnumerable<Region>> GetAllRegionsAsync()
    {
        var regions = await unitOfWork.RegionRepository.GetAllAsync();
        return regions.Select(region => new Region(region.Id, region.Name));
    }

    public Task<bool> ExistsAsync(int id) => unitOfWork.RegionRepository.ExistsAsync(region => region.Id == id);
}
