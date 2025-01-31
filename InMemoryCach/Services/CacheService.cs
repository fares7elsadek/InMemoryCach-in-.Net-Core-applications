using Microsoft.Extensions.Caching.Memory;

namespace InMemoryCach.Services;

public class CacheService(IMemoryCache cache) : ICacheService
{
    /// <summary>
    /// Retrieves cached data of type T using the specified key.
    /// </summary>
    /// <typeparam name="T">The type of data to retrieve.</typeparam>
    /// <param name="key">The cache key.</param>
    /// <returns>The cached data if available; otherwise, default(T).</returns>
    public T GetData<T>(string key)
    {
        return cache.TryGetValue(key, out T value) ? value : default;
    }

    /// <summary>
    /// Stores data in the cache with an expiration time.
    /// </summary>
    /// <typeparam name="T">The type of data to cache.</typeparam>
    /// <param name="key">The cache key.</param>
    /// <param name="value">The value to store.</param>
    /// <param name="expirationTime">The time when the cache should expire.</param>
    /// <returns>True if the data was successfully added; otherwise, false.</returns>
    public bool SetData<T>(string key, T value, DateTimeOffset expirationTime)
    {
        if (value == null)
            return false; // Do not cache null values

        var cacheEntryOptions = new MemoryCacheEntryOptions
        {
            AbsoluteExpiration = expirationTime,
            SlidingExpiration = TimeSpan.FromMinutes(5), // Refresh cache if accessed
            Priority = CacheItemPriority.Normal // Normal priority, adjust as needed
        };

        cache.Set(key, value, cacheEntryOptions);
        return true;
    }

    /// <summary>
    /// Removes cached data with the specified key.
    /// </summary>
    /// <param name="key">The cache key to remove.</param>
    /// <returns>True if the key was removed; otherwise, false.</returns>
    public bool RemoveData(string key)
    {
        if (string.IsNullOrEmpty(key))
            return false;

        cache.Remove(key);
        return true;
    }
}
