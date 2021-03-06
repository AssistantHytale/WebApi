﻿using AssistantHytale.Data.Cache;
using AssistantHytale.Data.Cache.Interface;
using AssistantHytale.Data.Repository;
using AssistantHytale.Data.Repository.Interface;
using AssistantHytale.Domain.Configuration.Interface;
using AssistantHytale.Integration.Repository;
using AssistantHytale.Integration.Repository.Interface;
using AssistantHytale.Persistence.Repository;
using AssistantHytale.Persistence.Repository.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace AssistantHytale.Data.Helper
{
    public static class RegisterServicesHelper
    {
        public static IServiceCollection RegisterCommonServices(this IServiceCollection services, IApiConfiguration config)
        {
            // Config Singletons
            services.AddSingleton(config);
            services.AddSingleton<IJwt>(construct => config.Jwt);
            services.AddSingleton<ILogging>(construct => config.Logging);
            services.AddSingleton<IDatabase>(construct => config.Database);
            services.AddSingleton<IAuthentication>(construct => config.Authentication);

            // Repositories
            services.AddTransient<IJwtRepository, JwtRepository>();

            // Persistence Repositories
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IServerRepository, ServerRepository>();

            // Integration Repositories
            services.AddTransient<IHytaleBlogRepository, HytaleBlogRepository>();
            services.AddTransient<IGithubRepository, GithubRepository>();

            // Services
            //services.AddTransient<IUserService, UserService>();

            // MemoryCache stuffs
            services.AddSingleton<ICustomCache, CustomCache>();

            return services;
        }

    }
}
