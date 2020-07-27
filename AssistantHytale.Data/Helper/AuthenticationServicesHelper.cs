using AssistantHytale.Domain.Configuration;
using AssistantHytale.Domain.Configuration.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace AssistantHytale.Data.Helper
{
    public static class AuthenticationServicesHelper
    {
        public static IServiceCollection RegisterAuthenticationServicesForApi(this IServiceCollection services, IApiConfiguration config)
        {
            services.SetUpGoogleAuthentication(config.Authentication.GoogleAuth);
            return services;
        }

        private static void SetUpGoogleAuthentication(this IServiceCollection services, GoogleAuth config)
        {
            services.AddAuthentication()
                .AddGoogle(options =>
                {
                    options.ClientId = config.ClientId;
                    options.ClientSecret = config.ClientSecret;
                    options.CallbackPath = "/auth/Google";
                });
        }
    }
}
