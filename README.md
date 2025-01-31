# In-Memory Caching in .NET Core

## Overview

This is a simple .NET Core project demonstrating the implementation of in-memory caching using `IMemoryCache`. The project showcases how to store, retrieve, and remove cached data efficiently to improve application performance.

## Features

- Store data in memory for quick access
- Retrieve cached data efficiently
- Set expiration policies for cache items
- Remove items from cache when needed

## Technologies Used

- .NET Core
- C#
- IMemoryCache

## Example Code

```csharp
public class CacheService
{
    private readonly IMemoryCache _cache;

    public CacheService(IMemoryCache cache)
    {
        _cache = cache;
    }

    public string GetOrSetCachedData(string key)
    {
        if (!_cache.TryGetValue(key, out string cachedValue))
        {
            cachedValue = "Hello from Cache!";
            var cacheOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromMinutes(5));
            _cache.Set(key, cachedValue, cacheOptions);
        }
        return cachedValue;
    }
}
```
