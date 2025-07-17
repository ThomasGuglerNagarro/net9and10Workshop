using Microsoft.Extensions.Caching.Hybrid;

namespace ConsoleApp9;
public class HybridCacheDemo(HybridCache cache)
{
    private HybridCache _cache = cache;

    public async Task<string> GetSomeInfoAsync(string name, int id, CancellationToken token = default)
    {
        return await _cache.GetOrCreateAsync(
            $"{name}-{id}", // Unique key to the cache entry
            async cancel => await GetDataFromTheSourceAsync(name, id, cancel),
            options: new HybridCacheEntryOptions() { Expiration = TimeSpan.FromMinutes(5) },
            cancellationToken: token
        );
    }

    public async Task<string> GetDataFromTheSourceAsync(string name, int id, CancellationToken token)
    {
        string someInfo = $"someinfo-{name}-{id}";
        await Task.Delay(1000, token); // Simulate a delay for data retrieval
        return someInfo;
    }
    /*
     builder.Services.AddHybridCache(options =>
       {
           options.MaximumPayloadBytes = 1024 * 1024;
           options.MaximumKeyLength = 1024;
           options.DefaultEntryOptions = new HybridCacheEntryOptions
           {
               Expiration = TimeSpan.FromMinutes(5),
               LocalCacheExpiration = TimeSpan.FromMinutes(5)
           };
       });
     */
}