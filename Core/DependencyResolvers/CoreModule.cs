﻿
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.InMemory;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using Core.CrossCuttingConcerns.Caching.Redis;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            serviceCollection.AddMemoryCache();
            serviceCollection.AddSingleton<ICacheService, InMemoryCacheManager>();

            //serviceCollection.AddStackExchangeRedisCache(options =>
            //{
            //    options.Configuration = "localhost:6379";
            //});
            //serviceCollection.AddSingleton<ICacheService, RedisCacheManager>();

            serviceCollection.AddSingleton<Stopwatch>();
        }
    }
}
