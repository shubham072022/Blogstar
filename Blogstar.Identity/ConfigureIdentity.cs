using Blogstar.Identity.Repository.Queries;
using BlogStar.Application.Common.Interfaces;
using BlogStar.Application.Repositories.Authentication.Commands;
using BlogStar.Application.Repositories.Authentication.Queries;
using BlogStar.Identity.DbContext;
using BlogStar.Identity.Repository.Commands;
using BlogStar.Identity.Services;
using BlogStar.Identity.Settings;
using BlogStar.Shared.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BlogStar.Identity
{
    public static class ConfigureIdentity
    {
        public static IServiceCollection AddIdentityContext(this IServiceCollection services
            ,IConfiguration configuration)
        {
            services.AddDbContext<BlogIdentityDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("BlogDb"),
                builder => builder.MigrationsAssembly(typeof(BlogIdentityDbContext).Assembly.FullName)));

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<BlogIdentityDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<JWTSettings>(configuration.GetSection("JWTSettings"));

            var jwtSettings = configuration.GetSection("JWTSettings")
                .Get<JWTSettings>();


            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateIssuerSigningKey = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience[0],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecurityKey))
                };
            });

            services.AddSingleton<ICurrentUserService, CurrentUserService>();
            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<IAuthenticationCommandRepository, AuthenticationCommandRepository>();
            services.AddTransient<IAuthQueryRepository, AuthQueryRepository>();

            return services;
        }
    }
}
