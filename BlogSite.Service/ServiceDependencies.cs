using BlogSite.Service.Abstratcts;
using BlogSite.Service.Concretes;
using BlogSite.Service.Profiles;
using BlogSite.Service.Rules;
using Microsoft.Extensions.DependencyInjection;

namespace BlogSite.Service;

public static class ServiceDependencies
{

    public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingProfiles));
        services.AddScoped<PostBusinessRules>();
        services.AddScoped<IJwtService, JwtService>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IPostService, PostService>();
        return services;
    }
}
