using System;
using System.Collections.Generic;
using System.IO;
using AssistantHytale.Data.Filter;
using AssistantHytale.Domain.Configuration.Interface;
using AssistantHytale.Domain.Constants;
using AssistantHytale.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace AssistantHytale.Data.Helper
{
    public static class ThirdPartySetupHelper
    {
        public static IServiceCollection RegisterThirdPartyServicesForApi(this IServiceCollection services, IApiConfiguration config)
        {
            services.SetUpApplicationInsight(config);
            services.SetUpEntityFramework(config);
            services.SetUpSwagger();
            return services;
        }

        private static void SetUpApplicationInsight(this IServiceCollection services, IApiConfiguration config)
        {
            if (config.ApplicationInsights.Enabled)
            {
                services.AddApplicationInsightsTelemetry(config.ApplicationInsights.InstrumentationKey);
            }
        }

        private static void SetUpEntityFramework(this IServiceCollection services, IApiConfiguration config)
        {
            services.AddDbContext<HytaleAssistantContext>(options => options
                .UseLazyLoadingProxies()
                .UseSqlServer(config.Database.ConnectionString, dbOptions => dbOptions.MigrationsAssembly("AssistantHytale.Api"))
            );
        }
        
        private static void SetUpSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(ApiAccess.Public, SwaggerHelper.CreateInfoForApiVersion(ApiAccess.Public));
                //c.SwaggerDoc(ApiAccess.Auth, SwaggerHelper.CreateInfoForApiVersion(ApiAccess.Auth));
                c.SwaggerDoc(ApiAccess.All, SwaggerHelper.CreateInfoForApiVersion(ApiAccess.All));
                c.DocInclusionPredicate(SwaggerHelper.DocInclusionPredicate);

                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        AuthorizationCode = new OpenApiOAuthFlow
                        {
                            AuthorizationUrl = new Uri("https://localhost:5000/connect/authorize"),
                            TokenUrl = new Uri("https://localhost:5000/connect/token"),
                            Scopes = new Dictionary<string, string>
                            {
                                {"api1", "Demo API - full access"}
                            }
                        }
                    }
                });

                //c.AddSecurityDefinition(ApiAuthScheme.Basic, new OpenApiSecurityScheme
                //{
                //    Type = SecuritySchemeType.Http,
                //    Description = "basic authentication for API",
                //    In = ParameterLocation.Header,
                //    Scheme = ApiAuthScheme.Basic
                //});
                //c.AddSecurityDefinition(ApiAuthScheme.JwtBearer, new OpenApiSecurityScheme
                //{
                //    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n" +
                //                  "Enter 'Bearer' [space] and then your token in the text input below." +
                //                  "\r\n\r\nExample: 'Bearer 12345abcdef'",
                //    Name = "Authorization",
                //    In = ParameterLocation.Header,
                //    Type = SecuritySchemeType.ApiKey,
                //    Scheme = ApiAuthScheme.JwtBearer
                //});
                c.OperationFilter<AuthorizeCheckOperationFilter>();

                // Set the comments path for the Swagger JSON and UI.
                const string xmlFile = "AssistantHytale.Api.xml";
                string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }
    }
}
