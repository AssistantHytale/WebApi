using AssistantHytale.Data.Cache;
using AssistantHytale.Data.Cache.Interface;
using AssistantHytale.Domain.Configuration.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace AssistantHytale.Data.Helper
{
    public static class RegisterServicesHelper
    {
        public static IServiceCollection RegisterCommonServices(this IServiceCollection services, IApiConfiguration config)
        {
            // Config Singletons
            services.AddSingleton(config);
            services.AddSingleton<ILogging>(construct => config.Logging);
            services.AddSingleton<IDatabase>(construct => config.Database);
            services.AddSingleton<IAuthentication>(construct => config.Authentication);

            // Repositories
            //services.AddTransient<IJwtRepository, JwtRepository>();

            //services.AddTransient<IStreamNewsScrapeRepository, StreamNewsScrapeRepository>();
            //services.AddTransient<IGithubRepository, GithubRepository>();

            // MemoryCache stuffs
            services.AddSingleton<ICustomCache, CustomCache>();


            // Services
            //services.AddTransient<IUserService, UserService>();

            return services;
        }

    }
}
