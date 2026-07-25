using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;

namespace WfhTracker.Api.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddCorsPolicy(this IServiceCollection services, IConfiguration config)
    {
        var corsPolicy = config.GetSection("CorsPolicy:WithOrigins").Get<string[]>();
        services.AddCors(options =>
        {
            options.AddPolicy("BlazorClient", policy =>
            {
                policy.WithOrigins(corsPolicy ?? ["https://localhost:7154"])
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });
        return services;
    }

    public static IServiceCollection AddJwtBearerExtension(this IServiceCollection services, IConfiguration config)
    {
        services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddMicrosoftIdentityWebApi(config.GetSection("AzureAd"));

        services.Configure<JwtBearerOptions>(
            JwtBearerDefaults.AuthenticationScheme,
            options =>
            {
                var audiences = config.GetSection("AzureAd:Audience").Get<string[]>()
                    ?? ["api://2100252a-53b7-4276-8686-855173565384"];

                options.TokenValidationParameters.ValidAudiences = audiences;
            });

        return services;
    }
}
