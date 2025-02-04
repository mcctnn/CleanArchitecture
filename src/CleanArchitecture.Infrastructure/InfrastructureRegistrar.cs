using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Users;
using CleanArchitecture.Infrastructure.Context;
using CleanArchitecture.Infrastructure.Options;
using CleanArchitecture.Infrastructure.Services;
using GenericRepository;
using Keycloak.AuthServices.Authentication;
using Keycloak.AuthServices.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;

namespace CleanArchitecture.Infrastructure;

public static class InfrastructureRegistrar
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(opt =>
        {
            string connectionString=configuration.GetConnectionString("SqlServer")!;
            opt.UseSqlServer(connectionString);
        });

        services.AddIdentity<AppUser, IdentityRole<Guid>>(opt =>
        {
            opt.Password.RequiredLength = 1;
            opt.Password.RequireNonAlphanumeric = false;
            opt.Password.RequireDigit = false;
            opt.Password.RequireLowercase = false;
            opt.Password.RequireUppercase = false;
            opt.Lockout.MaxFailedAccessAttempts = 3;
            opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            opt.SignIn.RequireConfirmedEmail = true;
        }).AddEntityFrameworkStores<ApplicationDbContext>().
            AddDefaultTokenProviders();

        services.AddScoped<IUnitOfWork>(srv=>srv.GetRequiredService<ApplicationDbContext>());

        services.Configure<JwtOptions>(configuration.GetSection("Jwt"));
        services.ConfigureOptions<JwtOptionsSetup>();
        services.Configure<KeycloakConfiguration>(configuration.GetSection("KeycloakConfiguration"));

        services.AddScoped<KeycloakService>();
        //services.AddScoped<IJwtProvider, KeycloakService>();

        
        

        services.Scan(opt => opt.
        FromAssemblies(typeof(InfrastructureRegistrar).Assembly)
        .AddClasses(publicOnly: false)
        .UsingRegistrationStrategy(RegistrationStrategy.Skip)
        .AsImplementedInterfaces()
        .WithScopedLifetime()
        );

        return services;
    }
}
