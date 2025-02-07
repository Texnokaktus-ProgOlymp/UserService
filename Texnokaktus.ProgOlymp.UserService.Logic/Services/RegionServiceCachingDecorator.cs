using Microsoft.Extensions.Caching.Memory;
using Texnokaktus.ProgOlymp.UserService.Domain;
using Texnokaktus.ProgOlymp.UserService.Logic.Services.Abstractions;

namespace Texnokaktus.ProgOlymp.UserService.Logic.Services;

internal class RegionServiceCachingDecorator(IRegionService regionService, IMemoryCache memoryCache) : IRegionService
{
    public async Task<IEnumerable<Region>> GetAllRegionsAsync() =>
        await memoryCache.GetOrCreateAsync("Regions:All",
                                           entry =>
                                           {
                                               entry.SetAbsoluteExpiration(TimeSpan.FromHours(1));
                                               return regionService.GetAllRegionsAsync();
                                           })
     ?? [];

    public async Task<bool> ExistsAsync(int id) =>
        await memoryCache.GetOrCreateAsync($"Regions:{id}:Exists",
                                           entry =>
                                           {
                                               entry.SetAbsoluteExpiration(TimeSpan.FromHours(1));
                                               return regionService.ExistsAsync(id);
                                           });
}
