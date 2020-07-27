using System;
using System.Security.Claims;
using System.Threading.Tasks;
using AssistantHytale.Domain.Configuration.Interface;
using AssistantHytale.Domain.Constants;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace AssistantHytale.Data.Helper
{
    public static class AuthenticationServicesHelper
    {
        public static IServiceCollection RegisterAuthenticationServicesForApi(this IServiceCollection services, IApiConfiguration config)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddAuthentication(options =>
                {
                    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                })
                // Add Cookie settings
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
                {
                    options.LoginPath = $"/{ApiUrl.Login}";
                    options.LogoutPath = $"/{ApiUrl.Logout}";
                    options.SlidingExpiration = true;
                })
                .SetUpGoogleAuthentication(config.Authentication.GoogleAuth);
            return services;
        }

        private static void SetUpGoogleAuthentication(this AuthenticationBuilder builder, IGoogleAuth config)
        {
            builder
                .AddGoogle(options =>
                {
                    options.ClientId = config.ClientId;
                    options.ClientSecret = config.ClientSecret;
                    options.UserInformationEndpoint = "https://www.googleapis.com/oauth2/v2/userinfo";
                    options.ClaimActions.Clear();
                    options.ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "id");
                    options.ClaimActions.MapJsonKey(ClaimTypes.Name, "name");
                    options.ClaimActions.MapJsonKey("urn:google:profile", "link");
                    options.ClaimActions.MapJsonKey(ClaimTypes.Email, "email");
                    options.Events = new OAuthEvents
                    {
                        OnCreatingTicket = OnCreatingTicket
                    };
                });
        }

        private static async Task OnCreatingTicket(OAuthCreatingTicketContext arg)
        {
            var firstName = arg.Identity.FindFirst(ClaimTypes.Name).Value;
            var email = arg.Identity.FindFirst(ClaimTypes.Email).Value;


            //Todo: Add logic here to save info into database
        }
    }
}
